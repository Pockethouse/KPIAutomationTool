using OfficeOpenXml;

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

    public void AddResultsToSheet<T>(IEnumerable<T> results)
    {
        using (var package = new ExcelPackage(new FileInfo(_filePath)))
        {
            var worksheet = package.Workbook.Worksheets[_sheetName] ?? package.Workbook.Worksheets.Add(_sheetName);
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

}