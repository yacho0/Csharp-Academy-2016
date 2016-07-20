﻿using System;
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
        // Quarter[] DeleteTasksList { get; set; }


        public int[] NumberList = { 1, 2, 3, 4 };

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;

            TaskList1 = new ObservableCollection<Quarter>();
            TaskList2 = new ObservableCollection<Quarter>();
            TaskList3 = new ObservableCollection<Quarter>();
            TaskList4 = new ObservableCollection<Quarter>();
            MultiTaskList = new Collection<ObservableCollection<Quarter>>();  //{ TaskList1, TaskList2, TaskList3, TaskList4 }
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

            string taskTemp = this.TaskTextBox.Text;

            try
            {
                numberstask = Int32.Parse(this.TaskTextBox.Text);
            }
            catch (Exception ex)
            {
                //Nothing using
                ex = new Exception();
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

            //int tmp;


            try
            {
                this.TaskList1.RemoveAt(this.ListView1.SelectedIndex);
            }
            catch (Exception ex)
            {
                //Nothing using
                ex = new Exception();
            }

            try
            {
                this.TaskList2.RemoveAt(this.ListView2.SelectedIndex);
            }
            catch (Exception ex)
            {
                //Nothing using
                ex = new Exception();
            }


            try
            {
                this.TaskList3.RemoveAt(this.ListView3.SelectedIndex);
            }
            catch (Exception ex)
            {
                //Nothing using
                ex = new Exception();
            }

            try
            {
                this.TaskList4.RemoveAt(this.ListView4.SelectedIndex);
            }
            catch (Exception ex)
            {
                //Nothing using
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

        public ObservableCollection<Quarter> Tmp { get; set; }
        public Quarter tmp { get; set; }


        private void XmlFileToList(string filename)
        {
            // miało kasować, ale nie kasuje...
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

            //temp form
            Tmp = new ObservableCollection<Quarter>();
            tmp = new Quarter();

            int i = 0;
            Tmp = MultiTaskList.ElementAt(0);
            foreach (var item in Tmp)
            {
                tmp = Tmp.ElementAt(i);
                TaskList1.Add(tmp);
                i++;
            }

            Tmp = MultiTaskList.ElementAt(1);
            i = 0;
            foreach (var item in Tmp)
            {
                tmp = Tmp.ElementAt(i);
                TaskList2.Add(tmp);
                i++;
            }

            Tmp = MultiTaskList.ElementAt(2);
            i = 0;
            foreach (var item in Tmp)
            {
                tmp = Tmp.ElementAt(i);
                TaskList3.Add(tmp);
                i++;
            }
            Tmp = MultiTaskList.ElementAt(3);
            i = 0;
            foreach (var item in Tmp)
            {
                tmp = Tmp.ElementAt(i);
                TaskList4.Add(tmp);
                i++;
            }

        }
    }
}
