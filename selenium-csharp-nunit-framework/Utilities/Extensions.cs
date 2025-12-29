using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using NUnit.Framework.Internal;
using NUnit.Framework.Internal.Execution;
using OpenQA.Selenium.BiDi.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace selenium_csharp_nunit_framework.Utilities
{
    public class Extensions
    {
        //Extensions class creted for update data in excel sheet in the form of pass or fail tescases
        public static void UpdateExcelTestReport(string Component, string Action, string ObjectName, string Status, string TestData, string Notes)
        {
            string file = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "Reports",
                "ExecutionReport.xlsx"
            );

            try
            {
                string tcName = TestContext.CurrentContext.Test.Name.Replace('"', '\'').Replace(";", "-").Replace("/", "_");
                int tcNameLength = TestContext.CurrentContext.Test.Name.Replace('"', '\'').Replace(";", "-").Replace("/", "_").Length;

                if (tcNameLength > 50)
                {
                    if (tcName.Contains("Iteration"))
                    {
                        string _tcname = tcName.Split(',')[0];
                        tcName = _tcname.Replace("'", "").Replace("(", "");
                    }
                    else
                    {
                        tcName = tcName[..50] + "...";
                    }
                }

                using SpreadsheetDocument doc = SpreadsheetDocument.Open(file, true);
                WorkbookPart? workbookPart = doc.WorkbookPart;
                Sheets? thesheetcollection = workbookPart?.Workbook.GetFirstChild<Sheets>();

                Sheet? selectedSheet = thesheetcollection?.GetFirstChild<Sheet>();
                Worksheet? selectedWorksheet = ((WorksheetPart)workbookPart.GetPartById(selectedSheet.Id)).Worksheet;

                SheetData sheetdata = selectedWorksheet?.GetFirstChild<SheetData>();
                Row selectedRow = new();
                FillSelectedCell(selectedRow, CellValues.String, tcName);
                FillSelectedCell(selectedRow, CellValues.String, Component);
                FillSelectedCell(selectedRow, CellValues.String, Action);
                FillSelectedCell(selectedRow, CellValues.String, ObjectName);
                FillSelectedCell(selectedRow, CellValues.String, TestData);
                FillSelectedCell(selectedRow, CellValues.String, Status);
                FillSelectedCell(selectedRow, CellValues.String, Notes);

                sheetdata.AppendChild(selectedRow);
                workbookPart.Workbook.Save();

                //string sheetName = "ExecutionReport";
                //Application oXL = null;
                //_Workbook oWB = null;
                //_Worksheet oSheet = null;

                //try
                //{
                //    oXL = new Application();
                //    oWB = oXL.Workbooks.Open("d:\\MyExcel.xlsx");
                //    oSheet = String.IsNullOrEmpty(sheetName) ? (_Worksheet)oWB.ActiveSheet : (_Worksheet)oWB.Worksheets[sheetName];

                //    oSheet.Cells[row, col] = data;

                //    oWB.Save();
            }
            catch (Exception ex)
            {
                Logger.Log.Error("" + ex.Message);
                throw;
            }
            //finally
            //{
            //    if (oWB != null)
            //        oWB.Close();
            //}
            //row = row + 1;
        }

        private static void FillSelectedCell(Row currentRow, CellValues dataType, string cellValue)
        {
            Cell selectedCell = new()
            {
                DataType = dataType,
                CellValue = new CellValue(cellValue)
            };
            currentRow.AppendChild(selectedCell);
        }

    }
}
