using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Integral.Classes
{
    internal class RectangleCalculator : ICalculator
    {
        public double Intagrate(double a, double b, int count, Func<double, double> F)
        {
            double h = (b - a) / count;
            double S = 0;

            for (int i = 0; i < count; i++)
                S += F(a + h * i);

            return h * S;
        }
    }
}
