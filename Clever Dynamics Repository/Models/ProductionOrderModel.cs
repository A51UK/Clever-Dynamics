using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clever_Dynamics_Repository.Models.ProductionOrder
{
    public partial class Root
    {
        [JsonProperty("ProductionOrderModel")]
        public ProductionOrderModel[] ProductionOrderModel { get; set; }
    }

    public partial class ProductionOrderModel
    {
        [JsonProperty("Id")]
        public long Id { get; set; }

        [JsonProperty("Job")]
        public Job _Job { get; set; }
    }

    public partial class Job
    {
        [JsonProperty("Id")]
        public long Id { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("DateTime")]
        public string DateTime { get; set; }

        [JsonProperty("WorkDone")]
        public string WorkDone { get; set; }
    }
}
