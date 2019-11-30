using System;
using System.Collections.Generic;
using System.Text;

namespace gui
{
    interface IEstimationMethod
    {
        Func<double, double> Estimate(double[] x, double[] y); 
    }
}
