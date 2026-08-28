using ClosedXML.Excel;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;

namespace AttendanceCollector
{
    public partial class TimeSheetForm : Form
    {
        private string userId;
        private DateTime dateFrom;
        private DateTime dateTo;
        private DataTable timeSheetData;

        private PrintDocument printDocument;

        private int printRowIndex = 0;
        private int currentPage = 1;

        public TimeSheetForm(
            string userId,
            DateTime dateFrom,
            DateTime dateTo,
            DataTable timeSheetData)
        {
            InitializeComponent();

            this.userId = userId;
            this.dateFrom = dateFrom;
            this.dateTo = dateTo;
            this.timeSheetData = timeSheetData;

            InitializePrintDocument();
        }

        // =====================================================
        // Load
        // =====================================================

        private void TimeSheetForm_Load(
            object sender,
            EventArgs e)
        {
            lblFingerprintValue.Text =
                userId;

            lblPeriodValue.Text =
                dateFrom.ToString("yyyy-MM-dd") +
                "  إلى  " +
                dateTo.ToString("yyyy-MM-dd");

            dgvTimeSheet.AutoGenerateColumns = false;

            colDate.DataPropertyName =
                "work_date";

            colFirstPunch.DataPropertyName =
                "first_punch";

            colLastPunch.DataPropertyName =
                "last_punch";

            colPunchCount.DataPropertyName =
                "punch_count";

            dgvTimeSheet.DataSource =
                timeSheetData;

            int days =
                timeSheetData != null
                    ? timeSheetData.Rows.Count
                    : 0;

            lblTotalDaysValue.Text =
                days.ToString();

            dgvTimeSheet.ClearSelection();
        }

        // =====================================================
        // Close
        // =====================================================

        private void btnClose_Click(
            object sender,
            EventArgs e)
        {
            Close();
        }

        // =====================================================
        // Excel
        // =====================================================

        private void btnExportExcel_Click(
            object sender,
            EventArgs e)
        {
            if (timeSheetData == null ||
                timeSheetData.Rows.Count == 0)
            {
                MessageBox.Show(
                    "لا توجد بيانات لتصديرها.",
                    "تصدير Excel",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                return;
            }

            try
            {
                using (SaveFileDialog save =
                       new SaveFileDialog())
                {
                    save.Title =
                        "حفظ Time Sheet";

                    save.Filter =
                        "Excel Workbook (*.xlsx)|*.xlsx";

                    save.FileName =
                        "TimeSheet_" +
                        userId +
                        "_" +
                        dateFrom.ToString("yyyyMMdd") +
                        "_" +
                        dateTo.ToString("yyyyMMdd") +
                        ".xlsx";

                    if (save.ShowDialog() !=
                        DialogResult.OK)
                    {
                        return;
                    }

                    using (XLWorkbook workbook =
                           new XLWorkbook())
                    {
                        IXLWorksheet sheet =
                            workbook.Worksheets.Add(
                                "Time Sheet"
                            );

                        // =====================================
                        // Main Title
                        // =====================================

                        sheet.Cell("A1").Value =
                            "Attendance Collector";

                        sheet.Range("A1:D1").Merge();

                        sheet.Cell("A1").Style.Font.Bold =
                            true;

                        sheet.Cell("A1").Style.Font.FontSize =
                            16;

                        sheet.Cell("A1").Style.Alignment.Horizontal =
                            XLAlignmentHorizontalValues.Center;

                        // =====================================
                        // Time Sheet Title
                        // =====================================

                        sheet.Cell("A2").Value =
                            "كشف حركة الموظف - Time Sheet";

                        sheet.Range("A2:D2").Merge();

                        sheet.Cell("A2").Style.Font.Bold =
                            true;

                        sheet.Cell("A2").Style.Font.FontSize =
                            13;

                        sheet.Cell("A2").Style.Alignment.Horizontal =
                            XLAlignmentHorizontalValues.Center;

                        // =====================================
                        // Information
                        // =====================================

                        sheet.Cell("A4").Value =
                            "USER ID / رقم الموظف";

                        sheet.Cell("B4").Value =
                            userId;

                        sheet.Cell("C4").Value =
                            "الفترة";

                        sheet.Cell("D4").Value =
                            dateFrom.ToString("yyyy-MM-dd") +
                            " إلى " +
                            dateTo.ToString("yyyy-MM-dd");

                        sheet.Cell("A5").Value =
                            "أيام بها حركة";

                        sheet.Cell("B5").Value =
                            timeSheetData.Rows.Count;

                        // =====================================
                        // Table Headers
                        // =====================================

                        int headerRow = 7;

                        sheet.Cell(headerRow, 1).Value =
                            "التاريخ";

                        sheet.Cell(headerRow, 2).Value =
                            "أول بصمة";

                        sheet.Cell(headerRow, 3).Value =
                            "آخر بصمة";

                        sheet.Cell(headerRow, 4).Value =
                            "عدد البصمات";

                        IXLRange headerRange =
                            sheet.Range(
                                headerRow,
                                1,
                                headerRow,
                                4
                            );

                        headerRange.Style.Font.Bold =
                            true;

                        headerRange.Style.Alignment.Horizontal =
                            XLAlignmentHorizontalValues.Center;

                        headerRange.Style.Border.BottomBorder =
                            XLBorderStyleValues.Thin;

                        headerRange.Style.Border.TopBorder =
                            XLBorderStyleValues.Thin;

                        headerRange.Style.Border.LeftBorder =
                            XLBorderStyleValues.Thin;

                        headerRange.Style.Border.RightBorder =
                            XLBorderStyleValues.Thin;

                        // =====================================
                        // Data
                        // =====================================

                        int excelRow =
                            headerRow + 1;

                        foreach (DataRow row
                                 in timeSheetData.Rows)
                        {
                            sheet.Cell(excelRow, 1).Value =
                                row["work_date"]
                                .ToString();

                            sheet.Cell(excelRow, 2).Value =
                                row["first_punch"]
                                .ToString();

                            sheet.Cell(excelRow, 3).Value =
                                row["last_punch"]
                                .ToString();

                            sheet.Cell(excelRow, 4).Value =
                                row["punch_count"]
                                .ToString();

                            excelRow++;
                        }

                        // =====================================
                        // Table Formatting
                        // =====================================

                        if (excelRow > headerRow + 1)
                        {
                            IXLRange dataRange =
                                sheet.Range(
                                    headerRow + 1,
                                    1,
                                    excelRow - 1,
                                    4
                                );

                            dataRange.Style.Alignment.Horizontal =
                                XLAlignmentHorizontalValues.Center;

                            dataRange.Style.Border.BottomBorder =
                                XLBorderStyleValues.Thin;

                            dataRange.Style.Border.TopBorder =
                                XLBorderStyleValues.Thin;

                            dataRange.Style.Border.LeftBorder =
                                XLBorderStyleValues.Thin;

                            dataRange.Style.Border.RightBorder =
                                XLBorderStyleValues.Thin;
                        }

                        // =====================================
                        // RTL
                        // =====================================

                        sheet.RightToLeft = true;

                        // =====================================
                        // Width
                        // =====================================

                        sheet.Columns()
                            .AdjustToContents();

                        sheet.Column(1).Width =
                            Math.Max(
                                sheet.Column(1).Width,
                                16
                            );

                        sheet.Column(2).Width =
                            Math.Max(
                                sheet.Column(2).Width,
                                16
                            );

                        sheet.Column(3).Width =
                            Math.Max(
                                sheet.Column(3).Width,
                                16
                            );

                        sheet.Column(4).Width =
                            Math.Max(
                                sheet.Column(4).Width,
                                16
                            );

                        // =====================================
                        // Freeze Header
                        // =====================================

                        sheet.SheetView
                            .FreezeRows(headerRow);

                        // =====================================
                        // Save
                        // =====================================

                        workbook.SaveAs(
                            save.FileName
                        );
                    }

                    MessageBox.Show(
                        "تم تصدير Time Sheet إلى Excel بنجاح.",
                        "Excel",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "حدث خطأ أثناء تصدير Excel:\n\n" +
                    ex.Message,
                    "خطأ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // =====================================================
        // Printing / PDF
        // =====================================================

        private void InitializePrintDocument()
        {
            printDocument =
                new PrintDocument();

            printDocument.DocumentName =
                "TimeSheet_" +
                userId;

            printDocument.DefaultPageSettings.Landscape =
                false;

            printDocument.PrintPage +=
                PrintDocument_PrintPage;

            printDocument.BeginPrint +=
                PrintDocument_BeginPrint;
        }

        // =====================================================
        // Begin Print
        // =====================================================

        private void PrintDocument_BeginPrint(
            object sender,
            PrintEventArgs e)
        {
            printRowIndex = 0;
            currentPage = 1;
        }

        // =====================================================
        // PDF / Print Button
        // =====================================================

        private void btnPrint_Click(
            object sender,
            EventArgs e)
        {
            if (timeSheetData == null ||
                timeSheetData.Rows.Count == 0)
            {
                MessageBox.Show(
                    "لا توجد بيانات للطباعة.",
                    "Time Sheet",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                return;
            }

            try
            {
                using (PrintPreviewDialog preview =
                       new PrintPreviewDialog())
                {
                    preview.Document =
                        printDocument;

                    preview.Width =
                        1100;

                    preview.Height =
                        750;

                    preview.StartPosition =
                        FormStartPosition.CenterParent;

                    preview.ShowDialog(
                        this
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "حدث خطأ أثناء تجهيز الطباعة:\n\n" +
                    ex.Message,
                    "خطأ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // =====================================================
        // Print Page
        // =====================================================

        private void PrintDocument_PrintPage(
            object sender,
            PrintPageEventArgs e)
        {
            Graphics g =
                e.Graphics;

            Rectangle bounds =
                e.MarginBounds;

            using (Font titleFont =
                   new Font(
                       "Arial",
                       16,
                       FontStyle.Bold))
            using (Font subTitleFont =
                   new Font(
                       "Arial",
                       11,
                       FontStyle.Bold))
            using (Font normalFont =
                   new Font(
                       "Arial",
                       9,
                       FontStyle.Regular))
            using (Font tableHeaderFont =
                   new Font(
                       "Arial",
                       9,
                       FontStyle.Bold))
            using (Pen borderPen =
                   new Pen(Color.Black))
            {
                StringFormat center =
                    new StringFormat();

                center.Alignment =
                    StringAlignment.Center;

                center.LineAlignment =
                    StringAlignment.Center;

                StringFormat right =
                    new StringFormat();

                right.Alignment =
                    StringAlignment.Far;

                right.LineAlignment =
                    StringAlignment.Center;

                // ============================================
                // Title
                // ============================================

                float y =
                    bounds.Top;

                g.DrawString(
                    "Attendance Collector",
                    titleFont,
                    Brushes.Black,
                    new RectangleF(
                        bounds.Left,
                        y,
                        bounds.Width,
                        35
                    ),
                    center
                );

                y += 40;

                g.DrawString(
                    "Time Sheet - كشف حركة الموظف",
                    subTitleFont,
                    Brushes.Black,
                    new RectangleF(
                        bounds.Left,
                        y,
                        bounds.Width,
                        30
                    ),
                    center
                );

                y += 42;

                // ============================================
                // Employee Info
                // ============================================

                g.DrawString(
                    "USER ID / رقم الموظف: " +
                    userId,
                    normalFont,
                    Brushes.Black,
                    new RectangleF(
                        bounds.Left,
                        y,
                        bounds.Width,
                        25
                    ),
                    right
                );

                y += 25;

                g.DrawString(
                    "الفترة: " +
                    dateFrom.ToString("yyyy-MM-dd") +
                    " إلى " +
                    dateTo.ToString("yyyy-MM-dd"),
                    normalFont,
                    Brushes.Black,
                    new RectangleF(
                        bounds.Left,
                        y,
                        bounds.Width,
                        25
                    ),
                    right
                );

                y += 25;

                g.DrawString(
                    "أيام بها حركة: " +
                    timeSheetData.Rows.Count,
                    normalFont,
                    Brushes.Black,
                    new RectangleF(
                        bounds.Left,
                        y,
                        bounds.Width,
                        25
                    ),
                    right
                );

                y += 40;

                // ============================================
                // Table Dimensions
                // ============================================

                int tableWidth =
                    bounds.Width;

                int columnWidth =
                    tableWidth / 4;

                int rowHeight =
                    30;

                // ============================================
                // Header
                // ============================================

                string[] headers =
                {
                    "التاريخ",
                    "أول بصمة",
                    "آخر بصمة",
                    "عدد البصمات"
                };

                for (int i = 0; i < 4; i++)
                {
                    Rectangle rect =
                        new Rectangle(
                            bounds.Left +
                            (i * columnWidth),
                            (int)y,
                            columnWidth,
                            rowHeight
                        );

                    g.DrawRectangle(
                        borderPen,
                        rect
                    );

                    g.DrawString(
                        headers[i],
                        tableHeaderFont,
                        Brushes.Black,
                        rect,
                        center
                    );
                }

                y += rowHeight;

                // ============================================
                // Rows
                // ============================================

                while (
                    printRowIndex <
                    timeSheetData.Rows.Count
                )
                {
                    // هل يوجد مكان للصف؟
                    if (
                        y + rowHeight >
                        bounds.Bottom - 35
                    )
                    {
                        e.HasMorePages =
                            true;

                        currentPage++;

                        return;
                    }

                    DataRow row =
                        timeSheetData.Rows[
                            printRowIndex
                        ];

                    string[] values =
                    {
                        row["work_date"].ToString(),
                        row["first_punch"].ToString(),
                        row["last_punch"].ToString(),
                        row["punch_count"].ToString()
                    };

                    for (int i = 0; i < 4; i++)
                    {
                        Rectangle rect =
                            new Rectangle(
                                bounds.Left +
                                (i * columnWidth),
                                (int)y,
                                columnWidth,
                                rowHeight
                            );

                        g.DrawRectangle(
                            borderPen,
                            rect
                        );

                        g.DrawString(
                            values[i],
                            normalFont,
                            Brushes.Black,
                            rect,
                            center
                        );
                    }

                    y += rowHeight;

                    printRowIndex++;
                }

                // ============================================
                // Page Number
                // ============================================

                g.DrawString(
                    "Page " +
                    currentPage,
                    normalFont,
                    Brushes.Gray,
                    new RectangleF(
                        bounds.Left,
                        bounds.Bottom - 25,
                        bounds.Width,
                        20
                    ),
                    center
                );

                e.HasMorePages =
                    false;
            }
        }
    }
}