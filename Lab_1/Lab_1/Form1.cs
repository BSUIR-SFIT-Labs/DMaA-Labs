using System;
using System.Drawing;
using System.Windows.Forms;
using Lab_1.Entities;

namespace Lab_1
{
    public partial class MainForm : Form
    {
        private const int MaxColorArg = 256;
        private const int ShapePointWidth = 2;
        private const int ShapePointHeight = 2;
        private const int ClassPointWidth = 10;
        private const int ClassPointHeight = 10;

        private readonly Random _random = new Random();
        private int _amountOfClasses;
        private int _amountOfShapes;

        private Color[] _colors;
        private Shape[] _kernels;
        private Shape[] _newKernels;

        private Shape[] _shapes;

        public MainForm()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            var graphics = pbCanvas.CreateGraphics();
            graphics.Clear(Color.White);

            try
            {
                _amountOfClasses = int.Parse(tbAmountOfClasses.Text);
                _amountOfShapes = int.Parse(tbAmountOfShapes.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show(@"Please enter the correct number!", @"Error", MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Error);
            }

            _colors = new Color[_amountOfClasses];
            _shapes = new Shape[_amountOfShapes];
            _kernels = new Shape[_amountOfClasses];

            for (int i = 0; i < _amountOfClasses; i++)
                _colors[i] = Color.FromArgb(_random.Next(MaxColorArg), _random.Next(MaxColorArg),
                    _random.Next(MaxColorArg));

            for (int i = 0; i < _amountOfShapes; i++)
            {
                graphics = pbCanvas.CreateGraphics();

                _shapes[i].Point = new Point(_random.Next(pbCanvas.Width), _random.Next(pbCanvas.Height));
                graphics.FillRectangle(new SolidBrush(Color.Gray), _shapes[i].Point.X, _shapes[i].Point.Y,
                    ShapePointWidth, ShapePointHeight);
            }

            for (int i = 0; i < _amountOfClasses; i++)
            {
                graphics = pbCanvas.CreateGraphics();

                _kernels[i].Point = new Point(_random.Next(pbCanvas.Width), _random.Next(pbCanvas.Height));
                _kernels[i].AmountOfClasses = i;

                graphics.FillEllipse(new SolidBrush(_colors[i]), _kernels[i].Point.X, _kernels[i].Point.Y,
                    ClassPointWidth, ClassPointHeight);
            }
        }

        private void btnKMeans_Click(object sender, EventArgs e)
        {
            bool isReady = true;

            while (isReady)
            {
                Graphics graphics;


                for (int i = 0; i < _amountOfClasses; i++)
                {
                    graphics = pbCanvas.CreateGraphics();

                    graphics.FillEllipse(new SolidBrush(_colors[i]), _kernels[i].Point.X, _kernels[i].Point.Y,
                        ClassPointWidth, ClassPointHeight);
                }

                for (int i = 0; i < _amountOfShapes; i++)
                {
                    double minDistance = 100000000;

                    for (int j = 0; j < _amountOfClasses; j++)
                    {
                        double distance = Math.Sqrt(
                            (_shapes[i].Point.X - _kernels[j].Point.X) * (_shapes[i].Point.X - _kernels[j].Point.X)
                            + (_shapes[i].Point.Y - _kernels[j].Point.Y) * (_shapes[i].Point.Y - _kernels[j].Point.Y));

                        if (distance < minDistance)
                        {
                            minDistance = distance;
                            _shapes[i].AmountOfClasses = j;
                        }
                    }
                }

                for (int i = 0; i < _amountOfShapes; i++)
                {
                    graphics = pbCanvas.CreateGraphics();

                    graphics.FillRectangle(new SolidBrush(_colors[_shapes[i].AmountOfClasses]), _shapes[i].Point.X,
                        _shapes[i].Point.Y, ShapePointWidth, ShapePointHeight);
                }

                for (int i = 0; i < _amountOfClasses; i++)
                {
                    graphics = pbCanvas.CreateGraphics();

                    graphics.FillEllipse(new SolidBrush(_colors[i]), _kernels[i].Point.X, _kernels[i].Point.Y,
                        ClassPointWidth, ClassPointHeight);
                }

                int[,] coordinatesSum = new int[_amountOfClasses, 3];

                for (int i = 0; i < _amountOfShapes; i++)
                {
                    coordinatesSum[_shapes[i].AmountOfClasses, 0] += _shapes[i].Point.X;
                    coordinatesSum[_shapes[i].AmountOfClasses, 1] += _shapes[i].Point.Y;
                    coordinatesSum[_shapes[i].AmountOfClasses, 2] += 1;
                }

                _newKernels = new Shape[_amountOfClasses];

                for (int i = 0; i < _amountOfClasses; i++)
                {
                    _newKernels[i].Point = new Point(coordinatesSum[i, 0] / coordinatesSum[i, 2],
                        coordinatesSum[i, 1] / coordinatesSum[i, 2]);

                    _newKernels[i].AmountOfClasses = i;
                }

                isReady = false;

                for (int i = 0; i < _amountOfClasses; i++)
                    if (_newKernels[i].Point.X != _kernels[i].Point.X || _newKernels[i].Point.Y != _kernels[i].Point.Y)
                        isReady = true;

                _kernels = _newKernels;

                if (isReady)
                {
                    graphics = pbCanvas.CreateGraphics();
                    graphics.Clear(Color.White);
                }
            }
        }
    }
}