using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    class Factorial :IEstimationMethod
    {

        private double[] X;
        private double[] Y;
        private int n { get; set; }

        public Func<double, double> estimate(double[] x, double[] y)
        {
            X = x;
            Y = y;

            return x => FactorialAppr(n, x);
           }

        private double factorial(int k)
        {
            if (k == 0 || k == 1)
            {
                return 1;
            }
            return k * factorial(k - 1);
        }

        private double Cnk(int n, int k)
        {
            return factorial(n) / (factorial(k) * factorial((n - k)));
        }

        private int DegreeNum(int n)
        { 
           return  (n % 2 == 1) ?  -1 :  1;
        }

        private double deltaF(int n)
        {
            double r = 0;
            int k;
            for (k = 0; k <= n; k++)
            {
                r += Y[k] * DegreeNum(n - k) * Cnk(n, k);
            }
            return r;
        }

        private double factMN(double t, int k)
        {
            double mn = 1;
            int i;
            if (k == 0)
            {
                mn = 1;
            }
            else
            {
                for (i = 0; i < k; i++)
                {
                    mn *= (t - i);
                }
            }
            return mn;
        }
        private double FactorialAppr(int n, double t)
        {
            int k;
            double result = 0;
            for (k = 0; k <= n; k++)
            {
                result += deltaF(k) * factMN(t, k) / factorial(k);
            }
            return result;
        }
    }
}
