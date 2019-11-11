using System;

namespace Test
{
    class NewtonInterpolation : IEstimationMethod
    {
        private double[] X;
        private double[] Y;

        public Func<double, double> estimate(double[] x, double[] y)
        {
            X = x;
            Y = y;
            return z => IntegralPolynomial(z);
        }

        private double Wkx(int k, double x)
        {
            double result = 1;
            for (int i = 0; i <= k; i++)
                result *= (x - X[i]);
            return result;
        }

        private double DivededDifference(int k)
        {
            double result = 0;
            for (int i = 0; i <= k; i++)
            {
                double dob = 1;
                for (int j = 0; j <= k; j++)
                    if (j != i)
                        dob *= (X[i] - X[j]);
                result += Y[i] / dob;
            }
            return result;
        }

        private double IntegralPolynomial(double x)
        {
            double result = Y[0];
            for (int k = 1; k < X.Length; k++)
                result += Wkx(k - 1, x) * DivededDifference(k);
            return result;
        }

    }
}
