using System;
using System.Drawing;
using System.Text;
using System.Threading;

namespace MivhanBenaim1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = new UTF8Encoding();
            Console.CursorVisible = false;
            Console.SetWindowSize(80, 25);
            int moves = 0;
            bool isGameGoing = true;
            Point starPosition = new Point(StaticRandom.Next(80), StaticRandom.Next(25));
            ConsoleKeyInfo key;
            bool goToNextLevel = true;
            int figuresAmount = StaticRandom.Next(3, 6);
            IBoardService boardService = new BoardService();

            while (isGameGoing)
            {
                if (goToNextLevel)
                {
                    boardService.DrawFigures(figuresAmount);
                    goToNextLevel = false;
                    starPosition = new Point(StaticRandom.Next(80), StaticRandom.Next(25));

                    while (boardService.AbstackleMap[starPosition.X, starPosition.Y])
                    {
                        starPosition = new Point(StaticRandom.Next(80), StaticRandom.Next(25));
                    }

                    //panel with text and scores as abstackle
                    for (int i = 0; i < 18; i++)
                    {
                        boardService.AbstackleMap[i, 0] = true;
                    }
                    //second line as abstackle
                    for (int i = 0; i < 10; i++)
                    {
                        boardService.AbstackleMap[i, 1] = true;
                    }
                }

                Console.SetCursorPosition(starPosition.X, starPosition.Y);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write('*');

                //Thread.Sleep(50);

                key = Console.ReadKey(true);
                Console.SetCursorPosition(starPosition.X, starPosition.Y);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write('*');

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (starPosition.Y > 0)
                        {
                            boardService.AbstackleMap[starPosition.X, starPosition.Y] = true;
                            starPosition.Y--;
                            moves++;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (starPosition.Y < 24)
                        {
                            boardService.AbstackleMap[starPosition.X, starPosition.Y] = true;
                            starPosition.Y++;
                            moves++;
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (starPosition.X < 79)
                        {
                            boardService.AbstackleMap[starPosition.X, starPosition.Y] = true;
                            starPosition.X++;
                            moves++;
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        if (starPosition.X > 0)
                        {
                            boardService.AbstackleMap[starPosition.X, starPosition.Y] = true;
                            starPosition.X--;
                            moves++;
                        }
                        break;
                }

                if (boardService.AbstackleMap[starPosition.X, starPosition.Y])
                {
                    if (++figuresAmount == 15)
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
                    Console.CursorVisible = false;
                    boardService.AbstackleMap = new bool[80, 25];
                    moves = 0;
                }

                Console.SetCursorPosition(0, 0);
                Console.ForegroundColor = ConsoleColor.White;
                int freeCellsAmount = FreeCellsAmount(boardService);
                Console.Write("Moves {0, 4} of {1, 4}", moves, freeCellsAmount);
                Console.SetCursorPosition(0, 1);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Figures {0, 2}", figuresAmount);

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

        private static int FreeCellsAmount(IBoardService boardService)
        {
            int count = 0;

            foreach (bool cell in boardService.AbstackleMap)
            {
                if (!cell)
                {
                    count++;
                }
            }

            return count;
        }
    }
}