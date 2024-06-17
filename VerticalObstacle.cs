using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demoLabirint
{
    public class VerticalObstacle : Unit
    {
        private bool _obstacleDownDir = true;
        private char[,] _map;

        public VerticalObstacle(int startX, int startY,char symbol, ConsoleRenderer renderer, char[,] map) :
            base(startX, startY, symbol, renderer)
        {
            _map = map;
        }

        public override void Update()
        {
            if (_obstacleDownDir)
            {
                if (!TryMoveDown(_map))
                    _obstacleDownDir = false;
            }
            else
            {
                if (!TryMoveUp(_map))
                    _obstacleDownDir = true;
            }
        }
    }
}
