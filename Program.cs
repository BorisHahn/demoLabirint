namespace demoLabirint
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[,] map = new[,]
            {
                {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#',},
                {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#',},
                {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#',},
                {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#',},
                {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#',},
                {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#',},
                {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#',},
                {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#',},
                {'#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#',},
                {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#',},
            };

            int playerX = 1;
            int playerY = 1;
            ConsoleRenderer renderer = new ConsoleRenderer();

            SetMapPixels(map, renderer);
            SetPlayer(playerX, playerY, renderer);

            Console.CursorVisible = false;

            while (true)
            {
                renderer.Render();
            }

        }

        static void SetMapPixels(char[,] map, ConsoleRenderer renderer)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    renderer.SetPixel(i, j, map[i, j]);
                }
                Console.WriteLine();
            }
        }

        static void SetPlayer(int x, int y, ConsoleRenderer renderer)
        {
            renderer.SetPixel(x, y, '@');
        }
    }
}
