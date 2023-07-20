using Clever_Dynamics.Filter;
using Clever_Dynamics_Business_layer;
using Clever_Dynamics_Repository;
using Clever_Dynamics_Repository.Models;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using System.Linq.Expressions;

namespace Clever_Dynamics.Controllers
{
    // [AuthLogin]
    public class ProductionController : Controller
    {
        private OrderProcess orderProcess;
        private BaseRepository _repository;


        public ProductionController(BaseRepository baseRepository)
        {

            _repository = baseRepository;

            orderProcess = new OrderProcess(_repository);
        }

        [Route("/Production")]
        public IActionResult Index()
        {
            return View();
        }


        [Route("/Production/FindJob")]
        [HttpPost]
        public IActionResult FindJob(int id)
        {

            var order = orderProcess.FindOrder(id);

            if (order == null)
            {
                return Json(new { jobname = "", detail = "", time = "", id = 0, error = true });
            }

            return Json(new { jobname = order._Job.Name, detail = order._Job.Description, time = order._Job.DateTime, id = order._Job.Id , error = false });

        }


        [Route("/Production/SubmitJob")]
        [HttpPost]
        public IActionResult SubmitJobTime(int orderId, string time, string workdone)
        {

            orderProcess.SaveJobInfo(orderId, time, workdone);

            return Json(new { ok = true});
        }

    }
}
