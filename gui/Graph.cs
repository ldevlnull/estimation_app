using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace gui
{
    class Graph : IGraph
    {
        public void Build(PictureBox ApproximationGraph, PictureBox ErrorGraph,
            double LeftBorder, double RightBorder, int PointAmount,
            Func<double, double> EstimatedFunc, Func<double, double> AnalyticFunc)
        {
            NEst = PointAmount;
            lBorder = LeftBorder;
            rBorder = RightBorder;
            estimatedFunc = EstimatedFunc;
            analyticFunc = AnalyticFunc;

            pbHeight = ApproximationGraph.Height;
            pbWidth = ApproximationGraph.Width;
            gest = ApproximationGraph.CreateGraphics();
            gest.Clear(Color.White);
            gerr = ErrorGraph.CreateGraphics();
            gerr.Clear(Color.White);

            GetGraphEstimatedArray();
            GetGraphErrorArray();
            GetCoeffEstimated();
            GetCoeffError();

            DrawWeb(gest, Kx, Ky, Zx, Zy, Gx, Gy);
            DrawWeb(gerr, Kx, Kye, Zx, Zye, Gx, Gye);

            for (int i = 1; i < NEst; i++)
                gest.DrawLine(pen4, (float)(Kx * XEst[i - 1] + Zx), (float)(Ky * YEst[i - 1] + Zy),
                    (float)(Kx * XEst[i] + Zx), Convert.ToInt32(Ky * YEst[i] + Zy));
            for (int i = 1; i < NEst; i++)
                gerr.DrawLine(pen1, (float)(Kx * XEst[i - 1] + Zx), (float)(Kye * YErr[i - 1] + Zye),
                    (float)(Kx * XEst[i] + Zx), Convert.ToInt32(Kye * YErr[i] + Zye));
        }
        public void Build(PictureBox ApproximationGraph, PictureBox ErrorGraph,
            double LeftBorder, double RightBorder, int PointAmount,
            Func<double, double> EstimatedFunc)
        {
            NEst = PointAmount;
            lBorder = LeftBorder;
            rBorder = RightBorder;
            estimatedFunc = EstimatedFunc;

            pbHeight = ApproximationGraph.Height;
            pbWidth = ApproximationGraph.Width;
            gest = ApproximationGraph.CreateGraphics();
            gest.Clear(Color.White);
            gerr.Clear(Color.White);

            GetGraphEstimatedArray();
            GetCoeffEstimated();

            DrawWeb(gest, Kx, Ky, Zx, Zy, Gx, Gy);

            for (int i = 1; i < NEst; i++)
                gest.DrawLine(pen4, (float)(Kx * XEst[i - 1] + Zx), (float)(Ky * YEst[i - 1] + Zy),
                    (float)(Kx * XEst[i] + Zx), Convert.ToInt32(Ky * YEst[i] + Zy));
        }

        Graphics gest, gerr;
        Pen pen1 = new Pen(Color.Blue, (float)(2));
        Pen pen2 = new Pen(Color.Red, (float)(2));
        Pen pen3 = new Pen(Color.Gray, (float)(1));
        Pen pen4 = new Pen(Color.Orange, (float)(2));

        Func<double, double> estimatedFunc;
        Func<double, double> analyticFunc;

        double lBorder, rBorder;
        int NEst;
        double[] XEst;
        double[] YEst;
        double[] YErr;

        double Kx, Ky, Kye, Zx, Zy, Zye;
        double maxx, maxy, minx, miny, maxye, minye;
        double Gx, Gy, Gye;
        int StepX, StepY, L;

        int pbHeight, pbWidth;

        void GetCoeffEstimated()
        {
            minx = XEst[0];
            maxx = XEst[NEst - 1];
            maxy = miny = YEst[0];
            for (int i = 1; i < NEst; i++)
            {
                if (maxy < YEst[i]) maxy = YEst[i];
                if (miny > YEst[i]) miny = YEst[i];
            }
            for (int i = 1; i < NEst; i++)
            {
                if (maxy < YEst[i]) maxy = YEst[i];
                if (miny > YEst[i]) miny = YEst[i];
            }

            L = 15;
            Kx = (pbWidth - 2 * L) / (maxx - minx);
            Ky = (pbHeight - 2 * L) / (miny - maxy);
            Zx = (pbWidth * minx - L * (maxx + minx)) / (minx - maxx);
            Zy = (pbHeight * maxy - L * (miny + maxy)) / (maxy - miny);
            Gx = 0; Gy = L;

            if (minx * maxx <= 0.0) Gx = 0.0;
            if (minx * maxx > 0.0) Gx = minx;
            if (minx * maxx > 0.0 && minx < 0.0) Gx = maxx;
            if (miny * maxy <= 0.0) Gy = 0.0;
            if (miny * maxy > 0.0 && miny > 0.0) Gy = miny;
            if (miny * maxy > 0.0 && miny < 0.0) Gy = maxy;

            StepX = StepY = 50;
        }
        void GetCoeffError()
        {
            maxye = minye = YErr[0];
            for (int i = 1; i < NEst; i++)
            {
                if (maxye < YErr[i]) maxye = YErr[i];
                if (minye > YErr[i]) minye = YErr[i];
            }
            Kye = (pbHeight - 2 * L) / (minye - maxye);
            Zye = (pbHeight * maxye - L * (minye + maxye)) / (maxye - minye);
            Gye = L;
            if (minye * maxye <= 0.0) Gye = 0.0;
            if (minye * maxye > 0.0 && minye > 0.0) Gye = minye;
            if (minye * maxye > 0.0 && minye < 0.0) Gye = maxye;
        }

        void DrawWeb(Graphics g, double kx, double ky, double zx, double zy, double gx, double gy)
        {
            for (int i = 1; ky * gy + zy - i * StepY > L; i++)
            {
                string output = String.Format("{0:g3}", (double)(ky * gy - i * StepY) / ky);
                g.DrawLine(pen3, L, (float)(ky * gy + zy) - i * StepY, pbWidth - L,
                    (float)(ky * gy + zy) - i * StepY);
                g.DrawString(output, new Font("Arial", 8), Brushes.Black,
                    (float)(kx * gx + zx), (float)(ky * gy + zy) - i * StepY - 15);
            }
            for (int i = 1; ky * gy + zy + i * StepY < pbHeight - L; i++)
            {
                string output = String.Format("{0:g3}", (double)((ky * gy + i * StepY) / ky));
                g.DrawLine(pen3, L, (float)(ky * gy + zy) + i * StepY, pbWidth - L,
                        (float)(ky * gy + zy) + i * StepY);
                g.DrawString(output, new Font("Arial", 8), Brushes.Black,
                    (float)(kx * gx + zx), (float)(ky * gy + zy) + i * StepY - 15);
            }
            for (int i = 0; kx * gx + zx - i * StepX > L; i++)
            {
                string output = String.Format("{0:g3}", (double)((kx * gx - i * StepX) / kx));
                g.DrawLine(pen3, (float)(kx * gx + zx) - i * StepX, L,
                        (float)(kx * gx + zx) - i * StepX, pbHeight - L);
                g.DrawString(output, new Font("Arial", 8), Brushes.Black,
                    (float)(kx * gx + zx) - i * StepX, (float)(ky * gy + zy) - L);
            }
            for (int i = 0; kx * gx + zx + i * StepX < pbWidth - L; i++)
            {
                string output = String.Format("{0:g3}", (double)(kx * gx + i * StepX) / kx);
                g.DrawLine(pen3, (float)(kx * gx + zx) + i * StepX, L,
                        (float)(kx * gx + zx) + i * StepX, pbHeight - L);
                g.DrawString(output, new Font("Arial", 8), Brushes.Black,
                    (float)(kx * gx + zx) + i * StepX, (float)(ky * gy + zy) - L);
            }
            g.DrawLine(pen2, L, (float)(ky * gy + zy), (float)(pbWidth - L), (float)(ky * gy + zy));
            g.DrawLine(pen2, (float)(kx * gx + zx), L, (float)(kx * gx + zx), (float)(pbHeight - L));
        }
        void GetGraphEstimatedArray()
        {
            XEst = new double[NEst];
            YEst = new double[NEst];
            double step = (rBorder - lBorder) / NEst;
            for (int i = 0; i < NEst; i++)
            {
                XEst[i] = lBorder + step * i;
                YEst[i] = estimatedFunc(XEst[i]);
            }
        }
        void GetGraphErrorArray()
        {
            YErr = new double[NEst];
            double step = (rBorder - lBorder) / NEst;
            for (int i = 0; i < NEst; i++)
            {
                double x = lBorder + step * i;
                YErr[i] = Math.Abs(estimatedFunc(x) - analyticFunc(x));
            }
        }
    }
}
