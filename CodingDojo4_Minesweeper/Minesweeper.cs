using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingDojo4_Minesweeper
{
    public class Minesweeper
    {
        private readonly IStringMatrixNavigator _navigator;
        private const string DefaultField = "................";

        private char[] _field;

        public string Field
        {
            get
            {
                return new string(_field);
            }    
        }

        public Minesweeper(IStringMatrixNavigator navigator)
        {
            _navigator = navigator;
            Load(DefaultField);
        }

        public void Load(string minefield)
        {
            _field = minefield.ToCharArray();
            _navigator.Load(minefield);
        }

        public string Solve()
        {
            string solution = "";
            for (var pos = 0; pos < _field.Length; pos++)
            {
                int countBombs = 0;
                //bomb: mark it and move on
                if (_field[pos] == '*')
                {
                    solution += "*";
                    continue;
                }

                if (_navigator.GetValueOnTopOf(pos) == '*')
                    countBombs++;
                if (_navigator.GetValueOnTopLeft(pos) == '*')
                    countBombs++;
                if (_navigator.GetValueOnTopRight(pos) == '*')
                    countBombs++;
                if (_navigator.GetValueOnLeft(pos) == '*')
                    countBombs++;
                if (_navigator.GetValueOnRight(pos) == '*')
                    countBombs++;
                if (_navigator.GetValueOnBelow(pos) == '*')
                    countBombs++;
                if (_navigator.GetValueOnBelowLeft(pos) == '*')
                    countBombs++;
                if (_navigator.GetValueOnBelowRight(pos) == '*')
                    countBombs++;

                solution += countBombs.ToString();
            }
            return solution;
        }
    }
}
