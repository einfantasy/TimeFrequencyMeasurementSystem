using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using TimeFrequencyMeasurementSystem.Functions;

namespace TimeFrequencyMeasurementSystem.Structs
{
    public class MeasurementBurnInRate : MeasurementBase, INotifyPropertyChanged
    {
        #region 属性更改通知
        public new event PropertyChangedEventHandler PropertyChanged;
        private void Changed(string PropertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }
        #endregion

        private List<MeasurementBurnInRateParam> lstBurnInRateParam
        {
            set;
            get;
        }

        private string burnInRate;
        public string BurnInRate
        {
            get
            {
                return burnInRate;
            }
            set
            {
                burnInRate = value;
                Changed("BurnInRate");
            }
        }

        public MeasurementBurnInRate(List<MeasurementBurnInRateParam> lstBurnInParam) : base(Common.GetTime())
        {
            lstBurnInRateParam = lstBurnInParam;
            GetBurnInRate();
        }

        private double GetBurnInRate()
        {
            lstBurnInRateParam = lstBurnInRateParam.OrderBy(a => a.Index).ToList();
            var index = lstBurnInRateParam.Select(a => a.Index).Distinct().ToArray();
            if (index.Length != 15)
            {
                throw new ArgumentException("需要15组测量数据，请检查");
            }
            else
            {
                double[] values = new double[index.Length];
                double tempAverage = 0;
                int i = 1;
                int count = 0;
                foreach (var item in lstBurnInRateParam)
                {
                    if (item.Index != i)
                    {
                        values[i - 1] = tempAverage / count;
                        count = 0;
                        i = Convert.ToInt32(item.Index);
                        tempAverage = 0;
                    }

                    tempAverage += item.Value;
                    count++;
                }

                double rate = Math.Round(LeastSquare.LinearResult(index, values)[0] * 200, 2);
                BurnInRate = rate.ToString();
                return rate;
            }
        }
    }
}
