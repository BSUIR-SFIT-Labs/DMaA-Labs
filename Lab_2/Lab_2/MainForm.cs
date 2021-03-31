using System;
using System.Drawing;
using System.Windows.Forms;
using Lab_2.Entities;

namespace Lab_2
{
    public partial class MainForm : Form
    {
        private const int MaxClasses = 20;
        private const int MaxColorArg = 256;
        private const int ShapePointWidth = 2;
        private const int ShapePointHeight = 2;
        private const int ClassPointWidth = 10;
        private const int ClassPointHeight = 10;

        private readonly Random _random = new Random();
        private readonly Color[] _colors = new Color[20];

        private Shape[] _shapes;
        private Shape[] _kernels;
        private Shape[] _newKernels;
        private int _amountOfClasses;
        private int _amountOfShapes;

        public MainForm()
        {
            InitializeComponent();

            for (int i = 0; i < _colors.Length; i++)
            {
                _colors[i] = Color.FromArgb(_random.Next(MaxColorArg), _random.Next(MaxColorArg),
                    _random.Next(MaxColorArg));
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            var graphics = pictureBox.CreateGraphics();
            graphics.Clear(Color.White);

            try
            {
                _amountOfShapes = int.Parse(tbAmountOfShapes.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show(@"Please enter the correct number!", @"Error", MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Error);
            }

            _shapes = new Shape[_amountOfShapes];

            for (int i = 0; i < _amountOfShapes; i++)
            {
                graphics = pictureBox.CreateGraphics();
                _shapes[i].Point = new Point(_random.Next(pictureBox.Width), _random.Next(pictureBox.Height));
                graphics.FillRectangle(new SolidBrush(Color.Gray), _shapes[i].Point.X, _shapes[i].Point.Y, ShapePointWidth, ShapePointHeight);
                _shapes[i].AmountOfClasses = 0;
            }

            _kernels = new Shape[MaxClasses];
            int randomNumber = _random.Next(_amountOfShapes);
            _kernels[0].Point = _shapes[randomNumber].Point;

            for (int i = randomNumber; i < _amountOfShapes - 1; i++)
            {
                _shapes[i] = _shapes[i + 1];
            }

            graphics = pictureBox.CreateGraphics();
            graphics.FillEllipse(new SolidBrush(Color.Black), _kernels[0].Point.X - 5, _kernels[0].Point.Y - 5, ClassPointWidth, ClassPointHeight);
            graphics.DrawEllipse(new Pen(Brushes.Black), _kernels[0].Point.X - 5, _kernels[0].Point.Y - 5, ClassPointWidth, ClassPointHeight);
        }

        private void btnExecuteMaximinsAlgorithm_Click(object sender, EventArgs e)
        {
            double maxDistance = -1;
            double distance;
            int index = 0;

            for (int i = 0; i < _amountOfShapes; i++)
            {
                distance = Math.Sqrt(Math.Pow(_shapes[i].Point.X - _kernels[0].Point.X, 2) +
                                     Math.Pow(_shapes[i].Point.Y - _kernels[0].Point.Y, 2));
                if (distance > maxDistance)
                {
                    maxDistance = distance;
                    _kernels[1].Point = _shapes[i].Point;
                    index = i;
                }
            }

            for (int i = index; i < _amountOfShapes - 1; i++)
            {
                _shapes[i] = _shapes[i + 1];
            }

            _amountOfShapes -= 1;
            _kernels[1].AmountOfClasses = 1;
            _amountOfClasses = 2;

            bool isReady = true;

            while (isReady)
            {
                Graphics graphics;

                for (int i = 0; i < _amountOfClasses; i++)
                {
                    graphics = pictureBox.CreateGraphics();
                    graphics.FillEllipse(new SolidBrush(Color.Black), _kernels[i].Point.X - 5, _kernels[i].Point.Y - 5, ClassPointWidth, ClassPointHeight);
                    graphics.DrawEllipse(new Pen(Brushes.Black), _kernels[i].Point.X - 5, _kernels[i].Point.Y - 5, ClassPointWidth, ClassPointHeight);
                }

                for (int i = 0; i < _amountOfShapes; i++)
                {
                    double minDistance = 100000000;
                    for (int j = 0; j < _amountOfClasses; j++)
                    {
                        distance = Math.Sqrt(
                            (_shapes[i].Point.X - _kernels[j].Point.X) * (_shapes[i].Point.X - _kernels[j].Point.X) +
                            (_shapes[i].Point.Y - _kernels[j].Point.Y) * (_shapes[i].Point.Y - _kernels[j].Point.Y));

                        if (distance < minDistance)
                        {
                            minDistance = distance;
                            _shapes[i].AmountOfClasses = j;
                        }
                    }
                }

                for (int i = 0; i < _amountOfShapes; i++)
                {
                    graphics = pictureBox.CreateGraphics();
                    graphics.FillRectangle(new SolidBrush(_colors[_shapes[i].AmountOfClasses]), _shapes[i].Point.X,
                        _shapes[i].Point.Y, 3, 3);
                }

                for (int i = 0; i < _amountOfClasses; i++)
                {
                    graphics = pictureBox.CreateGraphics();
                    graphics.FillEllipse(new SolidBrush(Color.Black), _kernels[i].Point.X - 5, _kernels[i].Point.Y - 5, ClassPointWidth, ClassPointHeight);
                    graphics.DrawEllipse(new Pen(Brushes.Black), _kernels[i].Point.X - 5, _kernels[i].Point.Y - 5, ClassPointWidth, ClassPointHeight);
                }

                double averageDistance = 0;
                int numberOfDistance = 0;

                for (int i = 0; i < _amountOfClasses - 1; i++)
                {
                    for (int j = i + 1; j < _amountOfClasses; j++)
                    {
                        averageDistance +=
                            Math.Sqrt(
                                (_kernels[i].Point.X - _kernels[j].Point.X) *
                                (_kernels[i].Point.X - _kernels[j].Point.X) +
                                (_kernels[i].Point.Y - _kernels[j].Point.Y) *
                                (_kernels[i].Point.Y - _kernels[j].Point.Y));
                        numberOfDistance += 1;
                    }
                }

                averageDistance /= numberOfDistance;
                averageDistance /= 2;

                maxDistance = -1;

                for (int i = 0; i < _amountOfClasses; i++)
                {
                    for (int j = 0; j < _amountOfShapes; j++)
                    {

                        if (_shapes[j].AmountOfClasses == i)
                        {
                            distance = Math.Sqrt(Math.Pow(_shapes[j].Point.X - _kernels[i].Point.X, 2) +
                                                 Math.Pow(_shapes[j].Point.Y - _kernels[i].Point.Y, 2));
                            if (distance > maxDistance)
                            {
                                maxDistance = distance;
                                _kernels[_amountOfClasses].Point = _shapes[j].Point;
                                index = j;
                            }
                        }
                    }
                }

                if (maxDistance > averageDistance)
                {
                    _amountOfClasses += 1;

                    for (int i = index; i < _amountOfShapes - 1; i++) _shapes[i] = _shapes[i + 1];

                    _amountOfShapes -= 1;

                    graphics = pictureBox.CreateGraphics();
                    graphics.Clear(Color.White);
                }
                else
                {
                    isReady = false;
                }
            }
        }

        private void btnExecuteKMeansAlgorithm_Click(object sender, EventArgs e)
        {
            bool isReady = true;

            while (isReady)
            {
                Graphics graphics;

                for (int i = 0; i < _amountOfClasses; i++)
                {
                    graphics = pictureBox.CreateGraphics();
                    graphics.FillEllipse(new SolidBrush(Color.Black), _kernels[i].Point.X, _kernels[i].Point.Y, ClassPointWidth, ClassPointHeight);
                }

                for (int i = 0; i < _amountOfShapes; i++)
                {
                    double minDistance = 100000000;

                    for (int j = 0; j < _amountOfClasses; j++)
                    {
                        double distance = Math.Sqrt(
                            (_shapes[i].Point.X - _kernels[j].Point.X) * (_shapes[i].Point.X - _kernels[j].Point.X) +
                            (_shapes[i].Point.Y - _kernels[j].Point.Y) * (_shapes[i].Point.Y - _kernels[j].Point.Y));

                        if (distance < minDistance)
                        {
                            minDistance = distance;
                            _shapes[i].AmountOfClasses = j;
                        }
                    }
                }

                for (int i = 0; i < _amountOfShapes; i++)
                {
                    graphics = pictureBox.CreateGraphics();
                    graphics.FillRectangle(new SolidBrush(_colors[_shapes[i].AmountOfClasses]), _shapes[i].Point.X,
                        _shapes[i].Point.Y, 3, 3);
                }

                for (int i = 0; i < _amountOfClasses; i++)
                {
                    graphics = pictureBox.CreateGraphics();
                    graphics.FillEllipse(new SolidBrush(Color.Black), _kernels[i].Point.X, _kernels[i].Point.Y, ClassPointWidth, ClassPointHeight);
                    graphics.DrawEllipse(new Pen(Brushes.Black), _kernels[i].Point.X, _kernels[i].Point.Y, ClassPointWidth, ClassPointHeight);
                }

                int[,] sumOfCoordinates = new int[_amountOfClasses, 3];

                for (int i = 0; i < _amountOfShapes; i++)
                {
                    sumOfCoordinates[_shapes[i].AmountOfClasses, 0] += _shapes[i].Point.X;
                    sumOfCoordinates[_shapes[i].AmountOfClasses, 1] += _shapes[i].Point.Y;
                    sumOfCoordinates[_shapes[i].AmountOfClasses, 2] += 1;
                }

                _newKernels = new Shape[_amountOfClasses];

                for (int i = 0; i < _amountOfClasses; i++)
                {
                    _newKernels[i].Point = new Point(sumOfCoordinates[i, 0] / sumOfCoordinates[i, 2],
                        sumOfCoordinates[i, 1] / sumOfCoordinates[i, 2]);
                    _newKernels[i].AmountOfClasses = i;
                }

                isReady = false;

                for (int i = 0; i < _amountOfClasses; i++)
                {
                    if (_newKernels[i].Point.X != _kernels[i].Point.X || _newKernels[i].Point.Y != _kernels[i].Point.Y)
                    {
                        isReady = true;
                    }
                }

                _kernels = _newKernels;

                if (isReady)
                {
                    graphics = pictureBox.CreateGraphics();
                    graphics.Clear(Color.White);
                }
            }
        }
    }
}