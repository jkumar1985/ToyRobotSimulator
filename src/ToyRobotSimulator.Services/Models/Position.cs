namespace ToyRobotSimulator.Service.Models
{
    public class Position
    {
        public int X { get; }
        public int Y { get; }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Position Move(Direction direction)
        {
            switch (direction)
            {
                case Direction.NORTH:
                    return new Position(X, Y + 1);

                case Direction.EAST:
                    return new Position(X + 1, Y);

                case Direction.SOUTH:
                    return new Position(X, Y - 1);

                case Direction.WEST:
                    return new Position(X - 1, Y);

                default:
                    return this; 
            }
        }
    }

}
