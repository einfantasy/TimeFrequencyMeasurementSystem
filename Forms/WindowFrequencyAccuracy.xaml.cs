﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TimeFrequencyMeasurementSystem.Functions;

namespace TimeFrequencyMeasurementSystem.Forms
{
    /// <summary>
    /// WindowFrequencyAccuracy.xaml 的交互逻辑
    /// </summary>
    public partial class WindowFrequencyAccuracy : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void Changed(string PropertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }

        private string now;
        public string Now
        {
            get
            {
                return now;
            }
            set
            {
                now = value;
                Changed("Now");
            }
        }

        private int frequencyStandard;
        public int FrequencyStandard
        {
            get
            {
                return frequencyStandard;
            }
            set
            {
                frequencyStandard = value;
                Changed("FrequencyStandard");
            }
        }

        private string frequencyActual;
        public string FrequencyActual
        {
            get
            {
                return frequencyActual;
            }
            set
            {
                frequencyActual = value;
                Changed("FrequencyActual");
            }
        }

        public WindowFrequencyAccuracy()
        {
            InitializeComponent();
            FrequencyStandard = 10;
            this.DataContext = this;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Now = Common.GetTime();
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            string msg;
            bool result = Common.CheckValue(LblFrequencyActual.Content.ToString(), FrequencyActual, out msg);
            if (result != true)
            {
                MessageBox.Show(msg);
            }
            else
            {
                this.DialogResult = true;
                this.Close();
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
