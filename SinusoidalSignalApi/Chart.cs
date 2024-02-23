using System.Drawing;
using ZedGraph;

namespace SinusoidalSignalApi
{
    public static class Chart
    {
        public static GraphPane DrawSinusoidal(double A, double Fd, double Fs, double N)
        {
            GraphPane graphPane = new();

            graphPane.Title.Text = "Sinusoidal signal Asin(2Pi * f * t)";
            graphPane.YAxis.Title.Text = "Amplitude";
            graphPane.XAxis.Title.Text = "Time";

            PointPairList list = new();

            double timeStep = 1.0 / Fd;
            double periodLenght = 1.0 / Fs;
            double length = periodLenght * N;

            graphPane.XAxis.Scale.Min = 0;
            graphPane.XAxis.Scale.Max = length;
            graphPane.YAxis.Scale.Min = -A;
            graphPane.YAxis.Scale.Max = A;

            for (double i = 0; i < length; i += timeStep)
            {
                list.Add(i, A * Math.Sin(2 * Math.PI * Fs * i));
            }
            graphPane.AddCurve("", list, Color.Red);

            return graphPane;
        }
    }
}
