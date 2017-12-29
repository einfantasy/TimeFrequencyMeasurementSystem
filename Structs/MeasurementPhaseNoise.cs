using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace TimeFrequencyMeasurementSystem.Structs
{
    public class MeasurementPhaseNoise : MeasurementBase, INotifyPropertyChanged
    {
        #region 属性更改通知
        public new event PropertyChangedEventHandler PropertyChanged;
        private void Changed(string PropertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }
        #endregion

        public string FrequencyOffset { get; set; }
        public string Noise { get; set; }

        public MeasurementPhaseNoise(string now, string frequencyOffset, string noise) : base(now)
        {
            this.FrequencyOffset = frequencyOffset;
            this.Noise = noise;
        }
    }
}
