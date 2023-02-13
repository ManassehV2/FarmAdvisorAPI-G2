using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmAdvisor.Models.Models
{
    public class ResetSensorDateModel
    {
        public ResetSensorDateModel(DateTime timeStamp)
        {
            TimeStamp = timeStamp;

        }

        public DateTime TimeStamp { get; set; }
    }
}



