using System;
using System.Drawing;

namespace _2_zadacha
{
    class Square
    {
        public delegate void SquareSizeChanged(double a);

        public event SquareSizeChanged OnSizeChanged;
        PointF leftUp;
        PointF rightDown;
        public PointF LeftUp
        {
            get
            {
                return leftUp;
            }
            set
            {
                OnSizeChanged(Math.Abs(leftUp.X - value.X));
                leftUp = value;
            }
        }
        public PointF RightDown { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {

        }
    }
}
