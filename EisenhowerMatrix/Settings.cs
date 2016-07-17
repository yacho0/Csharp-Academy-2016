using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EisenhowerMatrix
{
    public class Settings: INotifyPropertyChanged
    {
        private int age = 26;

        public int Age
        {
            get { return this.age; }
            set
            {
                if(this.age != value)
                {
                    this.age = value;
                    //info to user interface
                    this.NotifyPropertyChanged("Age");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged (string tmp)
        {
            if(this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(tmp));
            }

        }

    }
}
