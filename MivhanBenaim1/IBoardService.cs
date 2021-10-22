namespace MivhanBenaim1
{
    public interface IBoardService
    {
        public bool[,] AbstackleMap { get; set; }

        public void DrawFigures(int figuresAmount);
    }
}