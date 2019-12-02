using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gui
{
    interface IGraph
    {
        void Build(PictureBox ApproximationGraph, PictureBox ErrorGraph,
            double LeftBorder, double RightBorder, int PointAmount,
            Func<double, double> function);
        void Build(PictureBox ApproximationGraph, PictureBox ErrorGraph,
            double LeftBorder, double RightBorder, int PointAmount,
            Func<double, double> EstimatedFunction, Func<double, double> AnalyticFunction);
    }
}
