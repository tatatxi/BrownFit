using OfficeOpenXml;
using SENAI.BrownFit_Thanara.Data.Context;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SENAI.BrownFit_Thanara.UI.Site.Controllers
{
    public class RelatoriosController : Controller
    {
        private Brown_ThanaraContext db = new Brown_ThanaraContext();

        public ActionResult GerarRelatorio()
        {
            using (ExcelPackage package = new ExcelPackage())
            {
                //1) NOME DO RELATÓRIO
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Relatório Geral");
                worksheet.View.ShowGridLines = false;

                //COMEÇA AQUI A MONTAGEM DO EXCEL
                var rowIndex = 1;

                //2) COLOCAR AS COLUNAS DO RELATÓRIO
                var lstColunas = new List<string>()
                {
                    "Data Aula",
                    "Tipo Aula",
                    "Professor",
                    "Descrição"
                };

                //adicionando cabeçalho do relatório
                EPPlusHelper.AdicionarColunas(worksheet, lstColunas);
                rowIndex++;

                //buscando registros no banco de dados (no caso desse relatório é uma lista de agendas)
                //3) CHAMAR A CLASSE DE ACESSO AO BANCO PARA BUSCAR OS DADOS DA TABELA DESEJADA
                var lst = db.Agendas
                 .Join(
                     db.Aulas,
                     agenda => agenda.Aula.AulaID,
                     aula => aula.AulaID,
                     (agenda, aula) => new { agenda }).Select(x => x.agenda).ToList();

                foreach (var agenda in lst)
                {
                    EPPlusHelper.AdicionarLinha(worksheet, rowIndex, string.Format("{0:dd/MM/yyyy HH:mm}", agenda.DataAula), agenda.Aula.TipoAula, agenda.Professor.Nome, agenda.Descricao);
                    rowIndex++;
                }

                //TERMINA AQUI A MONTAGEM DO EXCEL
                worksheet.Cells.AutoFitColumns(100);
                worksheet.View.ShowHeaders = true;
                worksheet.PrinterSettings.PaperSize = ePaperSize.A4;
                worksheet.PrinterSettings.FitToPage = true;

                if (!Directory.Exists(Server.MapPath("~/Uploads")))
                    Directory.CreateDirectory(Server.MapPath("~/Uploads"));

                var fileName = Path.Combine(Server.MapPath("~/Uploads"), string.Format("{0:ddMMyyyyHHmmss}.xlsx", DateTime.Now));
                var fi = new FileInfo(fileName);
                package.SaveAs(fi);

                return RedirectToAction("Download", "Relatorios", new { fileName = fi.Name });
            }
        }

        public ActionResult Download(string fileName)
        {
            var fullName = Path.Combine(Server.MapPath(string.Format("~/Uploads/{0:yyyyMMdd}", DateTime.Now)), fileName);
            string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            return File(fullName, contentType, fileName);
        }
    }
}