using System;
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
    /// WindowDriftRate.xaml 的交互逻辑
    /// </summary>
    public partial class WindowDriftRate : Window, INotifyPropertyChanged
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

        private int days;
        public int Days
        {
            get
            {
                return days;
            }
            set
            {
                days = value;
                Changed("Days");
            }
        }

        private string frequency;
        public string Frequency
        {
            get
            {
                return frequency;
            }
            set
            {
                frequency = value;
                Changed("Frequency");
            }
        }

        public WindowDriftRate(int day = 1)
        {
            InitializeComponent();
            this.Days = day;
            this.DataContext = this;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Now = Common.GetTime();
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            string msg;
            bool result = Common.CheckValue(LblFrequency.Content.ToString(), Frequency, out msg);
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
