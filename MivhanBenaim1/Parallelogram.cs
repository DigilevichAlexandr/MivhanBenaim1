using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace MivhanBenaim1
{
    public class Parallelogram : Figure
    {
        public Parallelogram(int size)
            : base(size, new Point(StaticRandom.Next(79 - size * 2), StaticRandom.Next(25 - size)))
        { }

        public override void Draw(bool[,] abstackleMap)
        {
            for (int i = 0; i < _size; i++)
                for (int j = i; j < _size + i; j++)
                {
                    Console.SetCursorPosition(_place.X + j, _place.Y + i);
                    abstackleMap[_place.X + j, _place.Y + i] = true;
                    Console.Write('ם');
                }
        }
    }
}
