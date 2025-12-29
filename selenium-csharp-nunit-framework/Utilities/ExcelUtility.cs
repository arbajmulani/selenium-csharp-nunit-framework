using OfficeOpenXml;
using selenium_csharp_nunit_framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace selenium_csharp_nunit_framework.Utilities
{
    public class ExcelUtility
    {
        public static T ReadSingleRow<T>(
     string filePath,
     string sheetName,
     int rowNumber = 2
 ) where T : new()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using var package = new ExcelPackage(new FileInfo(filePath));

            var sheet = package.Workbook.Worksheets
                            .FirstOrDefault(x => x.Name.Equals(
                                sheetName, StringComparison.OrdinalIgnoreCase));

            if (sheet == null)
            {
                throw new ArgumentException(
                    $"Sheet '{sheetName}' not found in Excel file.");
            }

            if (sheet.Dimension == null)
            {
                throw new InvalidOperationException(
                    $"Sheet '{sheetName}' is empty.");
            }

            var headers = new Dictionary<string, int>();

            for (int col = 1; col <= sheet.Dimension.End.Column; col++)
            {
                var header = sheet.Cells[1, col].Text?.Trim();
                if (!string.IsNullOrEmpty(header))
                    headers[header] = col;
            }

            T model = new T();
            var props = typeof(T).GetProperties();

            foreach (var prop in props)
            {
                if (headers.TryGetValue(prop.Name, out int col))
                {
                    var value = sheet.Cells[rowNumber, col].Text;
                    prop.SetValue(model, value);
                }
            }

            return model;
        }
    }
}
