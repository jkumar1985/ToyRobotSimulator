using ToyRobotSimulator.Service.Models;

namespace ToyRobotSimulator.Service.Services
{
    public class RobotService
    {
        private readonly Robot _robot = new();
        private const int TableSize = 5;

        public void ExecuteCommand(string command)
        {
            if (string.IsNullOrWhiteSpace(command)) return;

            var parts = command.Trim().Split(' ');
            var action = parts[0].ToUpper();

            switch (action)
            {
                case "PLACE":
                    if (parts.Length < 2) return;
                    var args = parts[1].Split(',');
                    if (args.Length != 3) return;

                    if (int.TryParse(args[0], out var x) &&
                        int.TryParse(args[1], out var y) &&
                        Enum.TryParse(args[2], true, out Direction dir) &&
                        IsValidPosition(x, y))
                    {
                        _robot.Place(new Position(x, y), dir);
                    }
                    break;

                case "MOVE":
                    if (_robot.IsPlaced)
                    {
                        var newPos = _robot.Position.Move(_robot.Direction);
                        if (IsValidPosition(newPos.X, newPos.Y))
                            _robot.Move();
                    }
                    break;

                case "LEFT":
                    if (_robot.IsPlaced) _robot.TurnLeft();
                    break;

                case "RIGHT":
                    if (_robot.IsPlaced) _robot.TurnRight();
                    break;

                case "REPORT":
                    if (_robot.IsPlaced)
                        Console.WriteLine(_robot.Report());
                    break;
            }


        }

        private static bool IsValidPosition(int x, int y) =>
            x >= 0 && x < TableSize && y >= 0 && y < TableSize;
    }
}
