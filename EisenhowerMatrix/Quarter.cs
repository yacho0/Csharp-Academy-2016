using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EisenhowerMatrix
{
    
    public enum FeaturesOfTask { personal, work}

    public class Quarter
    {
        public string Task { get; set; }
        public FeaturesOfTask FeatureOfTask { get; set; }

        public Quarter (string task, FeaturesOfTask featureoftask)
        {
            this.Task = task;
            // i thign better to use in Task class
            this.FeatureOfTask = featureoftask;   
        }

        // Using polymorphism
        public Quarter (int task, FeaturesOfTask featureoftask)
        {
            MessageBox.Show("You have entered the same number", "Warning");
        }
    }
}
