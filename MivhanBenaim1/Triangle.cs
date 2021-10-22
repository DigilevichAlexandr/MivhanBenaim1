using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace MivhanBenaim1
{
    public class Triangle : Figure
    {
        public Triangle(int size)
            : base(size, new Point(StaticRandom.Next(80 - size), StaticRandom.Next(25 - size)))
        { }

        public override void Draw(bool[,] abstackleMap)
        {
            for (int i = 0; i < _size; i++)
                for (int j = 0; j < i + 1; j++)
                {
                    Console.SetCursorPosition(_place.X + j, _place.Y + i);
                    abstackleMap[_place.X + j, _place.Y + i] = true;
                    Console.Write('#');
                }
        }
    }
}
