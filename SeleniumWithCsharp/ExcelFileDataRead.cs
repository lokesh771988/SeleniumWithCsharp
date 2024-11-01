using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using XL = Microsoft.Office.Interop.Excel;

namespace SeleniumWithCsharp
{
    public class ExcelFileDataRead
    {
        XL.Application app = null;
        XL.Workbooks workbooks = null;
        XL.Workbook workbook = null;
        Hashtable sheets;
        public string filePath;

        public ExcelFileDataRead(string filePath)
        {
            this.filePath = filePath;
        }

        public void openExcelFile()
        {
            app = new XL.Application();
            workbooks = app.Workbooks;
            workbook = workbooks.Open(filePath);
            sheets = new Hashtable();
            int count = 1;
            foreach(XL.Worksheet sheet in workbook.Sheets)
            {
                sheets[count] = sheet.Name;
                count++;
            }
        }

        public void closeExcel()
        {
            workbook.Close(false, filePath, null);
            Marshal.FinalReleaseComObject(workbook);
            workbook = null;
            workbooks.Close();
            Marshal.FinalReleaseComObject(workbooks);
            workbooks = null;
            app.Quit();
            Marshal.FinalReleaseComObject(app);
            app = null;
        }

        public int getRowCount(string sheetName)
        {
            openExcelFile();

            int rowCount = 0;
            int sheetValue = 0;
            if (sheets.Contains(sheetName))
            {
                foreach(DictionaryEntry sheet in sheets)
                {
                    if (sheet.Value.Equals(sheetName))
                    {
                        sheetValue = (int)sheet.Key;
                    }
                }
                XL.Worksheet worksheet = workbook.Worksheets[sheetName] as XL.Worksheet;
                XL.Range range = worksheet.UsedRange;
                rowCount = range.Rows.Count;
            }

            closeExcel();
            return rowCount;
        }
    }
}
