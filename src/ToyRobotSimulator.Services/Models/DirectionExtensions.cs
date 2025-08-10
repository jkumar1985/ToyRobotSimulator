namespace ToyRobotSimulator.Service.Models
{
    public static class DirectionExtensions
    {
        public static Direction TurnLeft(this Direction current)
        {
            return current switch
            {
                Direction.NORTH => Direction.WEST,
                Direction.WEST => Direction.SOUTH,
                Direction.SOUTH => Direction.EAST,
                Direction.EAST => Direction.NORTH,
                _ => current
            };
        }

        public static Direction TurnRight(this Direction current)
        {
            return current switch
            {
                Direction.NORTH => Direction.EAST,
                Direction.EAST => Direction.SOUTH,
                Direction.SOUTH => Direction.WEST,
                Direction.WEST => Direction.NORTH,
                _ => current
            };
        }
    }
}
