using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeFrequencyMeasurementSystem.Functions
{
    /// <summary>
    /// 最小二乘法
    /// </summary>
    public class LeastSquare
    {
        /// <summary>
        /// 求一点到已知直线的距离
        /// </summary>
        /// <param name="x0">已知点x坐标</param>
        /// <param name="y0">已知点y坐标</param>
        /// <param name="a">直线方程系数a</param>
        /// <param name="b">直线方程系数b</param>
        /// <returns></returns>
        public static double LinearDistance(double x0, double y0, double a, double b)
        {
            double result = 0;
            result = (a * x0 - y0 + b) / Math.Sqrt(a * a + 1);
            return result;
        }

        /// <summary>
        /// 根据已知点求斜率与偏移量
        /// </summary>
        /// <param name="arrayX">x的集合</param>
        /// <param name="arrayY">y的集合</param>
        /// <returns>result[0]:斜率 result[1]:偏移量</returns>
        public static double[] LinearResult(double[] arrayX, double[] arrayY)
        {
            double[] result = { 0, 0 };

            if (arrayX.Length == arrayY.Length)
            {
                double averX = arrayX.Average();
                double averY = arrayY.Average();
                result[0] = Scale(averX, averY, arrayX, arrayY);
                result[1] = Offset(result[0], averX, averY);
            }

            return result;
        }

        private static double Scale(double averX, double averY, double[] arrayX, double[] arrayY)
        {
            double scale = 0;
            if (arrayX.Length == arrayY.Length)
            {
                double Molecular = 0;
                double Denominator = 0;
                for (int i = 0; i < arrayX.Length; i++)
                {
                    Molecular += (arrayX[i] - averX) * (arrayY[i] - averY);
                    Denominator += Math.Pow((arrayX[i] - averX), 2);
                }
                scale = Molecular / Denominator;
            }

            return scale;
        }

        private static double Offset(double scale, double averX, double averY)
        {
            double offset = 0;
            offset = averY - scale * averX;
            return offset;
        }
    }
}
