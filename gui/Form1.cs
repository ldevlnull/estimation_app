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
        private bool ArePointsAnatytic = false;

        private string FileName;

        private double[] X;
        private double[] Y;

        private IGraph graph = new Graph(); // todo

        private IEstimationMethod[] estimationMethods = {
            null,
            new Splain(), // todo: Cub Splines  
            new Factorial(), // todo: Factorial
            new LagrangePolynomial(),
            new Linear_LSM(),
            new NewtonInterpolation()
        };

        public MainWindow()
        {
            InitializeComponent();
            SelectMethodField.SelectedIndex = 0;
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
            if(!SelectedInit && SelectMethodField.SelectedIndex == 0)
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
                if (Selected == 1 || Selected == 2)
                {
                    throw new NotImplementedException();
                }
                else
                {
                    IEstimationMethod method = estimationMethods[Selected];
                    if(ArePointsReady)
                    {
                        Func<double, double> function = method.Estimate(X, Y);
                        if (ArePointsReadFromFile)
                            FileUtil.ReadCoords(out X, out Y, FileName);
                        else if(ArePointsAnatytic) {
                        
                            return;
                        }
                        graph.Build(
                            ApproximationGraphBox, 
                            ErrorGraphBox, 
                            Convert.ToDouble(LeftBorderField.Text), 
                            Convert.ToDouble(RightBorderField.Text), 
                            Convert.ToInt32(PointsAmountField.Text), 
                            function, X, Y
                        );
                    } 
                    else
                    {
                        throw new ArgumentNullException("Points weren't presented");
                    }
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
            return System.Text.RegularExpressions.Regex.IsMatch(field.Text, "[^0-9.]");
        }

        private void GenerateButton_Click(object sender, EventArgs e)
        {
            double a = Convert.ToDouble(GenerateFromField.Text);
            double b = Convert.ToDouble(GenerateToField.Text);
            int n = Convert.ToInt32(GeneratePointAmountField.Text);

            X = new double[n];
            Y = new double[n];
            Random random = new Random();
            for(int i = 0; i < n; i++)
            {
                X[i] = random.NextDouble() * (b - a) + a;
                Y[i] = random.NextDouble() * (b - a) + a;
            }
            ArePointsReady = true;
        }

        // todo: implement reading of points from file
        private void ReadPointsFromFileButton_Click(object sender, EventArgs e)
        {
            ArePointsReadFromFile = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                FileName = openFileDialog1.FileName;

            ArePointsReady = true;
        }

        private void GeneratePointsRadio_CheckedChanged(object sender, EventArgs e)
        {
            ArePointsReadFromFile = false;
        }
    }
}
