using CandidateEval.Models;
using System.Web.Mvc;

namespace CandidateEval.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Supervisees = Supervisee.GetList();

            return View();
        }
    }
}