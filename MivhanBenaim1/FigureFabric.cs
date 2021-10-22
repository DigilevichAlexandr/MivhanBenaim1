using System;
using System.Drawing;

namespace MivhanBenaim1
{
    internal class FigureFabric
    {
        Random randome = new Random();

        public Figure GetFigure(FigureTypes type)
        {
            switch (type)
            {
                case FigureTypes.Line:
                    return new Line(randome.Next(2, 10));
                    break;
                case FigureTypes.Parallelogram:
                    return new Parallelogram(randome.Next(3, 10));
                    break;
                case FigureTypes.Square:
                    return new Square(randome.Next(3, 10));
                    break;
                case FigureTypes.Triangle:
                    return new Triangle(randome.Next(3, 10));
                    break;
                default: return null;
            }
        }
    }
}