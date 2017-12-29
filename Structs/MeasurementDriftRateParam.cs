using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace TimeFrequencyMeasurementSystem.Structs
{
    public class MeasurementDriftRateParam : MeasurementBase, INotifyPropertyChanged
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
                return Convert.ToDouble(Days);
            }
        }

        public double Value
        {
            get
            {
                return Convert.ToDouble(Frequency);
            }
        }

        private string days;
        public string Days
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

        public MeasurementDriftRateParam(string now, string days, string frequency) : base(now)
        {
            Days = days;
            Frequency = frequency;
        }
    }
}
