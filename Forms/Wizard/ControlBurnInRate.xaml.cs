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
    /// ControlBurnInRate.xaml 的交互逻辑
    /// </summary>
    public partial class ControlBurnInRate : ControlBase, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void Changed(string PropertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }

        private string burnInRate;
        public string BurnInRate
        {
            get
            {
                return burnInRate;
            }
            set
            {
                burnInRate = value;
                Changed("BurnInRate");
            }
        }

        public ControlBurnInRate()
        {
            InitializeComponent();
            try
            {
                MeasurementBurnInRate mbir = new MeasurementBurnInRate(MeasurementData.LstBurnInRateParam.ToList());
                BurnInRate = string.Format("{0}%", mbir.BurnInRate);
            }
            catch (Exception)
            {
                BurnInRate = "N/A";
            }

            this.DataContext = this;
        }
    }
}
