using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    class Square : IEstimationMethod
    {
        public Func<double, double> estimate(double[] x, double[] y)
        {
            return x => x*x;
        }
    }
}
