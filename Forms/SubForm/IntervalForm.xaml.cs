using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TimeFrequencyMeasurementSystem.Data;
using TimeFrequencyMeasurementSystem.Structs;

namespace TimeFrequencyMeasurementSystem.Forms.SubForm
{
    /// <summary>
    /// IntervalForm.xaml 的交互逻辑
    /// </summary>
    public partial class IntervalForm : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void Changed(string PropertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }

        public ObservableCollection<MeasurementInterval> LstInterval
        {
            get
            {
                return MeasurementData.LstInterval;
            }
            set
            {
                MeasurementData.LstInterval = value;
                Changed("LstInterval");
            }
        }



        public IntervalForm()
        {
            InitializeComponent();

            LstInterval = new ObservableCollection<MeasurementInterval>();
            this.DataContext = this;
        }

        private void ItmIntervalRemove_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridInterval.SelectedIndex != -1)
            {
                MeasurementInterval mi = LstInterval[dataGridInterval.SelectedIndex];
                LstInterval.Remove(mi);
            }
        }

        private void BtnAddRecord9_Click(object sender, RoutedEventArgs e)
        {
            WindowInterval windowI = new WindowInterval();
            if (windowI.ShowDialog() == true)
            {
                MeasurementBase measurement = new MeasurementInterval(windowI.Now, windowI.Average, windowI.StandardDeviation);
                LstInterval.Add((MeasurementInterval)measurement);
            }
        }
    }
}
