using Clever_Dynamics.Models;
using Clever_Dynamics_Business_layer;
using Clever_Dynamics_Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Clever_Dynamics.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly OperatorsProcess _operatorsProcess;

        private readonly BaseRepository _baseRepository;

        public HomeController(ILogger<HomeController> logger, BaseRepository baseRepository)
        {
            _logger = logger;
            _baseRepository = baseRepository;
            _operatorsProcess = new OperatorsProcess(baseRepository, HttpContext);

        }

        public IActionResult Index()
        {

            LoginViewModel vm = new LoginViewModel();

            return View(vm);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(LoginViewModel model)
        {

            if(ModelState.IsValid)
            {
                //check user
                //

                if(_operatorsProcess.VariationSignIn(model.Username))
                {
                    _operatorsProcess.SignIn(HttpContext);

                    return Redirect("/Production");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
                }
            }

            return View(model);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}