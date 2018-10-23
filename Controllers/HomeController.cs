using jsreport.MVC;
using jsreport.Types;
using System.Web.Mvc;

namespace NetWebApp.Controllers
{
    public class HomeController : Controller
    {
        [EnableJsReport]
        public ActionResult Index()
        {
            var jsReportFeature = HttpContext.JsReportFeature()
                .Recipe(Recipe.ChromePdf)
                .Engine(Engine.Handlebars)
                .Configure(r => r.Template.Chrome = new Chrome
                {
                    HeaderTemplate = this.RenderViewToString("Header", new { }),
                    DisplayHeaderFooter = true,
                    MarginTop = "2cm",
                    MarginLeft = "1cm",
                    MarginBottom = "2cm",
                });
            jsReportFeature.RenderRequest.Template.Helpers = @"function getThisJson() {return JSON.stringify(this);};";

            return View("TestPage");
        }
    }
}