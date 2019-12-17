using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gui
{
    public partial class MainWindow : Form
    {
        private bool SelectedInit = true;
        private bool ArePointsReady = false;
        private bool ArePointsReadFromFile = false;
        private bool ArePointsAnalytic = false;

        private string FileName;

        private double[] X;
        private double[] Y;

        private IGraph graph = new Graph();
        Func<double, double> AnalyticFunction;

        private IEstimationMethod[] estimationMethods = {
            null,
            new Splain(),
            new Factorial(),
            new LagrangePolynomial(),
            new Linear_LSM(),
            new NewtonInterpolation()
        };

        private Func<double, double>[] AnalyticFunctions = {
            null,
            x => 2 * Math.Cos(x),
            x => Math.Sin(x),
            x => Math.Exp(x),
            x => 1 / (1 + x * x)
        };

        public MainWindow()
        {
            InitializeComponent();
            SelectMethodField.SelectedIndex = 0;
            AnalyticFunctionsCombo.SelectedIndex = 0;
        }

        private void InputPointsRadio_CheckedChanged(object sender, EventArgs e)
        {
            bool Status = InputPointsRadio.Checked;

            ReadPointsFromFileButton.Visible = Status;
            ReadPointsFromFileLabel.Visible = Status;

            GenerateFromField.Visible = !Status;
            GenerateToField.Visible = !Status;
            GenerateFromField.Visible = !Status;
            GenerateRangeLabel.Visible = !Status;
            GenerateButton.Visible = !Status;
            GeneratePointsAmoutLabel.Visible = !Status;
            GeneratePointAmountField.Visible = !Status;

        }

        private void SelectMethodField_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!SelectedInit && SelectMethodField.SelectedIndex == 0)
            {
                SelectMethodField.SelectedIndex = 1;
            }
            SelectedInit = false;
        }

        private void ApproximateButton_Click(object sender, EventArgs e)
        {
            int Selected = SelectMethodField.SelectedIndex;
            if (ValidateInput())
            {
                IEstimationMethod method = estimationMethods[Selected];
                if (ArePointsReady)
                {
                    if (ArePointsAnalytic)
                    {
                        Func<double, double> function = method.Estimate(X, Y);
                        graph.Build(
                            ApproximationGraphBox,
                            ErrorGraphBox,
                            Convert.ToDouble(LeftBorderField.Text),
                            Convert.ToDouble(RightBorderField.Text),
                            Convert.ToInt32(PointsAmountField.Text),
                            Convert.ToInt32(GeneratePointAmountField.Text),
                            function, AnalyticFunction
                            );
                    }
                    else
                    {
                        if (ArePointsReadFromFile)
                            FileUtil.ReadCoords(out X, out Y, FileName);
                        Func<double, double> function = method.Estimate(X, Y);
                        graph.Build(
                            ApproximationGraphBox,
                            ErrorGraphBox,
                            Convert.ToDouble(LeftBorderField.Text),
                            Convert.ToDouble(RightBorderField.Text),
                            Convert.ToInt32(PointsAmountField.Text),
                            function, X, Y
                        );
                    }
                }
                else
                {
                    throw new ArgumentNullException("Points weren't presented");
                }

            }
        }

        // todo: add validation for generations field and validate them, only if corresponding method is selected
        private bool ValidateInput()
        {
            if (SelectMethodField.SelectedIndex == 0)
            {
                MessageBox.Show("Select Method field cannot be empty!", "Error!", MessageBoxButtons.OK);
            }
            else if (IsOnlyNumbersAndDot(LeftBorderField))
            {
                MessageBox.Show("Left Border field can contain only numbers!", "Error!", MessageBoxButtons.OK);
            }
            else if (IsOnlyNumbersAndDot(RightBorderField))
            {
                MessageBox.Show("Right Border field can contain only numbers!", "Error!", MessageBoxButtons.OK);
            }
            else if (IsOnlyNumbersAndDot(PointsAmountField))
            {
                MessageBox.Show("Points Amount field can contain only numbers!", "Error!", MessageBoxButtons.OK);
            }
            else if (IsOnlyNumbersAndDot(GenerateFromField))
            {
                MessageBox.Show("Generate From field can contain only numbers!", "Error!", MessageBoxButtons.OK);
            }
            else if (IsOnlyNumbersAndDot(GenerateToField))
            {
                MessageBox.Show("Generate To field can contain only numbers!", "Error!", MessageBoxButtons.OK);
            }
            else
            {
                return true;
            }
            return false;
        }

        private bool IsOnlyNumbersAndDot(TextBox field)
        {
            if (field.Text == "") return false;
            return System.Text.RegularExpressions.Regex.IsMatch(field.Text, "[^0-9.+-]");
        }

        private void GenerateButton_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                double a = Convert.ToDouble(GenerateFromField.Text);
                double b = Convert.ToDouble(GenerateToField.Text);
                int n = Convert.ToInt32(GeneratePointAmountField.Text);

                X = new double[n];
                Y = new double[n];
                if (ArePointsAnalytic)
                {
                    if (AnalyticFunctionsCombo.SelectedIndex == 0)
                    {
                        MessageBox.Show("Select Analytic Function cannot be empty!", "Error!", MessageBoxButtons.OK);
                        return;
                    }
                    AnalyticFunction = AnalyticFunctions[AnalyticFunctionsCombo.SelectedIndex];
                    double step = (b - a) / n;
                    for (int i = 0; i < n; i++)
                    {
                        X[i] = a + i * step;
                        Y[i] = AnalyticFunction(X[i]);
                    }
                }
                else
                {
                    Random random = new Random();
                    for (int i = 0; i < n; i++)
                    {
                        X[i] = random.NextDouble() * (b - a) + a;
                        Y[i] = random.NextDouble() * (b - a) + a;
                    }
                }
                ArePointsReady = true;
            }
        }

        private void ReadPointsFromFileButton_Click(object sender, EventArgs e)
        {
            ArePointsReadFromFile = true;
            ArePointsAnalytic = false;
            
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                FileName = openFileDialog1.FileName;

            ArePointsReady = true;
        }

        private void GeneratePointsRadio_CheckedChanged(object sender, EventArgs e)
        {
            ArePointsReadFromFile = false;
            ArePointsAnalytic = false;
        }

        private void AnalyticFunctionRadio_CheckedChanged(object sender, EventArgs e)
        {
            AnalyticFunctionsCombo.Visible = !AnalyticFunctionsCombo.Visible;
            ArePointsAnalytic = true;
            ArePointsReadFromFile = false;
        }
    }
}