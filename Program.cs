using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traffic_Control
{
    class Program
    {
        public static double L1(double fi)
        {
            return Math.Cos(fi * Math.PI / 180);
        }
        
        public static double L2(double fi)
        {
            return Math.Sin(fi * Math.PI / 180);
        }

        public static double L(double fi, double x1, double x2, double x3, double x4, double y1, double y2, double T)
        {
            var l = L1(fi) * (x1 + T * x3 - y1) + L2(fi) * (x2 + T * x4 - y2) - L1(fi) * Math.Pow(T, 2) / 2 - L2(fi) * Math.Pow(T, 2) / 2;
            return l;
        }

        public static double Max(double x1, double x2, double x3, double x4, double y1, double y2, double T)
        {
            var max = 0.0;
            for (double fi = 0; fi <= 360; fi++)
            {
                if (L(fi, x1, x2, x3, x4, y1, y2, T) >= max)
                {
                    max = L(fi, x1, x2, x3, x4, y1, y2, T);
                }
            }
            return max;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите x1 x2 x3 x4 y1 y2 T");
            double[] numbers = Array.ConvertAll(Console.ReadLine().Split(), double.Parse);
            var x1 = numbers[0];
            var x2 = numbers[1];
            var x3 = numbers[2];
            var x4 = numbers[3];
            var y1 = numbers[4];
            var y2 = numbers[5];
            var T = numbers[6];
            Console.WriteLine(Max(x1, x2, x3, x4, y1, y2, T));
        }
    }
}
