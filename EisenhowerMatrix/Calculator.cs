using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EisenhowerMatrix 
{
    class Calculator: Settings
    {
        public int Years;
        public int Days;
        public int Hours;

        public void GiveOddTime(int age)
        {
            // Variable averageyear is inheritance from class Settings
            Years = averageyear - age;

            Days = Years * 365;
            Hours = Days * 24;

            MessageBox.Show("On average, you will live yet "
                + Years.ToString() + " years. This is "
                + Days.ToString() + " days. This is "
                + Hours.ToString() + " hours."
                , "You odd years");
        }

    }
}
