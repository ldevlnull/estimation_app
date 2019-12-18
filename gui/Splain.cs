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
            int N = x.Length - 1;
            h = new double[N+1];
            a = new double[N+1];
            b = new double[N+1];
            for (int i = 0; i < N; i++)
            {
                h[i] = x[i + 1] - x[i];
            }
            h[N] = h[N - 1];
            c = TridiagonalSolve(y, h);
            d = new double[N+1];

            for (int i = 1; i < N; i++)
            {
                a[i] = y[i - 1];
                b[i] = (y[i] - y[i - 1]) / h[i] - (h[i] / 3) * (c[i + 1] + 2 * c[i]);
                d[i] = (c[i + 1] - c[i]) / (3 * h[i]);
            };
            a[N] = y[N];
            b[N] = (y[N] - y[N - 1]) / h[N] - (2.0 / 3.0) * h[N] * c[N];
            d[N] = -c[N] / (3 * h[N]);
            return z =>
            {
                int i = 0;
                double diff = double.MaxValue;
                for (int j = 1; j < N; j++)
                {
                    double temp = z - x[j-1];
                    if (diff > temp && temp >= 0)
                    {
                        diff = temp;
                        i = j;
                    }
                }
                return a[i] + b[i] * (diff) +
                    c[i] * Math.Pow(diff, 2) +
                    d[i] * Math.Pow(diff, 3);
            };
        }


       private double[] TridiagonalSolve(double[] y, double[] h)
        {
            int N = y.Length-1;
            double[] alf = new double[N+1];
            double[] bet = new double[N + 1];
            double[] ham = new double[N + 1];
            double[] del = new double[N + 1];
            double[] A = new double[N + 1];
            double[] B = new double [N+1];
            double[] c = new double[N + 1];
            alf[1] = 0;
            bet[1] = 1;
            ham[1] = 0;
            del[1] = 0;
            for (int i = 2; i <= N; i++)
            {
                alf[i] = h[i - 1];
                bet[i] = 2 * (h[i - 1] + h[i]);
                ham[i] = h[i];
                del[i] = 3 * (((y[i] - y[i - 1]) / h[i]) - ((y[i - 1] - y[i - 2]) / h[i - 1]));
            }
            ham[N] = 0;

            A[1] = -ham[1] / bet[1];
            B[1] = del[1] / bet[1];

            for (int i = 2; i <= N - 1; i++)
            {
                A[i] = -ham[i] / (alf[i] * A[i - 1] + bet[i]);
                B[i] = (del[i] - alf[i] * B[i - 1]) / (alf[i] * A[i - 1] + bet[i]);
            }

            c[N] = (del[N] - alf[N] * B[N - 1]) / (alf[N] * A[N - 1] + bet[N]);
            for (int i = N; i > 1; i--)
            {
                c[i - 1] = A[i - 1] * c[i] + B[i - 1];
            }
            return c;
        }
    }
}
