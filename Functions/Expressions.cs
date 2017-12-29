using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeFrequencyMeasurementSystem.Functions
{
    public static class Expressions
    {
        /// <summary>
        /// 计算开机特性
        /// </summary>
        /// <param name="fta">开机频率</param>
        /// <param name="ftw">稳定频率</param>
        /// <param name="f0">标称频率</param>
        /// <returns>开机特性</returns>
        public static double BootFeature(double fta, double ftw, double f0)
        {
            double V = Math.Abs((fta - ftw) / f0);
            return V;
        }

        /// <summary>
        /// 计算频率准确度
        /// </summary>
        /// <param name="f0">频率标称值</param>
        /// <param name="fx">频率实际值</param>
        /// <returns>准确度</returns>
        public static double FrequencyAccuracy(double f0, double fx)
        {
            double A = (f0 - fx) / fx;
            return A;
        }

        /// <summary>
        /// 计算频率复现性
        /// </summary>
        /// <param name="f1">f1</param>
        /// <param name="f2">f2</param>
        /// <param name="f0">f0</param>
        /// <returns>复现性</returns>
        public static double Reproducibility(double f1, double f2, double f0)
        {
            double R = Math.Abs((f2 - f1) / f0);
            return R;
        }
    }
}
