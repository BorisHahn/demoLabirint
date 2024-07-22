using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace demoLabirint
{
    public class Player : Unit
    {
        public Player(Vector2 startPosition, ConsoleRenderer renderer, IMoveInput input) : 
            base(startPosition, '@', renderer)
         {
            input.MoveUp += () => TryMoveUp();
            input.MoveDown += () => TryMoveDown();
            input.MoveLeft += () => TryMoveLeft();
            input.MoveRight += () => TryMoveRight();
        }
        public override void Update()
        {
        }
    }
}
