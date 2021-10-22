using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace MivhanBenaim1
{
    public class BoardService : IBoardService
    {
        public bool[,] AbstackleMap { get; set; } = new bool[80, 25];
        private FigureFabric _figureFabric = new FigureFabric();

        public void DrawFigures(int figuresAmount)
        {
            for (int i = 0; i < figuresAmount; i++)
            {
                FigureTypes type = (FigureTypes)StaticRandom.Next(4);
                var figure = _figureFabric.GetFigure(type);
                Console.ForegroundColor = (ConsoleColor)StaticRandom.Next(1, 14);
                figure.Draw(AbstackleMap);
            }
        }
    }
}
