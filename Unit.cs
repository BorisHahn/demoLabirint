using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demoLabirint
{
    public abstract class Unit
    {
        public Vector2 Position { get; private set; }
        private ConsoleRenderer _renderer;
        private char _symbol;

        public Unit(Vector2 startPosition, char symbol, ConsoleRenderer renderer)
        {
            Position = startPosition;
            _symbol = symbol;
            _renderer = renderer;
            _renderer.SetPixel(Position.X, Position.Y, _symbol);
        }

        public virtual bool TryMoveLeft()
        {
            return TryChangePosition(new Vector2(Position.X - 1, Position.Y));
        }

        public virtual bool TryMoveRight()
        {
            return TryChangePosition(new Vector2(Position.X + 1, Position.Y));
        }

        public virtual bool TryMoveUp()
        {
            return TryChangePosition(new Vector2(Position.X, Position.Y - 1));
        }

        public virtual bool TryMoveDown()
        {
            return TryChangePosition(new Vector2(Position.X, Position.Y + 1));
        }

        protected virtual bool TryChangePosition(Vector2 newPosition)
        {
            if (GameData.GetInstance().Map[newPosition.X, newPosition.Y] == '#')
                return false;
            _renderer.SetPixel(Position.X, Position.Y, ' ');
            Position = newPosition;
            _renderer.SetPixel(Position.X, Position.Y, _symbol);
            return true;
        }

        public abstract void Update();
    }
}
