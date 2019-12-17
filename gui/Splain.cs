using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gui
{
    class Splain : IEstimationMethod
    {
        double[] h;
        double[] a;
        double[] b;
        double[] c;
        double[] d;
        public Func<double, double> Estimate(double[] x, double[] y)
        {
            int N = x.Length;
            h = new double[N];
            a = new double[N];
            b = new double[N];
            for (int i = 0; i < N - 1; i++)
            {
                h[i] = x[i + 1] - x[i];
            }
            h[N - 1] = h[N - 2];
            c = TridiagonalSolve(y, h);
            d = new double[N];

            for (int i = 1; i < N - 1; i++)
            {
                a[i] = y[i - 1];
                b[i] = (y[i] - y[i - 1]) / h[i] - (h[i] / 3) * (c[i + 1] + 2 * c[i]);
                d[i] = (c[i + 1] - c[i]) / (3 * h[i]);
            };
            a[N - 1] = y[N - 2];
            b[N - 1] = (y[N - 1] - y[N - 2]) / h[N - 1] - (2.0 / 3.0) * h[N - 1] * c[N - 1];
            d[N - 1] = -c[N - 1] / (3 * h[N - 1]);
            return z => {
               // if (z < x.Min() || z > x.Max())
               //     throw new IndexOutOfRangeException();
                double minX = x.Min();
                int index = 0;
                double diff = z - minX;
                for (int i = 0; i < x.Length; i++)
                {
                    if (minX == x[i])
                    {
                        index = i;
                        break;
                    }
                }
                return a[index + 1] + b[index + 1] * diff + c[index + 1] * Math.Pow(diff, 2) + d[index + 1] * Math.Pow(diff, 3);
            };
        }


       private double[] TridiagonalSolve(double[] y, double[] h)
        {
            int i = 1;
            int N = y.Length;
            double[] alfa = new double[N];
            var beta = new double[N];
            var hamma = new double[N];
            var delta = new double[N];
            var A = new double[N];
            var B = new double[N];
            var c = new double[N];
            alfa[1] = hamma[1] = delta[1] = 0.0;
            beta[1] = 1.0;
            for (i = 2; i < N; i++)
            {
                alfa[i] = h[i - 1];
                beta[i] = 2 * (h[i - 1] + h[i]);
                hamma[i] = h[i];
                delta[i] = 3 * (((y[i] - y[i - 1]) / h[i]) - ((y[i - 1] - y[i - 2]) / h[i - 1]));
            }
            hamma[N - 1] = 0.0;
            A[1] = -hamma[1] / beta[1];
            B[1] = delta[1] / beta[1];
            for (i = 1; i < N - 1; i++)
            {
                A[i] = -hamma[i] / (alfa[i] * A[i - 1] + beta[i]);
                B[i] = (delta[i] - alfa[i] * B[i - 1]) / (alfa[i] * A[i - 1] + beta[i]);
            }
            c[N - 1] = (delta[N - 1] - alfa[N - 1] * B[N - 2]) / (alfa[N - 1] * A[N - 2] + beta[N - 1]);

            for (i = N - 1; i > 0; i--)
            {
                c[i - 1] = A[i - 1] * c[i] + B[i - 1];
            }
            return c;
        }
    }
}
