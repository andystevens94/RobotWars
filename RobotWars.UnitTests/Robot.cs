namespace RobotWars.UnitTests
{
	public class RobotTests
	{
		[Theory]
		[InlineData('S', 5, 5, "asdsadasd")]
		[InlineData('b', 345, -43, "njksjwkmcwe")]
		public void CanCreateRobot(char heading, int x, int y, string commands)
		{
			var robot = RobotService.CreateRobot(heading, x, y, commands);//.Should().NotBeNull();
			robot.Heading.Should().Be(heading);
			robot.Coords.X.Should().Be(x);
			robot.Coords.Y.Should().Be(y);
			robot.Commands.Should().BeEquivalentTo(new Queue<char>(commands));
		}

		[Theory]
		[InlineData('S', 5, 5, "asdsadasd")]
		[InlineData('b', 345, -43, "njksjwkmcwe")]
		public void CanCreateRobot2(char heading, int x, int y, string commands)
		{
			var serviceRobot = RobotService.CreateRobot(heading, x, y, commands);
			var newRobot = new Robot(heading, new Point(x, y), new Queue<char>(commands));
			serviceRobot.Should().BeEquivalentTo(newRobot);
		}

		//
		//[Theory]
		//[InlineData('S', 5, 5, "asdsadasd")]
		//public void CanCreateRobot2(char heading, Point y, string commands)
		//{
		//	Robot robot = new Robot();
		//}
	}
}