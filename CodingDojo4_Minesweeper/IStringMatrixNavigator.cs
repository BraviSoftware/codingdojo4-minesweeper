namespace CodingDojo4_Minesweeper
{
    public interface IStringMatrixNavigator
    {
        int Dimension();
        void Load(string input);
        bool IsPositionInFirstRow(int pos);
        bool IsPositionInLastRow(int pos);
        bool IsPositionInLeftBorder(int position);
        bool IsPositionInRightBorder(int position);
        char? GetValueOnTopOf(int pos);
        char? GetValueOnBelow(int pos);
        char? GetValueOnLeft(int pos);
        char? GetValueOnRight(int pos);
        char? GetValueOnTopRight(int pos);
        char? GetValueOnTopLeft(int pos);
        char? GetValueOnBelowLeft(int pos);
        char? GetValueOnBelowRight(int pos);
    }
}