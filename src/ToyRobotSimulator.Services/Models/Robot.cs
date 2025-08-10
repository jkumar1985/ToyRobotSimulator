namespace ToyRobotSimulator.Service.Models
{
    public class Robot
    {
        public Position Position { get; private set; }
        public Direction Direction { get; private set; }
        public bool IsPlaced { get; private set; }

        public void Place(Position position, Direction direction)
        {
            Position = position;
            Direction = direction;
            IsPlaced = true;
        }

        public void Move()
        {
            Position = Position.Move(Direction);
        }

        public void TurnLeft()
        {
            Direction = Direction.TurnLeft();
        }

        public void TurnRight()
        {
            Direction = Direction.TurnRight();
        }

        public string Report() =>
            $"{Position.X},{Position.Y},{Direction}";
    }
}
