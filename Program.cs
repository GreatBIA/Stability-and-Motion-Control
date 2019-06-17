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
            return (Math.Cos(fi * Math.PI / 180));
        }

        public static double L2(double fi)
        {
            return (Math.Sin(fi * Math.PI / 180));
        }

        public static double L(double fi, double x1, double x2, double x3, double x4, double y1, double y2, double T)
        {
            return (L1(fi) * (x1 + T * x3 - y1) + L2(fi) * (x2 + T * x4 - y2));
        }

        public static double Ladditional(double fi, double T)
        {
            return ((L1(fi) + L2(fi)) * Math.Pow(T, 2) / 2.0);
        }


        public static double Max(double x1, double x2, double x3, double x4, double y1, double y2, double T, double a)
        {
            List<double> MaxList = new List<double>();
            MaxList.Add(0.0);
            for (double fi = 0; fi <= 360; fi++)
            {
                if (Ladditional(fi, T) >= 0)
                {
                    var max1 = L(fi, x1, x2, x3, x4, y1, y2, T) - a * Ladditional(fi, T);
                    MaxList.Add(max1);
                }
                if (Ladditional(fi, T) < 0)
                {
                    var max2 = L(fi, x1, x2, x3, x4, y1, y2, T) + a * Ladditional(fi, T);
                    MaxList.Add(max2);
                }
            }
            var maxs = MaxList.Max();
            return maxs;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите x1 x2 x3 x4 y1 y2 T a");
            double[] numbers = Array.ConvertAll(Console.ReadLine().Split(), double.Parse);
            var x1 = numbers[0];
            var x2 = numbers[1];
            var x3 = numbers[2];
            var x4 = numbers[3];
            var y1 = numbers[4];
            var y2 = numbers[5];
            var T = numbers[6];
            var a = numbers[7];
            Console.WriteLine(Max(x1, x2, x3, x4, y1, y2, T, a));
        }
    }
}
