using System;
using System.Collections.Generic;
using zkemkeeper;

namespace AttendanceCollector.Helper
{
    public class ZkAttendanceRecord
    {
        public string FingerprintId { get; set; }

        public DateTime PunchTime { get; set; }

        public int VerifyMode { get; set; }

        public int InOutMode { get; set; }

        public int WorkCode { get; set; }
    }

    public class ZktecoHelper
    {
        private CZKEM zk;
        private bool connected = false;

        public int LastErrorCode { get; private set; }

        public ZktecoHelper()
        {
            zk = new CZKEM();
        }

        // =====================================================
        // Connect
        // =====================================================

        public bool Connect(
            string ip,
            int port,
            int password = 0)
        {
            LastErrorCode = 0;
            connected = false;

            try
            {
                if (password > 0)
                {
                    zk.SetCommPassword(password);
                }

                connected =
                    zk.Connect_Net(
                        ip.Trim(),
                        port
                    );

                if (!connected)
                {
                    int errorCode = 0;

                    zk.GetLastError(
                        ref errorCode
                    );

                    LastErrorCode =
                        errorCode;
                }

                return connected;
            }
            catch
            {
                connected = false;
                throw;
            }
        }

        // =====================================================
        // Attendance Logs
        // =====================================================

        public List<ZkAttendanceRecord> GetAttendanceLogs()
        {
            List<ZkAttendanceRecord> records =
                new List<ZkAttendanceRecord>();

            if (!connected)
                return records;

            LastErrorCode = 0;

            try
            {
                int machineNumber = 1;

                bool loaded =
                    zk.ReadGeneralLogData(
                        machineNumber
                    );

                if (!loaded)
                {
                    int error = 0;

                    zk.GetLastError(
                        ref error
                    );

                    LastErrorCode =
                        error;

                    return records;
                }

                string enrollNumber;

                int verifyMode;
                int inOutMode;

                int year;
                int month;
                int day;

                int hour;
                int minute;
                int second;

                int workCode = 0;

                while (
                    zk.SSR_GetGeneralLogData(
                        machineNumber,
                        out enrollNumber,
                        out verifyMode,
                        out inOutMode,
                        out year,
                        out month,
                        out day,
                        out hour,
                        out minute,
                        out second,
                        ref workCode
                    )
                )
                {
                    try
                    {
                        DateTime punchTime =
                            new DateTime(
                                year,
                                month,
                                day,
                                hour,
                                minute,
                                second
                            );

                        records.Add(
                            new ZkAttendanceRecord
                            {
                                FingerprintId =
                                    enrollNumber,

                                PunchTime =
                                    punchTime,

                                VerifyMode =
                                    verifyMode,

                                InOutMode =
                                    inOutMode,

                                WorkCode =
                                    workCode
                            }
                        );
                    }
                    catch
                    {
                        // نتجاهل فقط السجل ذو التاريخ غير الصالح
                    }
                }

                return records;
            }
            catch
            {
                throw;
            }
        }

        // =====================================================
        // Serial Number
        // =====================================================

        public string GetSerialNumber()
        {
            if (!connected)
                return "";

            LastErrorCode = 0;

            try
            {
                string serialNumber = "";

                bool result =
                    zk.GetSerialNumber(
                        1,
                        out serialNumber
                    );

                if (result)
                {
                    return serialNumber;
                }

                int error = 0;

                zk.GetLastError(
                    ref error
                );

                LastErrorCode =
                    error;

                return "";
            }
            catch
            {
                return "";
            }
        }

        // =====================================================
        // Disconnect
        // =====================================================

        public void Disconnect()
        {
            try
            {
                if (connected)
                {
                    zk.Disconnect();
                }
            }
            finally
            {
                connected = false;
            }
        }

        // =====================================================
        // Status
        // =====================================================

        public bool IsConnected
        {
            get
            {
                return connected;
            }
        }
    }
}