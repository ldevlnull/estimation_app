using System;
using System.Collections.Generic;
using System.Text;

namespace gui
{
    class Linear_LSM : IEstimationMethod
    {
        public Func<double, double> Estimate(double[] X, double[] Y)
        {
            int m = get_m(X, Y); // int m = 12
            double[] C = new double[m];
            double[] A = new double[m];
            double[,] B = new double[m, m];

            get_B(B, X);
            get_C(C, X, Y);
            Gauss(B, C, A);

            return x => aprocsimation(A, x);
        }
        private double aprocsimation(double[] A, double x)
        {
            double phi = 0;
            for (int i = 0; i < A.Length; i++)
                phi += A[i] * Math.Pow(x, i);
            return phi;
        }
        private double dispersion(double[] X, double[] Y, double[] A)
        {
            double D = 0;
            for (int i = 0; i < X.Length; i++)
                D += Math.Pow(Y[i] - aprocsimation(A, X[i]), 2);
            return Math.Sqrt(D / (X.Length));
        }
        private int get_m(double[] X, double[] Y)       // для знаходження оптимального m
        {
            int m = 1;
            double disp = 1;
            while (true)
            {
                double[] C = new double[m];
                double[] A = new double[m];
                double[,] B = new double[m, m];
                get_B(B, X);
                get_C(C, X, Y);
                Gauss(B, C, A);
                double d = dispersion(X, Y, A);
                if (m == 1 || disp > d)
                {
                    disp = d;
                    m++;
                }
                else
                {
                    m--;
                    return m;
                }
            }
        }
        private void get_B(double[,] B, double[] X)
        {
            for (int k = 0; k < B.GetUpperBound(0) + 1; k++)
            {
                for (int l = 0; l < B.GetUpperBound(0) + 1; l++)
                {
                    B[k, l] = 0;
                    for (int i = 0; i < X.Length; i++)
                    {
                        B[k, l] += Math.Pow(X[i], k + l);
                        if (i == X.Length) break;
                    }
                }
            }
        }
        private void get_C(double[] C, double[] X, double[] Y)
        {
            for (int k = 0; k < C.Length; k++)
            {
                C[k] = 0;
                for (int i = 0; i < X.Length; i++)
                    C[k] += Y[i] * Math.Pow(X[i], k);
            }
        }
        private void Gauss(double[,] B, double[] C, double[] A)
        {
            double R = 0;
            int N = C.Length;
            if (N == 0)
            {
                A[0] = C[0] / B[0, 0];
                return;
            }
            for (int i = 0; i < N - 1; i++)
            {
                int k = i;
                R = Math.Abs(B[i, i]);
                for (int j = i + 1; j < N; j++)
                {
                    if (Math.Abs(B[j, i]) >= R)
                    {
                        k = j;
                        R = Math.Abs(B[j, i]);
                    }
                }
                if (k != i)
                {
                    R = C[k];
                    C[k] = C[i];
                    C[i] = R;
                    for (int j = 0; j < N; j++)
                    {
                        R = B[k, j];
                        B[k, j] = B[i, j];
                        B[i, j] = R;
                    }
                }
                R = B[i, i];
                C[i] = C[i] / R;
                for (int j = 0; j < N; j++)
                    B[i, j] = B[i, j] / R;
                for (k = i + 1; k < N; k++)
                {
                    R = B[k, i];
                    C[k] = C[k] - R * C[i];
                    B[k, i] = 0;
                    for (int j = i + 1; j < N; j++)
                        B[k, j] = B[k, j] - R * B[i, j];
                }
            }
            A[N - 1] = C[N - 1] / B[N - 1, N - 1];
            for (int i = N - 2; i >= 0; i--)
            {
                R = C[i];
                for (int j = i + 1; j < N; j++)
                    R = R - B[i, j] * A[j];
                A[i] = R;
            }
        }
    }
}
