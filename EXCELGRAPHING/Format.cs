using OfficeOpenXml;
using OfficeOpenXml.Drawing.Chart;

namespace EXCELGRAPHING;


public class Format
{
    private readonly string _filePath;
    private readonly string _defaultSheetName;

    public Format(string filePath, string defaultSheetName = "Sheet1")
    {
        _filePath = filePath;
        _defaultSheetName = defaultSheetName;
    }

    // This method now includes ProductLineID in the Payables data
    public void AddResultsToSheet<T1, T2>(
        IEnumerable<T1> payables, 
        IEnumerable<T2> productLines, 
        string sheetName,
        IDictionary<string, string> headers1 = null, 
        IDictionary<string, string> headers2 = null)
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

            int lastRow = worksheet.Dimension?.End.Row ?? 0;
            int startRow = lastRow > 0 ? lastRow + 1 : 1;

            // Add header row if not already present
            if (startRow == 1)
            {
                for (int i = 0; i < properties1.Length; i++)
                {
                    var header = headers1 != null && headers1.ContainsKey(properties1[i].Name)
                        ? headers1[properties1[i].Name]
                        : properties1[i].Name;
                    worksheet.Cells[startRow, i + 1].Value = header;
                }

                for (int i = 0; i < properties2.Length; i++)
                {
                    var header = headers2 != null && headers2.ContainsKey(properties2[i].Name)
                        ? headers2[properties2[i].Name]
                        : properties2[i].Name;
                    worksheet.Cells[startRow, properties1.Length + i + 1].Value = header;
                }

                startRow++;
            }

            int row = startRow;

            // Add data rows for payables
            foreach (var result in payables)
            {
                for (int col = 0; col < properties1.Length; col++)
                {
                    var value = properties1[col].GetValue(result);
                    if (value is DateTime dateValue)
                    {
                        worksheet.Cells[row, col + 1].Value = dateValue;
                        worksheet.Cells[row, col + 1].Style.Numberformat.Format = "yyyy-mm-dd";
                    }
                    else
                    {
                        worksheet.Cells[row, col + 1].Value = value;
                    }
                }
                row++;
            }

            row = startRow;

            // Add data rows for product lines
            foreach (var result in productLines)
            {
                for (int col = 0; col < properties2.Length; col++)
                {
                    var value = properties2[col].GetValue(result);
                    if (value is DateTime dateValue)
                    {
                        worksheet.Cells[row, properties1.Length + col + 1].Value = dateValue;
                        worksheet.Cells[row, properties1.Length + col + 1].Style.Numberformat.Format = "yyyy-mm-dd";
                    }
                    else
                    {
                        worksheet.Cells[row, properties1.Length + col + 1].Value = value;
                    }
                }
                row++;
            }

            package.Save();
        }
    }

    // Updated to create chart based on ProductLineID
 public void CreateGraphByProductLine(
    string sheetName = null, 
    string chartTitle = "Payable Payments by Product Line", 
    string xAxisTitle = "Date", 
    string yAxisTitle = "Amount ($)")
{
    using (var package = new ExcelPackage(new FileInfo(_filePath)))
    {
        var worksheet = package.Workbook.Worksheets[sheetName ?? _defaultSheetName];
        int lastRow = worksheet.Dimension?.End.Row ?? 2;

        // Remove existing chart if present
        var existingChart = worksheet.Drawings.FirstOrDefault(d => d.Name == "PaymentsChart") as ExcelChart;
        if (existingChart != null)
        {
            worksheet.Drawings.Remove(existingChart);
        }

        // Create new chart
        var chart = worksheet.Drawings.AddChart("PaymentsChart", eChartType.Line) as ExcelLineChart;

        // Set chart titles
        chart.Title.Text = chartTitle;
        chart.XAxis.Title.Text = xAxisTitle;
        chart.YAxis.Title.Text = yAxisTitle;

        // Format X-axis to display dates correctly
        chart.XAxis.Format = "yyyy-mm-dd";
        chart.XAxis.CrossesAt = 0; // Ensures the X-axis starts at the bottom

        // Group payments by product line and add series to chart
        var productLineGroups = worksheet.Cells[2, 3, lastRow, 3].GroupBy(c => c.Text).ToList(); // Assumes product line names are in column 3

        foreach (var group in productLineGroups)
        {
            string productLineName = group.Key;
            var firstCell = group.First().Start;
            var lastCell = group.Last().Start;

            var payableAmountRange = worksheet.Cells[firstCell.Row, 2, lastCell.Row, 2].Address; // Assumes payable amounts are in column 2
            var payableDateRange = worksheet.Cells[firstCell.Row, 1, lastCell.Row, 1].Address; // Assumes payable dates are in column 1

            var series = chart.Series.Add(payableAmountRange, payableDateRange);
            series.Header = productLineName;
        }

        // Set chart position and size
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