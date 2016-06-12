using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EisenhowerMatrix
{
    
    public enum FeaturesOfTask { personal, work}

    public class Helper
    {
        public string Task { get; set; }
        public FeaturesOfTask FeatureOfTask { get; set; }

        public Helper (string task, FeaturesOfTask featureoftask)
        {
            this.Task = task;
            this.FeatureOfTask = featureoftask;

        }
    }
}
