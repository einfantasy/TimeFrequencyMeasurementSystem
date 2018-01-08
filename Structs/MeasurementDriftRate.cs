using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using TimeFrequencyMeasurementSystem.Functions;

namespace TimeFrequencyMeasurementSystem.Structs
{
    public class MeasurementDriftRate : MeasurementBase, INotifyPropertyChanged
    {
        #region 属性更改通知
        public new event PropertyChangedEventHandler PropertyChanged;
        private void Changed(string PropertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }
        #endregion

        private List<MeasurementDriftRateParam> lstDriftRateParam
        {
            set;
            get;
        }

        private string driftRate;
        public string DriftRate
        {
            get
            {
                return driftRate;
            }
            set
            {
                driftRate = value;
                Changed("DriftRate");
            }
        }

        public MeasurementDriftRate(List<MeasurementDriftRateParam> lstDriftRateParam) : base(Common.GetTime())
        {
            this.lstDriftRateParam = lstDriftRateParam;
            GetDriftRate();
        }

        private double GetDriftRate()
        {
            lstDriftRateParam = lstDriftRateParam.OrderBy(a => a.Index).ToList();
            var days = lstDriftRateParam.Select(a => a.Index).Distinct().ToArray();
            if (days.Length != 15)
            {
                throw new ArgumentException("需要15组测量数据，请检查");
            }
            else
            {
                double[] values = new double[days.Length];
                double tempAverage = 0;
                int day = 1;
                int count = 0;
                foreach (var item in lstDriftRateParam)
                {
                    if (item.Index != day)
                    {
                        values[day - 1] = tempAverage / count;
                        count = 0;
                        day = Convert.ToInt32(item.Index);
                        tempAverage = 0;
                    }

                    tempAverage += item.Value;
                    count++;
                }

                double rate = Math.Round((LeastSquare.LinearResult(days, values)[0] * 100), 2);
                DriftRate = rate.ToString();
                return rate;
            }
        }
    }
}
