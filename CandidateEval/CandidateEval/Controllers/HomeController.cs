using CandidateEval.Models;
using CandidateEval.ViewModels.Home;
using System.Web.Mvc;

namespace CandidateEval.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewSupervisees()
        {
            var viewModel = new ViewSuperviseesViewModel
            {
                Supervisees = Supervisee.GetList()
            };

            return View(viewModel);
        }
    }
}