using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demoLabirint
{
    public class UnitsEnumerator : IEnumerator
    {
        private List<Unit> _units;
        private int _position = -1;

        public UnitsEnumerator(List<Unit> units)
        {
            _units = units;
        }

        public object Current
        {
            get
            {
                return _units[_position];
            }
        }

        public bool MoveNext()
        {
            if ( _position < _units.Count - 1)
            {
                _position++;
                return true;
            }

            return false;
        }

        public void Reset()
        {
            _position = -1;
        }
    }
}
