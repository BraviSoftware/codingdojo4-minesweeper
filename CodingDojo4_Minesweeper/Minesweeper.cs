using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingDojo4_Minesweeper
{
    public class Minesweeper
    {
        public List<char> Field { get; private set; }
        private List<int> BombPositions { get; set; }
        private readonly int _squareMatrixDimension;
        private readonly int _squareMatrixLength;

        public Minesweeper()
        {
            BombPositions = new List<int>();
            Field = "0000000000000000".ToList();
            _squareMatrixDimension = (int)Math.Sqrt(Field.Count);
            _squareMatrixLength = Field.Count;
        }

        public void AddBombToFieldAt(int index)
        {
            Field[index] = '*';
            BombPositions.Add(index);
        }

        public List<char> Solve()
        {
            /*
             * 0    1   2   3
             * 4    5   6   7
             * 8    9   10  11
             * 12   13  14  15
             */
            FindBombs();
            System.Diagnostics.Debug.WriteLine(new string(Field.ToArray()));
            return Field;
        }

        public void FindBombs()
        {
            foreach (var pos in BombPositions)
            {
                bool isOnTop = IsOnTop(pos); //doesn't need to calculate top
                bool isOnTheLastRow = IsOnBottom(pos); //doesn't need to calculate bottom
                bool isOnLeftColumn = IsOnLeftColumn(pos);
                bool isOnRightColumn = IsOnRightColumn(pos);
                var top = pos - _squareMatrixDimension;
                var down = pos + _squareMatrixDimension;
                var adjacentPositions = new[]
                        {
                            isOnTop || isOnLeftColumn ? -1 : top - 1,  //top left
                            isOnTop ? -1 :top,
                            isOnTop || isOnRightColumn ? -1 :top + 1,  //top right
                            isOnLeftColumn ? -1 : pos - 1,  //left
                            isOnRightColumn ? -1 : pos + 1,  //right
                            isOnTheLastRow || isOnLeftColumn ? -1 : down - 1,  //down left
                            isOnTheLastRow ? -1 : down,
                            isOnTheLastRow || isOnRightColumn ? -1 : down + 1,  //down right
                        };
                foreach (var adjacentPosition in adjacentPositions)
                {
                    if (adjacentPosition >= 0 && adjacentPosition < _squareMatrixLength)
                    {
                        var item = Field[adjacentPosition].ToString();
                        if (!item.Equals("*"))
                            Field[adjacentPosition] = (Convert.ToInt32(item) + 1).ToString()[0];
                    }
                }
            }
        }

        private bool IsOnTop(int pos)
        {
            return pos >= 0 && pos < _squareMatrixDimension;
        }

        private bool IsOnBottom(int pos)
        {
            var lastRowStartPos = _squareMatrixLength - _squareMatrixDimension;
            return pos >= lastRowStartPos && pos < _squareMatrixLength;
        }

        private bool IsOnLeftColumn(int pos)
        {
            var leftColumnPositions = new List<int>();
            for (int i = 0; i < _squareMatrixLength; i++)
                if (i % _squareMatrixDimension == 0)
                    leftColumnPositions.Add(i);
            return leftColumnPositions.Contains(pos);
        }

        private bool IsOnRightColumn(int pos)
        {
            var rightColumnPositions = new List<int>();
            for (int i = 0; i < _squareMatrixLength; i++)
                if (i % _squareMatrixDimension == _squareMatrixDimension - 1)
                    rightColumnPositions.Add(i);
            return rightColumnPositions.Contains(pos);
        }
    }
}