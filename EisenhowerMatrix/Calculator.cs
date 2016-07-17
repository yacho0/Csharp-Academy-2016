using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EisenhowerMatrix
{
    class Calculator
    {
        public int Years;
        public int Days;
        public int Hours;

        public void GiveYears(int age)
        {
            Years = 75 - age;

            MessageBox.Show("On average, you will live yet: " + Years.ToString(), "You odd years" );
        }

        public Calculator ()//int years, int days, int hours)     //??
        {
            //this.Years = years;
            //this.Days = days;
            //this.Hours = hours;

        }

    }
}
