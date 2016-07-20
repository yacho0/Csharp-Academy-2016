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
        public Collection<ObservableCollection<Quarter>> MultiTaskList { get; set; }
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
            MultiTaskList = new Collection<ObservableCollection<Quarter>>();
            this.settings = new Settings();

            this.NumberComboBox.ItemsSource = NumberList;
            this.NumberComboBox.SelectedIndex = 0;


            this.FOTComboBox.ItemsSource = Enum.GetValues(typeof(FeaturesOfTask));
            this.FOTComboBox.SelectedIndex = 0;

            this.AgeTextBox.DataContext = settings;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            int numberstask = 0;
            string buftask = this.TaskTextBox.Text;
            
            //Avoid problem with write string like int by exception
            try
            {
                numberstask = Int32.Parse(this.TaskTextBox.Text);
            }
            catch (Exception ex)
            {
                //Avoid warning about dont use "ex"
                ex = new Exception();
            }
            
            FeaturesOfTask featureoftask = (FeaturesOfTask)Enum.Parse(typeof(FeaturesOfTask), this.FOTComboBox.Text);
            Quarter tmp = new Quarter(buftask, featureoftask);

            if (numberstask > 0)
            {
                Quarter tmp2 = new Quarter(numberstask, featureoftask);
            }


            int numberofquart = int.Parse(NumberComboBox.Text);

            switch (numberofquart)
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
            try
            {
                this.TaskList1.RemoveAt(this.ListView1.SelectedIndex);
            }
            catch (Exception ex)
            {
                //Avoid warning about dont use "ex"
                ex = new Exception();
            }

            try
            {
                this.TaskList2.RemoveAt(this.ListView2.SelectedIndex);
            }
            catch (Exception ex)
            {
                ex = new Exception();
            }


            try
            {
                this.TaskList3.RemoveAt(this.ListView3.SelectedIndex);
            }
            catch (Exception ex)
            {
                ex = new Exception();
            }

            try
            {
                this.TaskList4.RemoveAt(this.ListView4.SelectedIndex);
            }
            catch (Exception ex)
            {
                ex = new Exception();
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


        private void YearsButton_Click(object sender, RoutedEventArgs e)
        {
            Calculator CalculatorObject = new Calculator();

            CalculatorObject.GiveOddTime(settings.Age);

        }

        private void GreenButton_Click(object sender, RoutedEventArgs e)
        {
            this.Background = Brushes.Green;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "Matrix"; // Default file name
            dlg.DefaultExt = ".xml";
            dlg.Filter = "XML documents (.xml)|*.xml";

            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                string filePath = dlg.FileName;

                ListToXmlFile(filePath);
            }
        }

        private void ListToXmlFile(string filePath)
        {
            MultiTaskList.Clear();
            MultiTaskList.Add(TaskList1);
            MultiTaskList.Add(TaskList2);
            MultiTaskList.Add(TaskList3);
            MultiTaskList.Add(TaskList4);


            using (var sw = new StreamWriter(filePath))
            {
                var serializer = new XmlSerializer(typeof(Collection<ObservableCollection<Quarter>>));
                serializer.Serialize(sw, MultiTaskList);
            }

            //Without clr is problem because number of items in collection increase too much.
            this.MultiTaskList.Clear();
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".xml";
            dlg.Filter = "XML documents (.xml)|*.xml";

            Nullable<bool> result = dlg.ShowDialog();
            string filename = "";
            if (result == true)
            {
                filename = dlg.FileName;
            }

            if (File.Exists(filename))
            {
                XmlFileToList(filename);
            }
            else
            {
                MessageBox.Show(@"Such file doesn't exist");
            }
        }

        public ObservableCollection<Quarter> BufTaskList { get; set; }
        public Quarter BufTask { get; set; }


        private void XmlFileToList(string filename)
        {
            MultiTaskList.Clear();
            TaskList1.Clear();
            TaskList2.Clear();
            TaskList3.Clear();
            TaskList4.Clear();


            using (var sr = new StreamReader(filename))
            {
                // 1,2,3,4 quarts add to MulitTaskList
                var deserializer = new XmlSerializer(typeof(Collection<ObservableCollection<Quarter>>));
                Collection<ObservableCollection<Quarter>> tmpList = (Collection<ObservableCollection<Quarter>>)deserializer.Deserialize(sr);
                foreach (var item in tmpList)
                {
                    MultiTaskList.Add(item);
                }
            }

            BufTaskList = new ObservableCollection<Quarter>();
            BufTask = new Quarter();

            int i = 0;
            BufTaskList = MultiTaskList.ElementAt(0);
            foreach (var item in BufTaskList)
            {
                BufTask = BufTaskList.ElementAt(i);
                TaskList1.Add(BufTask);
                i++;
            }

            BufTaskList = MultiTaskList.ElementAt(1);
            i = 0;
            foreach (var item in BufTaskList)
            {
                BufTask = BufTaskList.ElementAt(i);
                TaskList2.Add(BufTask);
                i++;
            }

            BufTaskList = MultiTaskList.ElementAt(2);
            i = 0;
            foreach (var item in BufTaskList)
            {
                BufTask = BufTaskList.ElementAt(i);
                TaskList3.Add(BufTask);
                i++;
            }
            BufTaskList = MultiTaskList.ElementAt(3);
            i = 0;
            foreach (var item in BufTaskList)
            {
                BufTask = BufTaskList.ElementAt(i);
                TaskList4.Add(BufTask);
                i++;
            }

        }
    }
}
