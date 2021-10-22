using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace MivhanBenaim1
{
    public class Line : Figure
    {
        public Line(int size)
        : base(size, new Point(StaticRandom.Next(80 - size), StaticRandom.Next(25)))
        { }

        public override void Draw(bool[,] abstackleMap)
        {
            for (int i = 0; i < _size; i++)
            {
                Console.SetCursorPosition(_place.X + i, _place.Y);
                abstackleMap[_place.X + i, _place.Y] = true;
                Console.Write('=');
            }
        }
    }
}
