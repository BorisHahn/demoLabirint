﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demoLabirint
{
    public class VerticalObstacle : Unit
    {
        private bool _obstacleDownDir = true;

        public VerticalObstacle(int startX, int startY,char symbol, ConsoleRenderer renderer) :
            base(startX, startY, symbol, renderer)
        {
        }

        public override void Update()
        {
            if (_obstacleDownDir)
            {
                if (!TryMoveDown())
                    _obstacleDownDir = false;
            }
            else
            {
                if (!TryMoveUp())
                    _obstacleDownDir = true;
            }
        }
    }
}
