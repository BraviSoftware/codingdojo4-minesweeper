using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingDojo4_Minesweeper
{
    public class Minesweeper
    {
        private char[] _field;

        public string Field
        {
            get
            {
                return new string(_field);
            }    
        }

        public Minesweeper()
        {
            _field = "................".ToCharArray();
        }

        public void Load(string minefield)
        {
            _field = minefield.ToCharArray();
        }

        public string Solve()
        {
            return  Field.Replace(".", "0");
        }
    }
}
