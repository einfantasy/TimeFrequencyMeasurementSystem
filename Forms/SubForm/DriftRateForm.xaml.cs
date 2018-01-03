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
    /// DriftRateForm.xaml 的交互逻辑
    /// </summary>
    public partial class DriftRateForm : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void Changed(string PropertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }


        public ObservableCollection<MeasurementDriftRateParam> LstDriftRateParam
        {
            get
            {
                return MeasurementData.LstDriftRateParam;
            }
            set
            {
                MeasurementData.LstDriftRateParam = value;
                Changed("LstDriftRateParam");
            }
        }

        private DateTime timeDriftRate;
        public DriftRateForm()
        {
            InitializeComponent();
            LstDriftRateParam = new ObservableCollection<MeasurementDriftRateParam>();
            this.DataContext = this;
        }

        private void ItmDriftRateRemove_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridDriftRate.SelectedIndex != -1)
            {
                MeasurementDriftRateParam mdr = LstDriftRateParam[dataGridDriftRate.SelectedIndex];
                LstDriftRateParam.Remove(mdr);
            }
        }

        private void BtnCalculate1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MeasurementDriftRate mdr = new MeasurementDriftRate(LstDriftRateParam.ToList());
                System.Windows.MessageBox.Show(string.Format("漂移率：{0}", mdr.DriftRate));
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }


        private void BtnAddRecord7_Click(object sender, RoutedEventArgs e)
        {
            int day = 1;
            if (LstDriftRateParam.Count != 0)
            {
                day = Convert.ToInt32(LstDriftRateParam.Last().Index);
                DateTime temp = DateTime.Now;
                if ((temp - timeDriftRate).TotalHours >= 24)
                    day++;
            }

            timeDriftRate = DateTime.Now;
            WindowDriftRate windowDR = new WindowDriftRate(day);
            if (windowDR.ShowDialog() == true)
            {
                MeasurementBase measurement = new MeasurementDriftRateParam(windowDR.Now, windowDR.Days.ToString(), windowDR.Frequency);
                LstDriftRateParam.Add((MeasurementDriftRateParam)measurement);
            }
        }
    }
}
