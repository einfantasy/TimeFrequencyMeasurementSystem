using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace TimeFrequencyMeasurementSystem.Structs
{
    public class MeasurementInterval : MeasurementBase, INotifyPropertyChanged
    {
        #region 属性更改通知
        public new event PropertyChangedEventHandler PropertyChanged;
        private void Changed(string PropertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }
        #endregion

        public string Average { get; set; }
        public string StandardDeviation { get; set; }

        public MeasurementInterval(string now, string average, string standardDeviation) : base(now)
        {
            Average = average;
            StandardDeviation = standardDeviation;
        }
    }
}
