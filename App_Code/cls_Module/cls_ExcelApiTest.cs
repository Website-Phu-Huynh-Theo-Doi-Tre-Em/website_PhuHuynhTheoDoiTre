using System;
using System.Collections;
using System.Globalization;
using System.Runtime.InteropServices;
using xl = Microsoft.Office.Interop.Excel;

public class cls_ExcelApiTest
{
    xl.Application xlApp = null;
    xl.Workbooks workbooks = null;
    xl.Workbook workbook = null;
    Hashtable sheets;
    public string xlFilePath;

    public cls_ExcelApiTest(string xlFilePath)
    {
        this.xlFilePath = xlFilePath;
    }

    public void OpenExcel()
    {
        xlApp = new xl.Application();
        workbooks = xlApp.Workbooks;
        workbook = workbooks.Open(xlFilePath);
        sheets = new Hashtable();
        int count = 1;

        // Lưu trữ tên worksheet trong Hashtable 
        foreach(xl.Worksheet sheet in workbook.Sheets)
        {
            sheets[count] = sheet.Name;
            count++;
        }
    }

    public void CloseExcel()
    {
        workbook.Close(false, xlFilePath, null); // Đóng kết nối với workbook
        Marshal.FinalReleaseComObject(workbook); // Giải phóng đối tượng 
        workbook = null;

        workbooks.Close();
        Marshal.FinalReleaseComObject(workbooks);
        workbooks = null;

        xlApp.Quit();
        Marshal.FinalReleaseComObject(xlApp);
        xlApp = null;
    }

    public int GetRowCount(string sheetName)
    {
        int rowCount = 0;
        int sheetValue = 0;
        if(sheets.ContainsValue(sheetName))
        {
            foreach(DictionaryEntry sheet in sheets) // lặp lại Hastable 
            {
                if(sheet.Value.Equals(sheetName))
                {
                    sheetValue = (int)sheet.Key;
                }    
            }

            // Lấy ra worksheet cụ thể bằng key trong workbook
            xl.Worksheet ws = workbook.Worksheets[sheetValue] as xl.Worksheet;
            xl.Range range = ws.UsedRange; // Độ dài tổng các cell có dữ liệu
            rowCount = range.Rows.Count;
        }
        return rowCount;
    }

    public int GetColumnCount(string sheetName)
    {
        int colCount = 0;
        int sheetValue = 0;
        if(sheets.ContainsValue(sheetName))
        {
            foreach(DictionaryEntry sheet in sheets)
            {
                if(sheet.Value.Equals(sheetName))
                {
                    sheetValue = (int)sheet.Key;
                }
            }
            xl.Worksheet ws = workbook.Worksheets[sheetValue] as xl.Worksheet;
            xl.Range range = ws.UsedRange;
            colCount = range.Columns.Count;
        }
        return colCount;
    }

    public string GetCellData(string sheetName, int colNumber, int rowNumber)
    {
        string value = "";
        int sheetValue = 0;

        if(sheets.ContainsValue(sheetName))
        {
            foreach(DictionaryEntry sheet in sheets)
            {
                if(sheet.Value.Equals(sheetName))
                { 
                    sheetValue = (int)sheet.Key;
                }
            }
            xl.Worksheet ws = workbook.Worksheets[sheetValue] as xl.Worksheet;
            xl.Range range = ws.UsedRange;
            value = ((range.Cells[rowNumber, colNumber] as xl.Range).Value2).ToString();
            Marshal.FinalReleaseComObject(ws);
            ws = null;
        }
        return value;
    }

    public string GetCellData(string sheetName, string colName, int rowNumber)
    {
        string value = "";
        int sheetValue = 0;
        int colNumber = 0;
        bool needFormated = false;

        if (sheets.ContainsValue(sheetName))
        {
            foreach (DictionaryEntry sheet in sheets)
            {
                if (sheet.Value.Equals(sheetName))
                {
                    sheetValue = (int)sheet.Key;
                }
            }
            xl.Worksheet ws = workbook.Worksheets[sheetValue] as xl.Worksheet;
            xl.Range range = ws.UsedRange;
            
            for(int i = 1; i <= range.Columns.Count; i++) 
            {
                string colNameValue = ((range.Cells[3, i] as xl.Range).Value2).ToString(); // i = 3 là hàng 3 có chứa các tên column
                if (colNameValue.ToLower().Equals(colName.ToLower()))
                {
                    if (colName.ToLower() == "ngày sinh")
                        needFormated = true; // cần định dạng lại ngày sinh
                    else
                        needFormated = false;
                    colNumber = i;
                    break;
                }
            }

            if((range.Cells[rowNumber, colNumber] as xl.Range).Value2 == null)
            {
                if (colName.ToLower() == "ngày sinh") // hàng chứa cột ngày sinh không có dữ liệu (vẫn có kẻ ô)
                    return "end";                     // tức là hàng rỗng => end để không bị lỗi convert datetime

                value = "";
            }
            else
            {
                if(needFormated)
                    value = Convert.ToDateTime((range.Cells[rowNumber, colNumber] as xl.Range).Value).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                else
                    value = ((range.Cells[rowNumber, colNumber] as xl.Range).Value2).ToString();
            }
            Marshal.FinalReleaseComObject(ws);
            ws = null;
        }
        return value;
    }
}
