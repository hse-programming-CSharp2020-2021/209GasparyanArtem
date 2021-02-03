using System;

namespace _3_seminar
{
    class Program
    {
        delegate void CoordChanged(Dot a);
        class Dot
        {
            public event CoordChanged OnCoordChanged;
            public double X { get; set; } = 0;
            public double Y { get; set; } = 0;
            public Dot(double x, double y)
            {
                X = x;
                Y = y;
            }
            public void DotFlow()
            {
                Random rnd = new Random();
                for (int i = 0; i < 10; i++)
                {
                    X = rnd.NextDouble() * 20 - 10;
                    Y = rnd.NextDouble() * 20 - 10;
                    if (X < 0 && Y < 0)
                        OnCoordChanged?.Invoke(this);
                }
            }
        }
        static void PrintInfo(Dot A)
        {
            Console.WriteLine($"X:{A.X} Y:{A.Y}");
        }
        static void Main(string[] args)
        {
            Console.Write("Введите x: ");
            double x = double.Parse(Console.ReadLine());
            Console.Write("Введите y: ");
            double y = double.Parse(Console.ReadLine());
            Dot D = new Dot(x, y);
            D.OnCoordChanged += PrintInfo;
            D.DotFlow();
        }
    }
}
