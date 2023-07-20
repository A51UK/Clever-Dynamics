using Clever_Dynamics_Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Sockets;
using System.Dynamic;
using System.Net;
using Clever_Dynamics_Repository.Models.OperatorModel;
using Clever_Dynamics_Repository.Models.ProductionOrder;

namespace Clever_Dynamics_Repository
{
    public class MockRepository : BaseRepository
    {

        public MockRepository() {

            base._address = System.AppDomain.CurrentDomain.BaseDirectory;
        }

        private string GetOperatorEndPoint = "\\MockJson\\GetOperator.Json";
        private string GetProductionOrderEndPoint = "\\MockJson\\GetProductionOrder.Json";
        private string SendProductionOrderEndPoint = "\\MockJson\\SendProductionOrder.Json";

        private string LoadFile(string path) => System.IO.File.ReadAllText(path);

        private void SaveFile(string path, string data) => System.IO.File.WriteAllText(path, data);


        public override OperatorModel GetOperator(string username)
        {

            var data = LoadFile(base._address + GetOperatorEndPoint);

            if (!string.IsNullOrEmpty(data))
            {
                var root = JsonConvert.DeserializeObject<Clever_Dynamics_Repository.Models.OperatorModel.Root>(data);
                

                if (root == null)
                {
                    return null;
                }

                return root.OperatorModel.Where(x => x.OperatorName == username).FirstOrDefault();
            }
            else
            {
                throw new Exception("Load Get Operator file failed ");
            }
        }


        public override List<ProductionOrderModel> GetProductionOrderList()
        {
            var data = LoadFile(base._address + GetProductionOrderEndPoint);

            if (!string.IsNullOrEmpty(data))
            {
                var productionOrderRoot = JsonConvert.DeserializeObject<Clever_Dynamics_Repository.Models.ProductionOrder.Root>(data);

                return productionOrderRoot.ProductionOrderModel.ToList();
            }
            else
            {
                throw new Exception("Load Get Operator file failed ");
            }


        }
        public override ProductionOrderModel GetProductionOrder(int number)
        {

            var productionOrderList = GetProductionOrderList();


            if (productionOrderList == null)
            {
                return null;
            }

            return productionOrderList.Where(x => x.Id == number).FirstOrDefault();

        }

        public override void SendProductionOrder(ProductionOrderModel productionOrder)
        {
            var productionOrderList = GetProductionOrderList();

            var removeOrder = productionOrderList.Find(x => x.Id == productionOrder.Id);

            productionOrderList.Remove(removeOrder);

            productionOrderList.Add(productionOrder); ;

            string data = JsonConvert.SerializeObject(productionOrderList);

            SaveFile(base._address + SendProductionOrderEndPoint, data);
        }
    }
}
