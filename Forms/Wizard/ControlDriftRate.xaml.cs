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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TimeFrequencyMeasurementSystem.Data;
using TimeFrequencyMeasurementSystem.Structs;

namespace TimeFrequencyMeasurementSystem.Forms.Wizard
{
    /// <summary>
    /// ControlDriftRate.xaml 的交互逻辑
    /// </summary>
    public partial class ControlDriftRate : ControlBase, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void Changed(string PropertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }

        private string driftRate;
        public string DriftRate
        {
            get
            {
                return driftRate;
            }
            set
            {
                driftRate = value;
                Changed("DriftRate");
            }
        }

        public ControlDriftRate()
        {
            InitializeComponent();
            try
            {
                MeasurementDriftRate mdr = new MeasurementDriftRate(MeasurementData.LstDriftRateParam.ToList());
                DriftRate = string.Format("{0}%", mdr.DriftRate);
            }
            catch (Exception)
            {
                DriftRate = "N/A";
            }

            this.DataContext = this;
        }
    }
}
