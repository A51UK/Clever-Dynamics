using Clever_Dynamics_Repository.Models;
using Clever_Dynamics_Repository.Models.OperatorModel;
using Clever_Dynamics_Repository.Models.ProductionOrder;

namespace Clever_Dynamics_Repository
{
    public abstract class BaseRepository
    {

        public string _address { get; set; } 

        public abstract OperatorModel GetOperator(string username);
        public abstract ProductionOrderModel GetProductionOrder(int number);

        public abstract List<ProductionOrderModel> GetProductionOrderList();

        public abstract void SendProductionOrder(ProductionOrderModel productionOrder);

        public abstract void SendOrderJobStarted(ProductionOrderModel productionOrder);
    }
}