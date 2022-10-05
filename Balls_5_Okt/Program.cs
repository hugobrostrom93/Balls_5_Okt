using System.Security.Cryptography.X509Certificates;

namespace Balls
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Ball[] balls = new Ball[200];
            Random rnd = new();
            for (var i = 0; i < balls.Length; i++)
            {
                balls[i] = new Ball();
                balls[i].X = rnd.Next(1, Console.WindowWidth - 1);
                balls[i].Y = rnd.Next(1, Console.WindowHeight - 1);
            }
            while (true)
            {
                foreach (Ball ball in balls)
                {
                    ball.Move();
                }
                Thread.Sleep(100); // Vänta en tioendels sekund
            }
        }


        class Ball
        {
            public int X { get; set; } = 0;
            public int Y { get; set; } = 0;
            public int MaxX { get; set; } = 100;
            public int MaxY { get; set; } = 20;
            public int MinX { get; set; } = 1;
            public int MinY { get; set; } = 1;
            public int DirX { get; set; } = 1;
            public int DirY { get; set; } = 1;

            public Ball()
            {
                Console.CursorVisible = false;
                X = 1;
                Y = 1;
                MaxX = Console.WindowWidth - 1;
                MaxY = Console.WindowHeight - 1;
                MinY = 1;
                MaxY = 1;
            }

            public Ball(int x, int y) : base()
            {
                X = x;
                Y = y;
            }

            public void Move()
            {
                Console.SetCursorPosition(X, Y); // Sätt cursorns positon
                Console.Write(' '); // Radera den gamla positionen
                X += DirX; // Öka eller minska X positionen
                Y += DirY; // Öka eller minska Y positionen
                           // Tänk på att skärmpositionerna vid (0,0) börjar alltid högst upp till vänster.
                if (X <= MinX) DirX = 1; // Om lägre gräns nådd, ändra riktning höger.
                if (X >= MaxX) DirX = -1; // Om högre gräns är nådd, ändra riktning vänster.
                if (Y <= MinY) DirY = 1; // Om lägre gräns nådd, ändra riktning nedåt.
                if (Y >= MaxY) DirY = -1; // Om högre gräns är nådd, ändra riktning upp.
                Console.SetCursorPosition(X, Y); // Sätt cursorns positon
                Console.Write('O'); // Skriv en boll
            }
        }
    }
}