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
            Movable player = new Movable(playerX, playerY, '@', renderer);

            Movable obstacle = new Movable(5, 1, '!', renderer);
            bool obstacleDownDir = true;

            renderer.Render();
            ConsoleKeyInfo keyInfo;
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    keyInfo = Console.ReadKey();
                
                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.UpArrow:
                            player.TryMoveUp(map);
                            break;
                        case ConsoleKey.DownArrow:
                            player.TryMoveDown(map);
                            break;
                        case ConsoleKey.RightArrow:
                            player.TryMoveRight(map);
                            break;
                        case ConsoleKey.LeftArrow:
                            player.TryMoveLeft(map);
                            break;
                    }
                }

                if (obstacleDownDir)
                {
                    if (!obstacle.TryMoveDown(map))
                        obstacleDownDir = false;
                }
                else
                {
                    if (!obstacle.TryMoveUp(map))
                        obstacleDownDir = true;
                }

                renderer.Render();

                Thread.Sleep(200);

                if (player.X == obstacle.X && player.Y == obstacle.Y)
                    GameOver();
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

        static void GameOver()
        {
            Environment.Exit(0);
        }
    }
}
