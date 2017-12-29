using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace TimeFrequencyMeasurementSystem.Structs
{
    public class MeasurementShortTermStability : MeasurementBase, INotifyPropertyChanged
    {
        #region 属性更改通知
        public new event PropertyChangedEventHandler PropertyChanged;
        private void Changed(string PropertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }
        #endregion

        public string Tau { get; set; }
        public string Sigma { get; set; }

        public MeasurementShortTermStability(string now, string tau, string sigma) : base(now)
        {
            this.Tau = tau;
            this.Sigma = sigma;
        }
    }
}
