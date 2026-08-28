using System;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace AttendanceCollector.Cls
{
    public static class Database
    {
        // =====================================================
        // Database Paths
        // =====================================================

        private static readonly string DbFolder =
            Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "Data"
            );

        private static readonly string DbPath =
            Path.Combine(
                DbFolder,
                "attendance.db"
            );

        private static readonly string ConnectionString =
            $"Data Source={DbPath};Version=3;Foreign Keys=True;Default Timeout=15;";

        // =====================================================
        // Initialize
        // =====================================================

        public static void Initialize()
        {
            if (!Directory.Exists(DbFolder))
            {
                Directory.CreateDirectory(DbFolder);
            }

            if (!File.Exists(DbPath))
            {
                SQLiteConnection.CreateFile(DbPath);
            }

            using (SQLiteConnection con =
                   new SQLiteConnection(ConnectionString))
            {
                con.Open();

                Execute(con, "PRAGMA journal_mode=WAL;");
                Execute(con, "PRAGMA synchronous=NORMAL;");
                Execute(con, "PRAGMA busy_timeout=15000;");

                CreateDevicesTable(con);
                CreateAttendanceTable(con);
                CreateQueueTable(con);
                CreateSettingsTable(con);

                UpdateDevicesTable(con);
                UpdateAttendanceTable(con);
                UpdateQueueTable(con);
                UpdateSettingsTable(con);

                // Collector الافتراضي
                Execute(
                    con,
                    @"
                    INSERT OR IGNORE INTO settings
                    (
                        key,
                        value
                    )
                    VALUES
                    (
                        'collector_code',
                        'COL-MAIN-01'
                    );
                    "
                );
            }
        }

        // =====================================================
        // Create Tables
        // =====================================================

        private static void CreateDevicesTable(
            SQLiteConnection con)
        {
            string sql = @"
                CREATE TABLE IF NOT EXISTS devices
                (
                    id INTEGER PRIMARY KEY AUTOINCREMENT,

                    name TEXT NOT NULL,

                    device_code TEXT NOT NULL,

                    connection_type TEXT NOT NULL DEFAULT 'LOCAL',

                    host TEXT NOT NULL,

                    port INTEGER NOT NULL DEFAULT 4370,

                    password INTEGER NOT NULL DEFAULT 0,

                    enabled INTEGER NOT NULL DEFAULT 1,

                    created_at TEXT NOT NULL
                );

                CREATE UNIQUE INDEX IF NOT EXISTS
                    idx_devices_device_code
                ON devices(device_code);
            ";

            Execute(con, sql);
        }

        private static void CreateAttendanceTable(
            SQLiteConnection con)
        {
            string sql = @"
                CREATE TABLE IF NOT EXISTS attendance
                (
                    id INTEGER PRIMARY KEY AUTOINCREMENT,

                    device_id INTEGER NOT NULL,

                    fingerprint_id TEXT NOT NULL,

                    punch_time TEXT NOT NULL,

                    verify_mode INTEGER,

                    created_at TEXT NOT NULL,

                    UNIQUE
                    (
                        device_id,
                        fingerprint_id,
                        punch_time
                    ),

                    FOREIGN KEY(device_id)
                        REFERENCES devices(id)
                        ON UPDATE CASCADE
                        ON DELETE RESTRICT
                );
            ";

            Execute(con, sql);
        }

        private static void CreateQueueTable(
            SQLiteConnection con)
        {
            string sql = @"
                CREATE TABLE IF NOT EXISTS send_queue
                (
                    id INTEGER PRIMARY KEY AUTOINCREMENT,

                    payload TEXT NOT NULL,

                    status TEXT NOT NULL DEFAULT 'PENDING',

                    attempts INTEGER NOT NULL DEFAULT 0,

                    last_error TEXT,

                    created_at TEXT NOT NULL,

                    last_try_at TEXT,

                    sent_at TEXT
                );
            ";

            Execute(con, sql);
        }

        private static void CreateSettingsTable(
            SQLiteConnection con)
        {
            string sql = @"
                CREATE TABLE IF NOT EXISTS settings
                (
                    key TEXT PRIMARY KEY,

                    value TEXT
                );
            ";

            Execute(con, sql);
        }

        // =====================================================
        // Migration Helpers
        // =====================================================

        private static bool ColumnExists(
            SQLiteConnection con,
            string tableName,
            string columnName)
        {
            string sql =
                "PRAGMA table_info(" +
                tableName +
                ");";

            using (SQLiteCommand cmd =
                   new SQLiteCommand(sql, con))
            using (SQLiteDataReader reader =
                   cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    string name =
                        reader["name"].ToString();

                    if (string.Equals(
                        name,
                        columnName,
                        StringComparison.OrdinalIgnoreCase))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private static void UpdateDevicesTable(
            SQLiteConnection con)
        {
            if (!ColumnExists(
                con,
                "devices",
                "device_code"))
            {
                Execute(
                    con,
                    "ALTER TABLE devices ADD COLUMN device_code TEXT;"
                );
            }

            if (!ColumnExists(
                con,
                "devices",
                "connection_type"))
            {
                Execute(
                    con,
                    "ALTER TABLE devices ADD COLUMN connection_type TEXT NOT NULL DEFAULT 'LOCAL';"
                );
            }

            if (!ColumnExists(
                con,
                "devices",
                "host"))
            {
                Execute(
                    con,
                    "ALTER TABLE devices ADD COLUMN host TEXT NOT NULL DEFAULT '';"
                );
            }

            if (!ColumnExists(
                con,
                "devices",
                "port"))
            {
                Execute(
                    con,
                    "ALTER TABLE devices ADD COLUMN port INTEGER NOT NULL DEFAULT 4370;"
                );
            }

            if (!ColumnExists(
                con,
                "devices",
                "password"))
            {
                Execute(
                    con,
                    "ALTER TABLE devices ADD COLUMN password INTEGER NOT NULL DEFAULT 0;"
                );
            }

            if (!ColumnExists(
                con,
                "devices",
                "enabled"))
            {
                Execute(
                    con,
                    "ALTER TABLE devices ADD COLUMN enabled INTEGER NOT NULL DEFAULT 1;"
                );
            }

            if (!ColumnExists(
                con,
                "devices",
                "created_at"))
            {
                Execute(
                    con,
                    "ALTER TABLE devices ADD COLUMN created_at TEXT;"
                );

                Execute(
                    con,
                    @"UPDATE devices
                      SET created_at = datetime('now')
                      WHERE created_at IS NULL;"
                );
            }
        }

        private static void UpdateAttendanceTable(
            SQLiteConnection con)
        {
            if (!ColumnExists(
                con,
                "attendance",
                "device_id"))
            {
                Execute(
                    con,
                    "ALTER TABLE attendance ADD COLUMN device_id INTEGER;"
                );
            }

            if (!ColumnExists(
                con,
                "attendance",
                "fingerprint_id"))
            {
                Execute(
                    con,
                    "ALTER TABLE attendance ADD COLUMN fingerprint_id TEXT;"
                );
            }

            if (!ColumnExists(
                con,
                "attendance",
                "punch_time"))
            {
                Execute(
                    con,
                    "ALTER TABLE attendance ADD COLUMN punch_time TEXT;"
                );
            }

            if (!ColumnExists(
                con,
                "attendance",
                "verify_mode"))
            {
                Execute(
                    con,
                    "ALTER TABLE attendance ADD COLUMN verify_mode INTEGER;"
                );
            }

            if (!ColumnExists(
                con,
                "attendance",
                "created_at"))
            {
                Execute(
                    con,
                    "ALTER TABLE attendance ADD COLUMN created_at TEXT;"
                );

                Execute(
                    con,
                    @"UPDATE attendance
                      SET created_at = datetime('now')
                      WHERE created_at IS NULL;"
                );
            }
        }

        private static void UpdateQueueTable(
            SQLiteConnection con)
        {
            if (!ColumnExists(
                con,
                "send_queue",
                "payload"))
            {
                Execute(
                    con,
                    "ALTER TABLE send_queue ADD COLUMN payload TEXT;"
                );
            }

            if (!ColumnExists(
                con,
                "send_queue",
                "status"))
            {
                Execute(
                    con,
                    "ALTER TABLE send_queue ADD COLUMN status TEXT NOT NULL DEFAULT 'PENDING';"
                );
            }

            if (!ColumnExists(
                con,
                "send_queue",
                "attempts"))
            {
                Execute(
                    con,
                    "ALTER TABLE send_queue ADD COLUMN attempts INTEGER NOT NULL DEFAULT 0;"
                );
            }

            if (!ColumnExists(
                con,
                "send_queue",
                "last_error"))
            {
                Execute(
                    con,
                    "ALTER TABLE send_queue ADD COLUMN last_error TEXT;"
                );
            }

            if (!ColumnExists(
                con,
                "send_queue",
                "created_at"))
            {
                Execute(
                    con,
                    "ALTER TABLE send_queue ADD COLUMN created_at TEXT;"
                );

                Execute(
                    con,
                    @"UPDATE send_queue
                      SET created_at = datetime('now')
                      WHERE created_at IS NULL;"
                );
            }

            if (!ColumnExists(
                con,
                "send_queue",
                "last_try_at"))
            {
                Execute(
                    con,
                    "ALTER TABLE send_queue ADD COLUMN last_try_at TEXT;"
                );
            }

            if (!ColumnExists(
                con,
                "send_queue",
                "sent_at"))
            {
                Execute(
                    con,
                    "ALTER TABLE send_queue ADD COLUMN sent_at TEXT;"
                );
            }
        }

        private static void UpdateSettingsTable(
            SQLiteConnection con)
        {
            if (!ColumnExists(
                con,
                "settings",
                "value"))
            {
                Execute(
                    con,
                    "ALTER TABLE settings ADD COLUMN value TEXT;"
                );
            }
        }

        // =====================================================
        // Devices
        // =====================================================

        public static int AddDevice(
            string name,
            string deviceCode,
            string connectionType,
            string host,
            int port,
            int password,
            bool enabled)
        {
            using (SQLiteConnection con =
                   GetConnection())
            {
                con.Open();

                string sql = @"
                    INSERT INTO devices
                    (
                        name,
                        device_code,
                        connection_type,
                        host,
                        port,
                        password,
                        enabled,
                        created_at
                    )
                    VALUES
                    (
                        @name,
                        @device_code,
                        @connection_type,
                        @host,
                        @port,
                        @password,
                        @enabled,
                        @created_at
                    );

                    SELECT last_insert_rowid();
                ";

                using (SQLiteCommand cmd =
                       new SQLiteCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue(
                        "@name",
                        name.Trim()
                    );

                    cmd.Parameters.AddWithValue(
                        "@device_code",
                        deviceCode.Trim().ToUpper()
                    );

                    cmd.Parameters.AddWithValue(
                        "@connection_type",
                        connectionType.Trim().ToUpper()
                    );

                    cmd.Parameters.AddWithValue(
                        "@host",
                        host.Trim()
                    );

                    cmd.Parameters.AddWithValue(
                        "@port",
                        port
                    );

                    cmd.Parameters.AddWithValue(
                        "@password",
                        password
                    );

                    cmd.Parameters.AddWithValue(
                        "@enabled",
                        enabled ? 1 : 0
                    );

                    cmd.Parameters.AddWithValue(
                        "@created_at",
                        DateTime.Now.ToString(
                            "yyyy-MM-dd HH:mm:ss"
                        )
                    );

                    return Convert.ToInt32(
                        cmd.ExecuteScalar()
                    );
                }
            }
        }

        public static void UpdateDevice(
            int deviceId,
            string name,
            string deviceCode,
            string connectionType,
            string host,
            int port,
            int password,
            bool enabled)
        {
            using (SQLiteConnection con =
                   GetConnection())
            {
                con.Open();

                string sql = @"
                    UPDATE devices

                    SET
                        name = @name,
                        device_code = @device_code,
                        connection_type = @connection_type,
                        host = @host,
                        port = @port,
                        password = @password,
                        enabled = @enabled

                    WHERE id = @id;
                ";

                using (SQLiteCommand cmd =
                       new SQLiteCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue(
                        "@id",
                        deviceId
                    );

                    cmd.Parameters.AddWithValue(
                        "@name",
                        name.Trim()
                    );

                    cmd.Parameters.AddWithValue(
                        "@device_code",
                        deviceCode.Trim().ToUpper()
                    );

                    cmd.Parameters.AddWithValue(
                        "@connection_type",
                        connectionType.Trim().ToUpper()
                    );

                    cmd.Parameters.AddWithValue(
                        "@host",
                        host.Trim()
                    );

                    cmd.Parameters.AddWithValue(
                        "@port",
                        port
                    );

                    cmd.Parameters.AddWithValue(
                        "@password",
                        password
                    );

                    cmd.Parameters.AddWithValue(
                        "@enabled",
                        enabled ? 1 : 0
                    );

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static DataTable GetDevices()
        {
            DataTable table =
                new DataTable();

            using (SQLiteConnection con =
                   GetConnection())
            {
                con.Open();

                string sql = @"
                    SELECT
                        id,
                        name,
                        device_code,
                        connection_type,
                        host,
                        port,
                        password,
                        enabled

                    FROM devices

                    ORDER BY
                        device_code ASC,
                        name ASC;
                ";

                using (SQLiteDataAdapter adapter =
                       new SQLiteDataAdapter(
                           sql,
                           con
                       ))
                {
                    adapter.Fill(table);
                }
            }

            return table;
        }

        public static DataTable GetActiveDevices()
        {
            DataTable table =
                new DataTable();

            using (SQLiteConnection con =
                   GetConnection())
            {
                con.Open();

                string sql = @"
                    SELECT
                        id,
                        name,
                        device_code,
                        connection_type,
                        host,
                        port,
                        password,
                        enabled

                    FROM devices

                    WHERE enabled = 1

                    ORDER BY
                        device_code ASC,
                        name ASC;
                ";

                using (SQLiteDataAdapter adapter =
                       new SQLiteDataAdapter(
                           sql,
                           con
                       ))
                {
                    adapter.Fill(table);
                }
            }

            return table;
        }

        public static DataTable GetDeviceById(
            int deviceId)
        {
            DataTable table =
                new DataTable();

            using (SQLiteConnection con =
                   GetConnection())
            {
                con.Open();

                string sql = @"
                    SELECT
                        id,
                        name,
                        device_code,
                        connection_type,
                        host,
                        port,
                        password,
                        enabled

                    FROM devices

                    WHERE id = @id

                    LIMIT 1;
                ";

                using (SQLiteCommand cmd =
                       new SQLiteCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue(
                        "@id",
                        deviceId
                    );

                    using (SQLiteDataAdapter adapter =
                           new SQLiteDataAdapter(cmd))
                    {
                        adapter.Fill(table);
                    }
                }
            }

            return table;
        }

        public static void SetDeviceEnabled(
            int deviceId,
            bool enabled)
        {
            using (SQLiteConnection con =
                   GetConnection())
            {
                con.Open();

                string sql = @"
                    UPDATE devices
                    SET enabled = @enabled
                    WHERE id = @id;
                ";

                using (SQLiteCommand cmd =
                       new SQLiteCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue(
                        "@id",
                        deviceId
                    );

                    cmd.Parameters.AddWithValue(
                        "@enabled",
                        enabled ? 1 : 0
                    );

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void DeleteDevice(
            int deviceId)
        {
            using (SQLiteConnection con =
                   GetConnection())
            {
                con.Open();

                string sql = @"
                    DELETE FROM devices
                    WHERE id = @id;
                ";

                using (SQLiteCommand cmd =
                       new SQLiteCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue(
                        "@id",
                        deviceId
                    );

                    cmd.ExecuteNonQuery();
                }
            }
        }

        // =====================================================
        // Attendance
        // =====================================================

        public static bool AddAttendance(
            int deviceId,
            string fingerprintId,
            DateTime punchTime,
            int verifyMode)
        {
            using (SQLiteConnection con =
                   GetConnection())
            {
                con.Open();

                string sql = @"
                    INSERT OR IGNORE INTO attendance
                    (
                        device_id,
                        fingerprint_id,
                        punch_time,
                        verify_mode,
                        created_at
                    )
                    VALUES
                    (
                        @device_id,
                        @fingerprint_id,
                        @punch_time,
                        @verify_mode,
                        @created_at
                    );
                ";

                using (SQLiteCommand cmd =
                       new SQLiteCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue(
                        "@device_id",
                        deviceId
                    );

                    cmd.Parameters.AddWithValue(
                        "@fingerprint_id",
                        fingerprintId
                    );

                    cmd.Parameters.AddWithValue(
                        "@punch_time",
                        punchTime.ToString(
                            "yyyy-MM-dd HH:mm:ss"
                        )
                    );

                    cmd.Parameters.AddWithValue(
                        "@verify_mode",
                        verifyMode
                    );

                    cmd.Parameters.AddWithValue(
                        "@created_at",
                        DateTime.Now.ToString(
                            "yyyy-MM-dd HH:mm:ss"
                        )
                    );

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public static DataTable GetAttendanceLogs(
            DateTime dateFrom,
            DateTime dateTo,
            string fingerprintId,
            string deviceCode,
            int deviceId)
        {
            DataTable table =
                new DataTable();

            using (SQLiteConnection con =
                   GetConnection())
            {
                con.Open();

                string sql = @"
                    SELECT
                        a.id,

                        a.fingerprint_id,

                        substr(
                            a.punch_time,
                            1,
                            10
                        ) AS punch_date,

                        substr(
                            a.punch_time,
                            12,
                            8
                        ) AS punch_time_only,

                        d.device_code,

                        d.name AS device_name,

                        a.verify_mode

                    FROM attendance a

                    INNER JOIN devices d
                        ON d.id = a.device_id

                    WHERE
                        substr(a.punch_time, 1, 10)
                        BETWEEN @date_from AND @date_to

                        AND
                        (
                            @fingerprint_id = ''
                            OR
                            a.fingerprint_id = @fingerprint_id
                        )

                        AND
                        (
                            @device_code = ''
                            OR
                            d.device_code = @device_code
                        )

                        AND
                        (
                            @device_id = 0
                            OR
                            a.device_id = @device_id
                        )

                    ORDER BY
                        a.punch_time DESC;
                ";

                using (SQLiteCommand cmd =
                       new SQLiteCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue(
                        "@date_from",
                        dateFrom.ToString("yyyy-MM-dd")
                    );

                    cmd.Parameters.AddWithValue(
                        "@date_to",
                        dateTo.ToString("yyyy-MM-dd")
                    );

                    cmd.Parameters.AddWithValue(
                        "@fingerprint_id",
                        fingerprintId ?? ""
                    );

                    cmd.Parameters.AddWithValue(
                        "@device_code",
                        deviceCode ?? ""
                    );

                    cmd.Parameters.AddWithValue(
                        "@device_id",
                        deviceId
                    );

                    using (SQLiteDataAdapter adapter =
                           new SQLiteDataAdapter(cmd))
                    {
                        adapter.Fill(table);
                    }
                }
            }

            return table;
        }

        public static DataTable GetEmployeeTimeSheet(
            string fingerprintId,
            DateTime dateFrom,
            DateTime dateTo)
        {
            DataTable table =
                new DataTable();

            using (SQLiteConnection con =
                   GetConnection())
            {
                con.Open();

                string sql = @"
                    SELECT
                        substr(
                            punch_time,
                            1,
                            10
                        ) AS work_date,

                        MIN(
                            substr(
                                punch_time,
                                12,
                                8
                            )
                        ) AS first_punch,

                        MAX(
                            substr(
                                punch_time,
                                12,
                                8
                            )
                        ) AS last_punch,

                        COUNT(*) AS punch_count

                    FROM attendance

                    WHERE
                        fingerprint_id = @fingerprint_id

                        AND
                        substr(
                            punch_time,
                            1,
                            10
                        )
                        BETWEEN
                        @date_from
                        AND
                        @date_to

                    GROUP BY
                        substr(
                            punch_time,
                            1,
                            10
                        )

                    ORDER BY
                        work_date ASC;
                ";

                using (SQLiteCommand cmd =
                       new SQLiteCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue(
                        "@fingerprint_id",
                        fingerprintId
                    );

                    cmd.Parameters.AddWithValue(
                        "@date_from",
                        dateFrom.ToString("yyyy-MM-dd")
                    );

                    cmd.Parameters.AddWithValue(
                        "@date_to",
                        dateTo.ToString("yyyy-MM-dd")
                    );

                    using (SQLiteDataAdapter adapter =
                           new SQLiteDataAdapter(cmd))
                    {
                        adapter.Fill(table);
                    }
                }
            }

            return table;
        }

        // =====================================================
        // Queue
        // =====================================================

        public static long AddToQueue(
            string payload)
        {
            using (SQLiteConnection con =
                   GetConnection())
            {
                con.Open();

                string sql = @"
                    INSERT INTO send_queue
                    (
                        payload,
                        status,
                        attempts,
                        created_at
                    )
                    VALUES
                    (
                        @payload,
                        'PENDING',
                        0,
                        @created_at
                    );

                    SELECT last_insert_rowid();
                ";

                using (SQLiteCommand cmd =
                       new SQLiteCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue(
                        "@payload",
                        payload
                    );

                    cmd.Parameters.AddWithValue(
                        "@created_at",
                        DateTime.Now.ToString(
                            "yyyy-MM-dd HH:mm:ss"
                        )
                    );

                    return Convert.ToInt64(
                        cmd.ExecuteScalar()
                    );
                }
            }
        }

        public static DataTable GetPendingQueue()
        {
            DataTable table =
                new DataTable();

            using (SQLiteConnection con =
                   GetConnection())
            {
                con.Open();

                string sql = @"
                    SELECT
                        id,
                        payload,
                        status,
                        attempts,
                        last_error,
                        created_at,
                        last_try_at,
                        sent_at

                    FROM send_queue

                    WHERE status = 'PENDING'

                    ORDER BY id ASC;
                ";

                using (SQLiteDataAdapter adapter =
                       new SQLiteDataAdapter(
                           sql,
                           con
                       ))
                {
                    adapter.Fill(table);
                }
            }

            return table;
        }

        public static int GetPendingQueueCount()
        {
            using (SQLiteConnection con =
                   GetConnection())
            {
                con.Open();

                using (SQLiteCommand cmd =
                       new SQLiteCommand(
                           @"SELECT COUNT(*)
                             FROM send_queue
                             WHERE status = 'PENDING';",
                           con))
                {
                    return Convert.ToInt32(
                        cmd.ExecuteScalar()
                    );
                }
            }
        }

        public static void MarkQueueSent(
            long queueId)
        {
            using (SQLiteConnection con =
                   GetConnection())
            {
                con.Open();

                string now =
                    DateTime.Now.ToString(
                        "yyyy-MM-dd HH:mm:ss"
                    );

                string sql = @"
                    UPDATE send_queue

                    SET
                        status = 'SENT',
                        attempts = attempts + 1,
                        last_error = NULL,
                        last_try_at = @last_try_at,
                        sent_at = @sent_at

                    WHERE id = @id;
                ";

                using (SQLiteCommand cmd =
                       new SQLiteCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue(
                        "@id",
                        queueId
                    );

                    cmd.Parameters.AddWithValue(
                        "@last_try_at",
                        now
                    );

                    cmd.Parameters.AddWithValue(
                        "@sent_at",
                        now
                    );

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void MarkQueueFailed(
            long queueId,
            string error)
        {
            using (SQLiteConnection con =
                   GetConnection())
            {
                con.Open();

                string sql = @"
                    UPDATE send_queue

                    SET
                        status = 'PENDING',
                        attempts = attempts + 1,
                        last_error = @last_error,
                        last_try_at = @last_try_at

                    WHERE id = @id;
                ";

                using (SQLiteCommand cmd =
                       new SQLiteCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue(
                        "@id",
                        queueId
                    );

                    cmd.Parameters.AddWithValue(
                        "@last_error",
                        error ?? ""
                    );

                    cmd.Parameters.AddWithValue(
                        "@last_try_at",
                        DateTime.Now.ToString(
                            "yyyy-MM-dd HH:mm:ss"
                        )
                    );

                    cmd.ExecuteNonQuery();
                }
            }
        }

        // =====================================================
        // Settings
        // =====================================================

        public static void SetSetting(
            string key,
            string value)
        {
            using (SQLiteConnection con =
                   GetConnection())
            {
                con.Open();

                string sql = @"
                    INSERT OR REPLACE INTO settings
                    (
                        key,
                        value
                    )
                    VALUES
                    (
                        @key,
                        @value
                    );
                ";

                using (SQLiteCommand cmd =
                       new SQLiteCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue(
                        "@key",
                        key
                    );

                    cmd.Parameters.AddWithValue(
                        "@value",
                        value
                    );

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static string GetSetting(
            string key,
            string defaultValue = "")
        {
            using (SQLiteConnection con =
                   GetConnection())
            {
                con.Open();

                string sql = @"
                    SELECT value
                    FROM settings
                    WHERE key = @key
                    LIMIT 1;
                ";

                using (SQLiteCommand cmd =
                       new SQLiteCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue(
                        "@key",
                        key
                    );

                    object result =
                        cmd.ExecuteScalar();

                    if (result == null ||
                        result == DBNull.Value)
                    {
                        return defaultValue;
                    }

                    return result.ToString();
                }
            }
        }

        // =====================================================
        // Dashboard - Today
        // =====================================================

        public static int GetTodayAttendanceCount()
        {
            return ExecuteTodayCount(
                @"SELECT COUNT(*)
                  FROM attendance
                  WHERE substr(punch_time,1,10) = @today;"
            );
        }

        public static int GetTodayFingerprintCount()
        {
            return ExecuteTodayCount(
                @"SELECT COUNT(DISTINCT fingerprint_id)
                  FROM attendance
                  WHERE substr(punch_time,1,10) = @today;"
            );
        }

        public static int GetTodayDevicesCount()
        {
            return ExecuteTodayCount(
                @"SELECT COUNT(DISTINCT device_id)
                  FROM attendance
                  WHERE substr(punch_time,1,10) = @today;"
            );
        }

        private static int ExecuteTodayCount(
            string sql)
        {
            using (SQLiteConnection con =
                   GetConnection())
            {
                con.Open();

                using (SQLiteCommand cmd =
                       new SQLiteCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue(
                        "@today",
                        DateTime.Now.ToString(
                            "yyyy-MM-dd"
                        )
                    );

                    return Convert.ToInt32(
                        cmd.ExecuteScalar()
                    );
                }
            }
        }

        public static DateTime? GetTodayFirstPunch()
        {
            return GetTodayPunchBoundary(
                "MIN"
            );
        }

        public static DateTime? GetTodayLastPunch()
        {
            return GetTodayPunchBoundary(
                "MAX"
            );
        }

        private static DateTime? GetTodayPunchBoundary(
            string aggregate)
        {
            using (SQLiteConnection con =
                   GetConnection())
            {
                con.Open();

                string sql =
                    "SELECT " +
                    aggregate +
                    @"(punch_time)
                      FROM attendance
                      WHERE substr(punch_time,1,10) = @today;";

                using (SQLiteCommand cmd =
                       new SQLiteCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue(
                        "@today",
                        DateTime.Now.ToString(
                            "yyyy-MM-dd"
                        )
                    );

                    object result =
                        cmd.ExecuteScalar();

                    if (result == null ||
                        result == DBNull.Value)
                    {
                        return null;
                    }

                    DateTime value;

                    if (DateTime.TryParse(
                        result.ToString(),
                        out value))
                    {
                        return value;
                    }

                    return null;
                }
            }
        }

        public static int GetTodaySentQueueCount()
        {
            using (SQLiteConnection con =
                   GetConnection())
            {
                con.Open();

                string sql = @"
                    SELECT COUNT(*)

                    FROM send_queue

                    WHERE
                        status = 'SENT'

                        AND
                        substr(sent_at,1,10)
                        = @today;
                ";

                using (SQLiteCommand cmd =
                       new SQLiteCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue(
                        "@today",
                        DateTime.Now.ToString(
                            "yyyy-MM-dd"
                        )
                    );

                    return Convert.ToInt32(
                        cmd.ExecuteScalar()
                    );
                }
            }
        }

        public static int GetTodayPendingQueueCount()
        {
            using (SQLiteConnection con =
                   GetConnection())
            {
                con.Open();

                string sql = @"
                    SELECT COUNT(*)

                    FROM send_queue

                    WHERE
                        status = 'PENDING'

                        AND
                        substr(created_at,1,10)
                        = @today;
                ";

                using (SQLiteCommand cmd =
                       new SQLiteCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue(
                        "@today",
                        DateTime.Now.ToString(
                            "yyyy-MM-dd"
                        )
                    );

                    return Convert.ToInt32(
                        cmd.ExecuteScalar()
                    );
                }
            }
        }

        public static DataTable GetTodayAttendanceSummary()
        {
            DataTable table =
                new DataTable();

            using (SQLiteConnection con =
                   GetConnection())
            {
                con.Open();

                string sql = @"
                    SELECT
                        a.fingerprint_id,

                        d.device_code,

                        d.name AS device_name,

                        MIN(
                            substr(
                                a.punch_time,
                                12,
                                8
                            )
                        ) AS first_punch,

                        MAX(
                            substr(
                                a.punch_time,
                                12,
                                8
                            )
                        ) AS last_punch,

                        COUNT(*) AS punch_count

                    FROM attendance a

                    INNER JOIN devices d
                        ON d.id = a.device_id

                    WHERE
                        substr(
                            a.punch_time,
                            1,
                            10
                        ) = @today

                    GROUP BY
                        a.fingerprint_id,
                        a.device_id,
                        d.device_code,
                        d.name

                    ORDER BY
                        first_punch DESC;
                ";

                using (SQLiteCommand cmd =
                       new SQLiteCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue(
                        "@today",
                        DateTime.Now.ToString(
                            "yyyy-MM-dd"
                        )
                    );

                    using (SQLiteDataAdapter adapter =
                           new SQLiteDataAdapter(cmd))
                    {
                        adapter.Fill(table);
                    }
                }
            }

            return table;
        }

        // =====================================================
        // Sample for n8n
        // =====================================================

        public static DataTable GetLatestAttendanceSample(
            int limit = 3)
        {
            DataTable table =
                new DataTable();

            if (limit < 1)
            {
                limit = 1;
            }

            if (limit > 3)
            {
                limit = 3;
            }

            using (SQLiteConnection con =
                   GetConnection())
            {
                con.Open();

                string sql = @"
                    SELECT
                        a.id,
                        a.fingerprint_id,
                        a.punch_time,
                        a.verify_mode,

                        d.id AS local_device_id,

                        d.name AS device_name,

                        d.device_code AS device_code,

                        d.connection_type

                    FROM attendance a

                    INNER JOIN devices d
                        ON d.id = a.device_id

                    ORDER BY
                        a.punch_time DESC

                    LIMIT @limit;
                ";

                using (SQLiteCommand cmd =
                       new SQLiteCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue(
                        "@limit",
                        limit
                    );

                    using (SQLiteDataAdapter adapter =
                           new SQLiteDataAdapter(cmd))
                    {
                        adapter.Fill(table);
                    }
                }
            }

            return table;
        }

        // =====================================================
        // Device activity today
        // =====================================================

        public static int GetTodayDeviceCodesCount()
        {
            using (SQLiteConnection con =
                   GetConnection())
            {
                con.Open();

                string sql = @"
                    SELECT
                        COUNT(
                            DISTINCT d.device_code
                        )

                    FROM attendance a

                    INNER JOIN devices d
                        ON d.id = a.device_id

                    WHERE
                        substr(
                            a.punch_time,
                            1,
                            10
                        ) = @today;
                ";

                using (SQLiteCommand cmd =
                       new SQLiteCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue(
                        "@today",
                        DateTime.Now.ToString(
                            "yyyy-MM-dd"
                        )
                    );

                    return Convert.ToInt32(
                        cmd.ExecuteScalar()
                    );
                }
            }
        }

        // =====================================================
        // General Helpers
        // =====================================================

        private static void Execute(
            SQLiteConnection con,
            string sql)
        {
            using (SQLiteCommand cmd =
                   new SQLiteCommand(sql, con))
            {
                cmd.ExecuteNonQuery();
            }
        }

        public static SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(
                ConnectionString
            );
        }

        public static string GetDatabasePath()
        {
            return DbPath;
        }
    }
}