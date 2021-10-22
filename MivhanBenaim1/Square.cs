using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace MivhanBenaim1
{
    public class Square : Figure
    {
        public Square(int size)
            : base(size, new Point(StaticRandom.Next(80 - size), StaticRandom.Next(25 - size)))
        { }

        public override void Draw(bool[,] abstackleMap)
        {
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    Console.SetCursorPosition(_place.X + i, _place.Y + j);
                    abstackleMap[_place.X + i, _place.Y + j] = true;
                    Console.Write('ם');
                }
            }
        }
    }
}
