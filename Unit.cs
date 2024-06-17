using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demoLabirint
{
    public abstract class Unit
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        private ConsoleRenderer _renderer;
        private char _symbol;

        public Unit(int startX, int startY, char symbol, ConsoleRenderer renderer)
        {
            X = startX;
            Y = startY;
            _symbol = symbol;
            _renderer = renderer;
            _renderer.SetPixel(X, Y, _symbol);
        }

        public virtual bool TryMoveLeft(char[,] map)
        {
            return TryChangePosition(X - 1, Y, map);
        }

        public virtual bool TryMoveRight(char[,] map)
        {
            return TryChangePosition(X + 1, Y, map);
        }

        public virtual bool TryMoveUp(char[,] map)
        {
            return TryChangePosition(X, Y - 1, map);
        }

        public virtual bool TryMoveDown(char[,] map)
        {
            return TryChangePosition(X, Y + 1, map);
        }

        protected virtual bool TryChangePosition(int newX, int newY, char[,] map)
        {
            if (map[newX, newY] == '#')
                return false;
            _renderer.SetPixel(X, Y, ' ');
            X = newX;
            Y = newY;
            _renderer.SetPixel(X, Y, _symbol);
            return true;
        }

        public abstract void Update();
    }
}
