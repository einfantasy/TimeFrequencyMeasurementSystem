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
    /// BurnInRateForm.xaml 的交互逻辑
    /// </summary>
    public partial class BurnInRateForm : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void Changed(string PropertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }

        public ObservableCollection<MeasurementBurnInRateParam> LstBurnInRateParam
        {
            get
            {
                return MeasurementData.LstBurnInRateParam;
            }
            set
            {
                MeasurementData.LstBurnInRateParam = value;
                Changed("LstBurnInRateParam");
            }
        }


        private DateTime timeBurnInRate;

        public BurnInRateForm()
        {
            InitializeComponent();
            LstBurnInRateParam = new ObservableCollection<MeasurementBurnInRateParam>();
            this.DataContext = this;
        }

        private void ItmBurnInRateRemove_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridBurnInRate.SelectedIndex != -1)
            {
                MeasurementBurnInRateParam mbir = LstBurnInRateParam[dataGridBurnInRate.SelectedIndex];
                LstBurnInRateParam.Remove(mbir);
            }
        }

        private void BtnCalculate2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MeasurementBurnInRate mbir = new MeasurementBurnInRate(LstBurnInRateParam.ToList());
                System.Windows.MessageBox.Show(string.Format("日老化率：{0}", mbir.BurnInRate));
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }

        private void BtnAddRecord8_Click(object sender, RoutedEventArgs e)
        {
            int count = 1;
            if (LstBurnInRateParam.Count != 0)
            {
                count = Convert.ToInt32(LstBurnInRateParam.Last().Index);
                DateTime temp = DateTime.Now;
                if ((temp - timeBurnInRate).TotalHours >= 24)
                    count++;
            }

            timeBurnInRate = DateTime.Now;
            WindowBurnInRate windowBIR = new WindowBurnInRate(count);
            if (windowBIR.ShowDialog() == true)
            {
                MeasurementBase measurement = new MeasurementBurnInRateParam(windowBIR.Now, windowBIR.Count.ToString(), windowBIR.Frequency);
                LstBurnInRateParam.Add((MeasurementBurnInRateParam)measurement);
            }
        }

    }
}
