namespace RobotWars.UnitTests
{
	public class RobotTests
	{
		[Theory]
		[InlineData('S', 5, 5, "LRM")]
		[InlineData('N', 345, -43, "MMMRRLLL")]
		public void CanCreateRobot(char heading, int x, int y, string commands)
		{
			var serviceRobot = RobotService.CreateRobot(heading, x, y, commands);
			var newRobot = new Robot(RobotService.CharToRobotHeading(heading), new Point(x, y), RobotService.StringToCommandQueue(commands));
			serviceRobot.Should().BeEquivalentTo(newRobot);
		}

		[Theory]
		[InlineData('N', true)]
		[InlineData('S', true)]
		[InlineData('E', true)]
		[InlineData('W', true)]
		[InlineData('n', true)]
		[InlineData('s', true)]
		[InlineData('e', true)]
		[InlineData('w', true)]
		[InlineData('(', false)]
		[InlineData('1', false)]
		[InlineData('a', false)]
		[InlineData('z', false)]
		[InlineData('\'', false)]
		[InlineData('^', false)]
		public void RobotCheckHeadingValidation(char heading, bool expected)
		{
			RobotValidation.HeadingValidation(heading).Should().Be(expected);
		}

		[Theory]
		[InlineData("LRM", true)]
		[InlineData("lmr", true)]
		[InlineData("mmm", true)]
		[InlineData("Lll", true)]
		[InlineData("RRr", true)]
		[InlineData("", false)]
		[InlineData(" ", false)]
		[InlineData("a", false)]
		[InlineData("LMRb", false)]
		[InlineData("LMR ", false)]
		[InlineData(" LMR", false)]
		public void RobotCheckCommandsValidation(string commands, bool expected)
		{
			RobotValidation.CommandsValidation(commands).Should().Be(expected);
		}

		[Theory]
		[InlineData(5, 5, 5, true)]
		[InlineData(15, 15, 15, true)]
		[InlineData(1, 1, 1, true)]
		[InlineData(5, 5, 0, true)]
		[InlineData(1, 5, 1, true)]
		[InlineData(5, 1, 5, true)]
		[InlineData(5, 5, 6, false)]
		[InlineData(1, 5, 2, false)]
		[InlineData(5, 5, -1, false)]
		public void RobotCheck_X_CoordinateValidation(int arenaWidth, int arenaHeight, int xCoord, bool expected)
		{
			var battleArena = new BattleArena(arenaWidth, arenaHeight);
			RobotValidation.xCoordinateValidation(xCoord, battleArena).Should().Be(expected);
		}

		[Theory]
		[InlineData(5, 5, 5, true)]
		[InlineData(15, 15, 5, true)]
		[InlineData(1, 1, 1, true)]
		[InlineData(1, 1, 0, true)]
		[InlineData(1, 5, 5, true)]
		[InlineData(5, 1, 1, true)]
		[InlineData(5, 1, 2, false)]
		[InlineData(5, 5, 6, false)]
		[InlineData(5, 5, -1, false)]
		public void RobotCheck_Y_CoordinateValidation(int arenaWidth, int arenaHeight, int yCoord, bool expected)
		{
			var battleArena = new BattleArena(arenaWidth, arenaHeight);
			RobotValidation.yCoordinateValidation(yCoord, battleArena).Should().Be(expected);
		}
	}
}