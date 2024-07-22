using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demoLabirint
{
    public class ConsoleInput: IMoveInput
    {
        public event Action MoveUp;
        public event Action MoveDown;
        public event Action MoveLeft;
        public event Action MoveRight;

        public void Update()
        {
            ConsoleKeyInfo keyInfo;
            if (Console.KeyAvailable)
            {
                keyInfo = Console.ReadKey();

                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        MoveUp?.Invoke();
                        break;
                    case ConsoleKey.DownArrow:
                        MoveDown?.Invoke();
                        break;
                    case ConsoleKey.RightArrow:
                        MoveRight?.Invoke();
                        break;
                    case ConsoleKey.LeftArrow:
                        MoveLeft?.Invoke();
                        break;
                }
            }
        }
    }
}
