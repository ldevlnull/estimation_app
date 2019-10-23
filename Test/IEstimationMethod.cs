using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    interface IEstimationMethod
    {
        public Func<double, double> estimate(double[] x, double[] y); 
    }
}
