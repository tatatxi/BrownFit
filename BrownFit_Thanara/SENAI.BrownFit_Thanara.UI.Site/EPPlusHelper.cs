using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace SENAI.BrownFit_Thanara.UI.Site
{
    public static class EPPlusHelper
    {
        public static void AdicionarColunas(ExcelWorksheet worksheet, List<string> lstColunas)
        {
            var rowIndex = 1;
            var columnIndex = 1;
            foreach (string tituloColuna in lstColunas)
            {
                worksheet.Cells[rowIndex, columnIndex].Value = tituloColuna;
                worksheet.Cells[rowIndex, columnIndex].Style.Font.Bold = true;
                worksheet.Cells[rowIndex, columnIndex].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                worksheet.Cells[rowIndex, columnIndex].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells[rowIndex, columnIndex].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet.Cells[rowIndex, columnIndex].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(191, 191, 191));
                worksheet.Cells[rowIndex, columnIndex].Style.Font.Color.SetColor(Color.Black);
                worksheet.Cells[rowIndex, columnIndex].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[rowIndex, columnIndex].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[rowIndex, columnIndex].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[rowIndex, columnIndex].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                columnIndex++;
            }
            rowIndex++;
        }

        public static void AdicionarLinha(ExcelWorksheet worksheet, int rowIndex, params string[] valoresCampos)
        {
            var columnIndex = 1;
            foreach (var valorCampo in valoresCampos)
            {
                worksheet.Cells[rowIndex, columnIndex].Value = valorCampo;
                SetRowStyle(worksheet, rowIndex, columnIndex);
                columnIndex++;
            }
        }

        private static void SetRowStyle(ExcelWorksheet worksheet, int rowIndex, int columnIndex)
        {
            worksheet.Cells[rowIndex, columnIndex].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            worksheet.Cells[rowIndex, columnIndex].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            worksheet.Cells[rowIndex, columnIndex].Style.Border.Left.Style = ExcelBorderStyle.Thin;
            worksheet.Cells[rowIndex, columnIndex].Style.Border.Top.Style = ExcelBorderStyle.Thin;
            worksheet.Cells[rowIndex, columnIndex].Style.Border.Right.Style = ExcelBorderStyle.Thin;
            worksheet.Cells[rowIndex, columnIndex].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
        }
    }
}