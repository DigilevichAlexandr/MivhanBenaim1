using System;
using System.Drawing;
using System.Collections.Generic;
using System.Text;

namespace MivhanBenaim1
{
    public abstract class Figure
    {
        protected int _size;
        protected Point _place;

        public Figure(int size, Point place)
        {
            _size = size;
            _place = place;
        }

        public abstract void Draw(bool[,] abstackleMap);
    }
}
