using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using TimeFrequencyMeasurementSystem.Functions;

namespace TimeFrequencyMeasurementSystem.Structs
{
    public class MeasurementFrequencyAccuracy : MeasurementBase, INotifyPropertyChanged
    {
        #region 属性更改通知
        public new event PropertyChangedEventHandler PropertyChanged;
        private void Changed(string PropertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }
        #endregion

        public string FrequencyStandard { get; set; }
        public string FrequencyActual { get; set; }
        public string FrequencyAccuracy { get; set; }

        public MeasurementFrequencyAccuracy(string now, string frequencyStandard, string frequencyActual) : base(now)
        {
            FrequencyActual = frequencyActual;
            FrequencyStandard = frequencyStandard;
            double f0 = Convert.ToDouble(FrequencyStandard);
            double fx = Convert.ToDouble(FrequencyActual);
            FrequencyAccuracy = Expressions.FrequencyAccuracy(f0, fx).ToString();
        }
    }
}
