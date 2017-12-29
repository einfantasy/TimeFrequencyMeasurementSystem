using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace TimeFrequencyMeasurementSystem.Structs
{
    public class MeasurementBase : INotifyPropertyChanged
    {
        #region 属性更改通知
        public event PropertyChangedEventHandler PropertyChanged;
        private void Changed(string PropertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }
        #endregion

        public string Now { get; set; }

        public MeasurementBase(string now)
        {
            this.Now = now;
        }
    }
}
