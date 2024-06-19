namespace demoLabirint
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[,] map = new[,]
            {
                {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#',},
                {'#', ' ', ' ', '#', ' ', '#', ' ', ' ', ' ', '#',},
                {'#', ' ', ' ', '#', ' ', '#', ' ', ' ', ' ', '#',},
                {'#', ' ', ' ', '#', ' ', '#', ' ', ' ', ' ', '#',},
                {'#', ' ', ' ', '#', ' ', '#', ' ', ' ', ' ', '#',},
                {'#', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', '#',},
                {'#', ' ', ' ', '#', ' ', '#', ' ', '#', '#', '#',},
                {'#', ' ', ' ', '#', ' ', '#', ' ', ' ', ' ', '#',},
                {'#', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', '#',},
                {'#', '#', '#', '#', '#', '#', '#', '#', '#', '#',},
            };

            int playerX = 1;
            int playerY = 1;
            ConsoleRenderer renderer = new ConsoleRenderer();
            SetMapPixels(map, renderer);

            Player player = new Player(playerX, playerY, renderer, map);
            VerticalObstacle obstacle = new VerticalObstacle(5, 1, '!', renderer, map);
            SmartEnemy enemy = new SmartEnemy(8, 8, '$', renderer, map, player);

            Units units = new Units();
            units.Add(player);
            units.Add(obstacle);
            units.Add(enemy);

            renderer.Render();
            ConsoleKeyInfo keyInfo;
            while (true)
            {
                foreach(Unit unit in units)
                {
                    unit.Update();
                }
                    
                renderer.Render();

                Thread.Sleep(200);

                foreach (Unit unit in units)
                {
                    if (unit == player)
                        continue;
                    if (player.X == unit.X && player.Y == unit.Y)
                        GameOver();
                }
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
