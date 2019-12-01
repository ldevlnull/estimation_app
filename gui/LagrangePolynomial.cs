using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace gui
{
    class LagrangePolynomial : IEstimationMethod
    {
        public Func<double, double> Estimate(double[] x, double[] y)
        {
            return X =>
            {
                double result = 0;
                for (int i = 0; i < x.Length; i++)
                {
                    result += y[i] * BernsteinPolynomial(x, X, i);
                }
                return result;
            };
        }

        private double BernsteinPolynomial(double[] x, double X, int i)
        {
            double product = 1;
            for(int j = 0; j < x.Length; j++)
            {
                if(j != i)
                {
                    product *= (X - x[j]) / (x[i] - x[j]);
                }
            }
            return product;
        }

    }
}
