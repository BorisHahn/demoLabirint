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
        public Player(int startX, int startY, ConsoleRenderer renderer) : 
            base(startX, startY, '@', renderer)
        {
        }
        public override void Update()
        {
            ConsoleKeyInfo keyInfo;
            if (Console.KeyAvailable)
            {
                keyInfo = Console.ReadKey();

                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        TryMoveUp();
                        break;
                    case ConsoleKey.DownArrow:
                        TryMoveDown();
                        break;
                    case ConsoleKey.RightArrow:
                        TryMoveRight();
                        break;
                    case ConsoleKey.LeftArrow:
                        TryMoveLeft();
                        break;
                }
            }
        }
    }
}
