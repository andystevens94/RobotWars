namespace RobotWars.UnitTests
{
	public class BattleArenaTests
	{
		[Theory]
		[InlineData(5, 5)]
		[InlineData(0, 0)]
		[InlineData(1, 543)]
		[InlineData(455, 5)]
		[InlineData(-5, -5)]
		public void CanCreateBattleArena(int width, int height)
		{
			BattleArena battleArena = new BattleArena(width, height);
			battleArena.Should().NotBeNull();
		}

		[Theory]
		[InlineData(5, 5, 'e', 3, 2, "LRM")]
		[InlineData(5, 5, 'e', 1, 5, "MLR")]
		public void CanCreateBattleArenaWithRobots(int width, int height, char heading, int xCoord, int yCoord, string commands)
		{
			List<Robot> robotList = new List<Robot>()
			{
				new Robot(RobotService.CharToRobotHeading(heading), new Point(xCoord, yCoord), RobotService.StringToCommandQueue(commands)),
				new Robot(RobotService.CharToRobotHeading(heading), new Point(0, 0), RobotService.StringToCommandQueue(commands))
			};

			BattleArena battleArena = new BattleArena(width, height, robotList);
			battleArena.Should().NotBeNull();
		}

		[Theory]
		[InlineData(1, true)]
		[InlineData(5, true)]
		[InlineData(1000, true)]
		[InlineData(99999999, true)]
		[InlineData(0, false)]
		[InlineData(-1, false)]
		public void CheckBattleArenaValidation(int value, bool expected)
		{
			BattleArenaValidation.WidthHeightValidation(value).Should().Be(expected);
		}
	}
}