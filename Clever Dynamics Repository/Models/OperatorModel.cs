using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clever_Dynamics_Repository.Models.OperatorModel
{
    public class OperatorModel
    {
        public string OperatorName { get; set; }
    }

    public class Root
    {
        public List<OperatorModel> OperatorModel { get; set; }
    }

}
