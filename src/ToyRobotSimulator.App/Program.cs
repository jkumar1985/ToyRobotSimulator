using ToyRobotSimulator.Service.Services;

var service = new RobotService();

if (args.Length > 0 && File.Exists(args[0]))
{
    Console.WriteLine($"Running commands from file: {args[0]}");
    foreach (var line in File.ReadAllLines(args[0]))
    {
        service.ExecuteCommand(line);
    }
}
else
{
    Console.WriteLine("Toy Robot Simulator. Enter commands, type EXIT to quit:");

    string input;
    while ((input = Console.ReadLine())?.ToUpper() != "EXIT")
    {
        service.ExecuteCommand(input);
    }
}
