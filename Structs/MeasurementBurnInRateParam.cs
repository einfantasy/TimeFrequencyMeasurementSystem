using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace TimeFrequencyMeasurementSystem.Structs
{
    public class MeasurementBurnInRateParam : MeasurementBase, INotifyPropertyChanged
    {
        #region 属性更改通知
        public new event PropertyChangedEventHandler PropertyChanged;
        private void Changed(string PropertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }
        #endregion

        public double Index
        {
            get
            {
                return Convert.ToDouble(Count);
            }
        }

        public double Value
        {
            get
            {
                return Convert.ToDouble(Frequency);
            }
        }

        private string count;
        public string Count
        {
            get
            {
                return count;
            }
            set
            {
                count = value;
                Changed("Count");
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

        public MeasurementBurnInRateParam(string now, string count, string frequency) : base(now)
        {
            Count = count;
            Frequency = frequency;
        }
    }
}
