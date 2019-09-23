using Library.DAL;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Seed
{
    public static class Utility
    {
        public static string readString(this ExcelWorksheet sheet, int row, int col)
        {
            return sheet.Cells[row, col].Value.ToString().Trim();
        }

        public static int readInteger(this ExcelWorksheet sheet, int row, int col)
        {
            return Convert.ToInt32(sheet.Cells[row, col].Value.ToString().Trim());
        }

        public static DateTime readDate(this ExcelWorksheet sheet, int row, int col)
        {
            return Convert.ToDateTime(sheet.Cells[row, col].Value.ToString().Trim());
        }

        public static decimal readDecimal(this ExcelWorksheet sheet, int row, int col)
        {
            return Convert.ToDecimal(sheet.Cells[row, col].Value.ToString().Trim());
        }
    }
}