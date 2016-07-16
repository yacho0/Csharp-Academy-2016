using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace EisenhowerMatrix
{


    public partial class MainWindow : Window
    {
        public ObservableCollection<Quarter> TaskList1 { get; set; }
        public ObservableCollection<Quarter> TaskList2 { get; set; }
        public ObservableCollection<Quarter> TaskList3 { get; set; }
        public ObservableCollection<Quarter> TaskList4 { get; set; }
        public Settings settings;

        public int[] NumberList = { 1, 2, 3, 4 };

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;

            TaskList1 = new ObservableCollection<Quarter>();
            TaskList2 = new ObservableCollection<Quarter>();
            TaskList3 = new ObservableCollection<Quarter>();
            TaskList4 = new ObservableCollection<Quarter>();
            this.settings = new Settings();


            this.NumberComboBox.ItemsSource = NumberList;
            this.NumberComboBox.SelectedIndex = 0;


            this.FOTComboBox.ItemsSource = Enum.GetValues(typeof(FeaturesOfTask));
            this.FOTComboBox.SelectedIndex = 0;


            // tmp = (Colors)Enum.Parse(typeof(Colors),ColorComboBox.Text);

            this.AgeTextBox.DataContext = settings;

        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            int numberstask;
            numberstask = 0;
            
            string taskTemp = this.TaskTextBox.Text;

            try
            {
                numberstask = Int32.Parse(this.TaskTextBox.Text);
            }
            catch (Exception ex)
            {
               
            }
            

            FeaturesOfTask featureoftask = (FeaturesOfTask)Enum.Parse(typeof(FeaturesOfTask), this.FOTComboBox.Text);

            Quarter tmp = new Quarter(taskTemp, featureoftask);

            if (numberstask > 0)
            {
                Quarter tmp2 = new Quarter(numberstask, featureoftask);
            }
            

            int flag = int.Parse(NumberComboBox.Text);

            switch (flag)
            {
                case 1:
                    TaskList1.Add(tmp);
                    break;
                case 2:
                    TaskList2.Add(tmp);
                    break;
                case 3:
                    TaskList3.Add(tmp);
                    break;
                case 4:
                    TaskList4.Add(tmp);
                    break;
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            int flag = int.Parse(NumberComboBox.Text);

            if (flag == 1)
            {
                try
                {
                    this.TaskList1.RemoveAt(this.ListView1.SelectedIndex);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Choose correct numeber of list.", "Delete tasks");
                }
            }

            if (flag == 2)
            {
                try
                {
                    this.TaskList2.RemoveAt(this.ListView2.SelectedIndex);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Choose correct numeber of list.", "Delete tasks");
                }
            }
            if (flag == 3)
            {
                try
                {
                    this.TaskList3.RemoveAt(this.ListView3.SelectedIndex);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Choose correct numeber of list.", "Delete tasks");
                }
            }
            if (flag == 4)
            {
                try
                {
                    this.TaskList4.RemoveAt(this.ListView4.SelectedIndex);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Choose correct numeber of list.", "Delete tasks");
                }
            }

        }
        private void MinusButton_Click(object sender, RoutedEventArgs e)
        {
            settings.Age--;

        }
        private void PlusButton_Click(object sender, RoutedEventArgs e)
        {
            settings.Age++;
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            TaskList1.Clear();
            TaskList2.Clear();
            TaskList3.Clear();
            TaskList4.Clear();
        }

        private void RedButton_Click(object sender, RoutedEventArgs e)
        {
            this.Background = Brushes.Red;
        }

        private void BlueButton_Click(object sender, RoutedEventArgs e)
        {
            this.Background = Brushes.Blue;
        }

        private void WhiteButton_Click(object sender, RoutedEventArgs e)
        {
            this.Background = Brushes.White;
        }
    }
}
