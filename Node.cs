using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demoLabirint
{
    public class Node
    {
        public Vector2 Position;
        public int Cost = 10;
        public int Estimate;
        public int Value;
        public Node Parent;

        public Node(Vector2 position)
        {
            Position = position;
        }

        public void CalculateEstimate(Vector2 targetPosition)
        {
            Estimate = Math.Abs(Position.X - targetPosition.X) + Math.Abs(Position.Y - targetPosition.Y);
        }

        public void CalculateValue()
        {
            Value = Cost + Estimate;
        }

        public override bool Equals(object? obj)
        {
            if (obj is not Node node)
                return false;
            return Position.Equals(node.Position);
        }
    }
}
