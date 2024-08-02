using OfficeOpenXml;
using OfficeOpenXml.Drawing.Chart;

namespace EXCELGRAPHING;


public class Format
{
    private readonly string _filePath;
    private readonly string _sheetName;



    public Format(string filePath, string sheetName = "Sheet1")
    {

        _filePath = filePath;
        _sheetName = sheetName;

    }

               public void AddResultsToSheet<T1, T2>(IEnumerable<T1> results1, IEnumerable<T2> results2, string sheetName)
        {
            using (var package = new ExcelPackage(new FileInfo(_filePath)))
            {
                var worksheet = package.Workbook.Worksheets[sheetName] ?? package.Workbook.Worksheets.Add(sheetName);
                var properties1 = typeof(T1).GetProperties()
                                            .Where(p => p.PropertyType.IsValueType || p.PropertyType == typeof(string))
                                            .ToArray();

                var properties2 = typeof(T2).GetProperties()
                                            .Where(p => p.PropertyType.IsValueType || p.PropertyType == typeof(string))
                                            .ToArray();

                // Determine the last row with data to append new data without overwriting
                int lastRow = worksheet.Dimension?.End.Row ?? 0;
                int startRow = lastRow > 0 ? lastRow + 1 : 1;

                // Add header row if not already present
                if (startRow == 1)
                {
                    for (int i = 0; i < properties1.Length; i++)
                    {
                        worksheet.Cells[startRow, i + 1].Value = properties1[i].Name;
                    }

                    for (int i = 0; i < properties2.Length; i++)
                    {
                        worksheet.Cells[startRow, properties1.Length + i + 1].Value = properties2[i].Name;
                    }

                    startRow++;  // Move to the next row for data
                }

                int row = startRow;

                // Add data rows for results1
                foreach (var result in results1)
                {
                    for (int col = 0; col < properties1.Length; col++)
                    {
                        worksheet.Cells[row, col + 1].Value = properties1[col].GetValue(result);
                    }
                    row++;
                }

                row = startRow;  // Reset row counter for results2

                // Add data rows for results2
                foreach (var result in results2)
                {
                    for (int col = 0; col < properties2.Length; col++)
                    {
                        worksheet.Cells[row, properties1.Length + col + 1].Value = properties2[col].GetValue(result);
                    }
                    row++;
                }

                package.Save();
            }
        }

        public void CreateGraph()
        {
            using (var package = new ExcelPackage(new FileInfo(_filePath)))
            {
                var workbook = package.Workbook;
                var worksheet = workbook.Worksheets[_sheetName] ?? workbook.Worksheets.Add(_sheetName);

                // Define the range of data to be used for the chart
                var dataSheet = workbook.Worksheets["CombinedPayments"];

                // Create a new chart
                var chart = worksheet.Drawings.AddChart("PaymentsChart", eChartType.Line) as ExcelLineChart;

                // Set the title of the chart
                chart.Title.Text = "Payable vs Receivable Payments";

                // Set data series for Payable Payments
                var payableSeries = chart.Series.Add(dataSheet.Cells["B2:B6"], dataSheet.Cells["A2:A6"]);
                payableSeries.Header = "Payable Amount";

                // Set data series for Receivable Payments
                var receivableSeries = chart.Series.Add(dataSheet.Cells["D2:D6"], dataSheet.Cells["C2:C6"]);
                receivableSeries.Header = "Receivable Amount";

                // Set the position and size of the chart
                chart.SetPosition(1, 0, 3, 0);
                chart.SetSize(800, 600);

                package.Save();
            }

        #region Charts Added




/*
  private readonly string _filePath;
        private readonly string _sheetName;

        public Format(string filePath, string sheetName = "Sheet1")
        {
            _filePath = filePath;
            _sheetName = sheetName;
        }

        public void AddResultsToSheet<T>(IEnumerable<T> results, string sheetName)
        {
            using (var package = new ExcelPackage(new FileInfo(_filePath)))
            {
                var worksheet = package.Workbook.Worksheets[sheetName] ?? package.Workbook.Worksheets.Add(sheetName);
                var properties = typeof(T).GetProperties()
                                          .Where(p => p.PropertyType.IsValueType || p.PropertyType == typeof(string))
                                          .ToArray();

                // Add header row
                for (int i = 0; i < properties.Length; i++)
                {
                    worksheet.Cells[1, i + 1].Value = properties[i].Name;
                }

                int row = 2;

                // Add data rows
                foreach (var result in results)
                {
                    for (int col = 0; col < properties.Length; col++)
                    {
                        worksheet.Cells[row, col + 1].Value = properties[col].GetValue(result);
                    }
                    row++;
                }

                package.Save();
            }
        }

        public void CreateGraph()
        {
            using (var package = new ExcelPackage(new FileInfo(_filePath)))
            {
                var workbook = package.Workbook;
                var worksheet = workbook.Worksheets[_sheetName] ?? workbook.Worksheets.Add(_sheetName);

                // Define the range of data to be used for the chart
                var payableSheet = workbook.Worksheets["PayablePayments"];
                var receivableSheet = workbook.Worksheets["ReceivablePayments"];

                // Create a new chart
                var chart = worksheet.Drawings.AddChart("PaymentsChart", eChartType.Line) as ExcelLineChart;

                // Set the title of the chart
                chart.Title.Text = "Payable vs Receivable Payments";

                // Set data series for Payable Payments
                var payableSeries = chart.Series.Add(payableSheet.Cells["B2:B6"], payableSheet.Cells["A2:A6"]);
                payableSeries.Header = "Payable Amount";

                // Set data series for Receivable Payments
                var receivableSeries = chart.Series.Add(receivableSheet.Cells["B2:B6"], receivableSheet.Cells["A2:A6"]);
                receivableSeries.Header = "Receivable Amount";

                // Set the position and size of the chart
                chart.SetPosition(1, 0, 3, 0);
                chart.SetSize(800, 600);

                package.Save();
            }
        }
 */

        #endregion
    }
}