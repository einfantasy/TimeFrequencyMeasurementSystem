using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using TimeFrequencyMeasurementSystem.Functions;

namespace TimeFrequencyMeasurementSystem.Structs
{
    public class MeasurementFrequencyReproducibility : MeasurementBase, INotifyPropertyChanged
    {
        #region 属性更改通知
        public new event PropertyChangedEventHandler PropertyChanged;
        private void Changed(string PropertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }
        #endregion

        public string FrequencyI { get; set; }

        public string FrequencyII { get; set; }

        public string FrequencyStandard { get; set; }

        public string Reproducibility { get; set; }

        public MeasurementFrequencyReproducibility(string now, string frequencyI, string frequencyII, string frequencyStandard) : base(now)
        {
            FrequencyI = frequencyI;
            FrequencyII = frequencyII;
            FrequencyStandard = frequencyStandard;
            double f1 = Convert.ToDouble(FrequencyI);
            double f2 = Convert.ToDouble(FrequencyII);
            double f0 = Convert.ToDouble(FrequencyStandard);
            double R = Expressions.Reproducibility(f1, f2, f0);
            Reproducibility = R.ToString();
        }
    }
}
