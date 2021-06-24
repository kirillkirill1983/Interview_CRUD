using System;


namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите значение точки Положение Х");
            int PointX = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите значение точки Положение Y");
            int PointY = Convert.ToInt32(Console.ReadLine());
            
            Point pointOne = new Point(PointX, PointY);
            
            while (true)
            {
                Console.WriteLine($"Задайте скорость");
                int speed = Convert.ToInt32(Console.ReadLine());
                                            
                Summa(ref pointOne, speed);
                Console.WriteLine("Для выхода введите N, для продолжения Enter ");
                string stop = Console.ReadLine();
                if (stop=="N")
                {
                    break;
                }
            }
            Console.WriteLine("ВЫХОД");
            Console.ReadKey();
        }
        static void Summa (ref Point pointOne,int speed) 
        {
            int pointXNew=pointOne.PontX +speed;
            int pointYNew= pointOne.PontY+ speed;
            Console.WriteLine($"точка Х {pointXNew} точка У {pointYNew} ");
            double resultVecor = Math.Sqrt(Math.Pow(pointXNew-pointOne.PontX,2)+Math.Pow(pointYNew-pointOne.PontY,2));
            Console.WriteLine($"Пройденный путь{resultVecor:F3}");
            pointOne = new Point(pointXNew,pointYNew);

        }
    }
    class Point
    {
        public int PontX { get; set; }
        public int PontY {get;set;}
        public Point(int X,int Y)
        {
            this.PontX = X;
            this.PontY = Y;
        }
        public static Point operator +(Point pointOne, Point pointyTwo) 
        {
            return new Point(pointOne.PontX + pointyTwo.PontX, pointOne.PontY + pointyTwo.PontY);
        }
        public override string ToString()
        {
            return String.Format($"{this.PontX } : {this.PontY}");
        }
    }
}

