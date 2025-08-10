using ToyRobotSimulator.Service.Services;

namespace ToyRobotSimulator.Tests
{
    public class RobotServiceTests
    {
        [Fact]
        public void Place_Move_Report_ShouldMatchExpected()
        {
            var service = new RobotService();
            var sw = new StringWriter();
            Console.SetOut(sw);

            service.ExecuteCommand("PLACE 0,0,NORTH");
            service.ExecuteCommand("MOVE");
            service.ExecuteCommand("REPORT");

            var output = sw.ToString().Trim();
            Assert.Equal("0,1,NORTH", output);
        }

        [Fact]
        public void Left_Turn_ShouldMatchExpected()
        {
            var service = new RobotService();
            var sw = new StringWriter();
            Console.SetOut(sw);

            service.ExecuteCommand("PLACE 0,0,NORTH");
            service.ExecuteCommand("LEFT");
            service.ExecuteCommand("REPORT");

            var output = sw.ToString().Trim();
            Assert.Equal("0,0,WEST", output);
        }

        [Fact]
        public void Complex_Command_Sequence()
        {
            var service = new RobotService();
            var sw = new StringWriter();
            Console.SetOut(sw);

            service.ExecuteCommand("PLACE 1,2,EAST");
            service.ExecuteCommand("MOVE");
            service.ExecuteCommand("MOVE");
            service.ExecuteCommand("LEFT");
            service.ExecuteCommand("MOVE");
            service.ExecuteCommand("REPORT");

            var output = sw.ToString().Trim();
            Assert.Equal("3,3,NORTH", output);
        }
    }
}
