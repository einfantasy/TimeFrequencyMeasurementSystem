using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeFrequencyMeasurementSystem.Functions
{
    public static class Common
    {
        /// <summary>
        /// 获取时间戳
        /// </summary>
        /// <returns></returns>
        public static string GetTime()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        /// <summary>
        /// 检查合法性
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool CheckValue(string name, string value, out string message)
        {
            message = string.Empty;
            if (value == string.Empty || value == "" || value == null)
            {
                message = string.Format("{0}不应为空", name);
            }
            else
            {
                try
                {
                    double temp = Convert.ToDouble(value);
                }
                catch
                {
                    message =  string.Format("{0}应为数字", name);
                }
            }

            if (message.Length > 0)
                return false;
            else
                return true;
        }
    }
}
