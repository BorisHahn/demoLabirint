namespace demoLabirint
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int playerX = 1;
            int playerY = 1;
            ConsoleRenderer renderer = new ConsoleRenderer();
            ConsoleInput input = new ConsoleInput();

            SetMapPixels(GameData.GetInstance().Map, renderer);

            Player player = new Player(new Vector2(playerX, playerY), renderer, input);
            VerticalObstacle obstacle = new VerticalObstacle(new Vector2(5, 1), '!', renderer);
            SmartEnemy enemy = new SmartEnemy(new Vector2(8, 8), '$', renderer, player);

            Units units = new Units();
            units.Add(player);
            units.Add(obstacle);
            units.Add(enemy);

            renderer.Render();
            ConsoleKeyInfo keyInfo;
            while (true)
            {
                input.Update();
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
                    if (player.Position.Equals(unit.Position))
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
