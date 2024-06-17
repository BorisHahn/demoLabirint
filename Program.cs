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

            Player player = new Player(playerX, playerY, renderer, map);
            VerticalObstacle obstacle = new VerticalObstacle(5, 1, '!', renderer, map);


            Units units = new Units();
            units.Add(player);
            units.Add(obstacle);

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
