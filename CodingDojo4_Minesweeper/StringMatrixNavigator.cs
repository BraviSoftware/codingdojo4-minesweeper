using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingDojo4_Minesweeper
{
    //totally overkill way to map a 1-dimensional string as as 2-dimensional
    //matrix, just to not use a bidimensional char array
    public class StringMatrixNavigator
    {
        private string _field;

        public int Dimension()
        {
            return (int)Math.Sqrt(_field.Length);
        }

        public void Load(string input)
        {
            _field = input;
        }

        public bool IsPositionInFirstRow(int pos)
        {
            return pos < Dimension();
        }

        public bool IsPositionInLastRow(int pos)
        {
            var dimension = Dimension();
            var ceiling = Math.Ceiling((decimal)(pos + 1) / dimension);
            return ceiling == dimension;
        }

        public bool IsPositionInLeftBorder(int position)
        {
            return position % Dimension() == 0;
        }

        public bool IsPositionInRightBorder(int position)
        {
            var dimension = Dimension();
            return position % dimension == dimension - 1;
        }

        public char? GetValueOnTopOf(int pos)
        {
            var array = _field.ToCharArray();
            return array[pos - Dimension()];
        }

        public char? GetValueOnBelow(int pos)
        {
            var array = _field.ToCharArray();
            return array[pos + Dimension()];
        }

        public char? GetValueOnLeft(int pos)
        {
            if (IsPositionInLeftBorder(pos))
                return null;
            var array = _field.ToCharArray();
            return array[pos - 1];
        }

        public char? GetValueOnRight(int pos)
        {
            if (IsPositionInRightBorder(pos))
                return null;
            var array = _field.ToCharArray();
            return array[pos + 1];
        }

        public char? GetValueOnTopRight(int pos)
        {
            if (IsPositionInFirstRow(pos))
                return null;
            if (IsPositionInRightBorder(pos))
                return null;
            var array = _field.ToCharArray();
            return array[pos - Dimension() + 1];
        }

        public char? GetValueOnTopLeft(int pos)
        {
            if (IsPositionInFirstRow(pos))
                return null;
            if (IsPositionInLeftBorder(pos))
                return null;
            var array = _field.ToCharArray();
            return array[pos - Dimension() - 1];
        }

        public char? GetValueOnBelowLeft(int pos)
        {
            if (IsPositionInLastRow(pos))
                return null;
            if (IsPositionInLeftBorder(pos))
                return null;
            var array = _field.ToCharArray();
            return array[pos + Dimension() - 1];
        }

        public char? GetValueOnBelowRight(int pos)
        {
            if (IsPositionInLastRow(pos))
                return null;
            if (IsPositionInRightBorder(pos))
                return null;
            var array = _field.ToCharArray();
            return array[pos + Dimension() + 1];
        }
    }
}
