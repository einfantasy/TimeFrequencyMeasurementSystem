using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using TimeFrequencyMeasurementSystem.Functions;

namespace TimeFrequencyMeasurementSystem.Structs
{
    public class MeasurementBootFeature : MeasurementBase, INotifyPropertyChanged
    {
        #region 属性更改通知
        public new event PropertyChangedEventHandler PropertyChanged;
        private void Changed(string PropertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }
        #endregion

        public string FrequencyBoot { get; set; }
        public string FrequencyStable { get; set; }
        public string FrequencyStandard { get; set; }
        public string BootFeature { get; set; }

        public MeasurementBootFeature(string now, string frequencyBoot, string frequencyStable, string frequencyStandard) : base(now)
        {
            this.FrequencyBoot = frequencyBoot;
            this.FrequencyStable = frequencyStable;
            this.FrequencyStandard = frequencyStandard;
            double fta = Convert.ToDouble(this.FrequencyBoot);
            double ftw = Convert.ToDouble(this.FrequencyStable);
            double f0 = Convert.ToDouble(this.FrequencyStandard);
            this.BootFeature = Expressions.BootFeature(fta, ftw, f0).ToString();
        }
    }
}
