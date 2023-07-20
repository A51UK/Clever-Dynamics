using Clever_Dynamics_Repository;
using Clever_Dynamics_Repository.Models;
using Clever_Dynamics_Repository.Models.ProductionOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Clever_Dynamics_Business_layer
{
    public class OrderProcess
    {
        private BaseRepository _baseRepository;

        public OrderProcess(BaseRepository baseRepository)
        {
            _baseRepository = baseRepository;
        }


        public ProductionOrderModel FindOrder(int orderId)
        {
            return _baseRepository.GetProductionOrder(orderId);
        }


        public void SaveJobInfo(int orderId, string time, string workdone)
        {
            var order = FindOrder(orderId);

            order._Job.DateTime = time;
            order._Job.WorkDone = workdone;

            _baseRepository.SendProductionOrder(order);

        }

    }
}
