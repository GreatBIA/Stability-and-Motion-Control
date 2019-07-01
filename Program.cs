using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trafic_Control
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

        public static double L(double fi, double x1, double x2, double n, double y1, double y2, double a)
        {
            return L1(fi) * (Math.Cos(n) * x1 + Math.Sin(n) * x2 - y1) + L2(fi) * (Math.Cos(n) * x2 - Math.Sin(n) * x1 + y2);
        }

        public static double Ladditional(double fi, double n)
        {
            return (L1(fi) * Math.Sin(n) + L2(fi) * Math.Cos(n));
        }

        public static double Max(double x1, double x2, double n, double y1, double y2, double a)
        {
            List<double> MaxList = new List<double>();
            MaxList.Add(0.0);
            for (double fi = 0; fi <= 360; fi++)
            {
                if (Ladditional(fi, n) >= 0)
                {
                    var max1 = L(fi, x1, x2, n, y1, y2, a) - a * Ladditional(fi, n);
                    MaxList.Add(max1);
                }
                else
                {
                    var max2 = L(fi, x1, x2, n, y1, y2, a) + a * Ladditional(fi, n);
                    MaxList.Add(max2);
                }
            }
            return MaxList.Max();

        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите x1 x2 ню y1 y2 а");
            double[] numbers = Array.ConvertAll(Console.ReadLine().Split(), double.Parse);
            var x1 = numbers[0];
            var x2 = numbers[1];
            var n = numbers[2];
            var y1 = numbers[3];
            var y2 = numbers[4];
            var a = numbers[5];
            Console.WriteLine(Max(x1, x2, n, y1, y2, a));
        }
    }
}