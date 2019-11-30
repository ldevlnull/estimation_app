using System;
using System.Collections.Generic;
using System.Text;

namespace gui
{
    class Square : IEstimationMethod
    {
        public Func<double, double> Estimate(double[] x, double[] y)
        {
            return (z) => z*z;
        }
    }
}
