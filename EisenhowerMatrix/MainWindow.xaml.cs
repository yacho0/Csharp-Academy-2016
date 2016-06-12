﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace EisenhowerMatrix
{


    public partial class MainWindow : Window
    {
        public ObservableCollection<Helper> TaskList1 { get; set; }
        public ObservableCollection<Helper> TaskList2 { get; set; }
        public ObservableCollection<Helper> TaskList3 { get; set; }
        public ObservableCollection<Helper> TaskList4 { get; set; }
        public Settings settings;

        public int[] NumberList = { 1, 2, 3, 4 };

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;

            TaskList1 = new ObservableCollection<Helper>();
            TaskList2 = new ObservableCollection<Helper>();
            TaskList3 = new ObservableCollection<Helper>();
            TaskList4 = new ObservableCollection<Helper>();
            this.settings = new Settings();


            this.NumberComboBox.ItemsSource = NumberList;
            this.NumberComboBox.SelectedIndex = 0;


            this.FOTComboBox.ItemsSource = Enum.GetValues(typeof(FeaturesOfTask));
            this.FOTComboBox.SelectedIndex = 0;


            // tmp = (Colors)Enum.Parse(typeof(Colors),ColorComboBox.Text);
            //this.Background = Brushes.Blue;


            this.AgeTextBox.DataContext = settings;

        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {


            string taskTemp = this.TaskTextBox.Text;
            FeaturesOfTask featureoftask = (FeaturesOfTask)Enum.Parse(typeof(FeaturesOfTask), this.FOTComboBox.Text);

            Helper tmp = new Helper(taskTemp, featureoftask);

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


    }
}