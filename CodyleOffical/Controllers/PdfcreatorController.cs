using DinkToPdf.Contracts;
using DinkToPdf;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CodyleOffical.Utility;

namespace CodyleOffical.Controllers
{
    [Area("User")]

 
    public class PdfcreatorController : Controller
    {
        private IConverter _converter;
        public PdfcreatorController(IConverter converter)
        {
            _converter = converter;
        }
        [HttpGet]
        public IActionResult CreatePDF()
        {
            var globalSettings = new GlobalSettings
            {
                PaperSize = PaperKind.ItalyEnvelope,
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Landscape,
                DocumentTitle = "PDF Report"
            };
            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = TemplateGenerator.GetHTMLString(),
                WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet =
                Path.Combine(Directory.GetCurrentDirectory(),"wwwroot", "assets", "ticket.css") },

            };
            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };
            var file = _converter.Convert(pdf);
            return File(file, "application/pdf", "CodyleEvent.pdf");
        }
    }
}
