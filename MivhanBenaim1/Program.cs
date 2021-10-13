using System;
using System.Drawing;
using System.Text;
using System.Threading;

namespace MivhanBenaim1
{
    class Program
    {
        private static bool[,] abstackleMap = new bool[80, 25];

        static void Main(string[] args)
        {
            Console.OutputEncoding = new UTF8Encoding();
            Console.CursorVisible = false;
            Console.SetWindowSize(80, 25);
            int moves = 0;

            bool isGameGoing = true;
            Random random = new Random();
            Point starPosition = new Point(random.Next(80), random.Next(25));
            ConsoleKeyInfo key;
            bool goToNextLevel = true;
            int figuresAmount = random.Next(3, 6);

            while (isGameGoing)
            {
                if (goToNextLevel)
                {
                    DrawFigures(figuresAmount);
                    goToNextLevel = false;
                    starPosition = new Point(random.Next(80), random.Next(25));
                }

                Console.SetCursorPosition(starPosition.X, starPosition.Y);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write('*');

                Thread.Sleep(50);

                key = Console.ReadKey(true);
                Console.SetCursorPosition(starPosition.X, starPosition.Y);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write('*');

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (starPosition.Y > 0)
                        {
                            abstackleMap[starPosition.X, starPosition.Y] = true;
                            starPosition.Y--;
                            moves++;
                        }

                        break;
                    case ConsoleKey.DownArrow:
                        if (starPosition.Y < 24)
                        {
                            abstackleMap[starPosition.X, starPosition.Y] = true;
                            starPosition.Y++;
                            moves++;
                        }

                        break;
                    case ConsoleKey.RightArrow:
                        if (starPosition.X < 79)
                        {
                            abstackleMap[starPosition.X, starPosition.Y] = true;
                            starPosition.X++;
                            moves++;
                        }

                        break;
                    case ConsoleKey.LeftArrow:
                        if (starPosition.X > 0)
                        {
                            abstackleMap[starPosition.X, starPosition.Y] = true;
                            starPosition.X--;
                            moves++;
                        }

                        break;
                }

                if(abstackleMap[starPosition.X, starPosition.Y])
                {
                    if(++figuresAmount == 15)
                    {
                        Console.Clear();
                        Console.SetCursorPosition(40, 13);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("You loose");
                        isGameGoing = false;
                        Console.Read();
                    }

                    goToNextLevel = true;
                    Console.Clear();
                    abstackleMap = new bool[80, 25];
                    moves = 0;
                }

                Console.SetCursorPosition(0,0);
                Console.ForegroundColor = ConsoleColor.White;
                int freeCellsAmount = FreeCellsAmount();
                Console.Write("Moves " + moves + " of " + freeCellsAmount);
                Console.SetCursorPosition(0, 1);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Figures " + figuresAmount);

                if (freeCellsAmount == 0)
                {
                    Console.Clear();
                    Console.SetCursorPosition(40, 13);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("You win");
                    isGameGoing = false;
                    Console.Read();
                }
            }
        }

        private static int FreeCellsAmount()
        {
            int count = 0;

            foreach(bool cell in abstackleMap)
            {
                if (!cell)
                {
                    count++;
                }
            }

            return count;
        }

        private static void DrawFigures(int figuresAmount)
        {
            Random random = new Random();

            for (int i = 0; i < figuresAmount; i++)
            {
                switch (random.Next(3))
                {
                    case 0:
                        DrawLine(random.Next(2, 10));
                        break;
                    case 1:
                        DrawSquare(random.Next(3, 10));
                        break;
                    case 2:
                        DrawParallelogram(random.Next(3, 10));
                        break;
                    case 3:
                        DrawTriangle(random.Next(3, 10));
                        break;
                }
            }
        }

        private static void DrawLine(int size)
        {
            Random random = new Random();
            Console.ForegroundColor = (ConsoleColor)random.Next(1, 14);
            Point point = new Point(random.Next(80 - size), random.Next(25));

            for (int i = 0; i < size; i++)
            {
                Console.SetCursorPosition(point.X + i, point.Y);
                abstackleMap[point.X + i, point.Y] = true;
                Console.Write('=');
            }
        }

        private static void DrawSquare(int size)
        {
            Random random = new Random();
            Console.ForegroundColor = (ConsoleColor)random.Next(1, 14);
            Point point = new Point(random.Next(80 - size), random.Next(25 - size));

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.SetCursorPosition(point.X + i, point.Y + j);
                    abstackleMap[point.X + i, point.Y + j] = true;
                    Console.Write('ם');
                }
            }

        }
        private static void DrawParallelogram(int size)
        {
            Random random = new Random();
            Console.ForegroundColor = (ConsoleColor)random.Next(1, 14);
            Point point = new Point(random.Next(79 - size * 2), random.Next(25 - size));

            for (int i = 0; i < size; i++)
                for (int j = i; j < size + i; j++)
                {
                    Console.SetCursorPosition(point.X + j, point.Y + i);
                    abstackleMap[point.X + j, point.Y + i] = true;
                    Console.Write('ם');
                }
        }
        private static void DrawTriangle(int size)
        {
            {
                Random random = new Random();
                Console.ForegroundColor = (ConsoleColor)random.Next(1, 14);
                Point point = new Point(random.Next(80 - size), random.Next(25 - size));

                for (int i = 0; i < size; i++)
                    for (int j = 0; j < i + 1; j++)
                    {
                        Console.SetCursorPosition(point.X + i, point.Y + j);
                        abstackleMap[point.X + i, point.Y + j] = true;
                        Console.Write('#');
                    }
            }
        }
    }
}