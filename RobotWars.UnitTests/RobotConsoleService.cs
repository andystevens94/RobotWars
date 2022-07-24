namespace RobotWars.UnitTests
{
	public class RobotConsoleServiceTests
	{
		[Theory]
		[InlineData(5, 5, "mrMLLl", "N", "0", "0")]
		[InlineData(10, 10, "rR", "S", "1", "9")]
		[InlineData(361, 1934, "llrlLmrRrmmmLrRrmRM", "E", "361", "1934")]
		[InlineData(1, 38434, "LlllmmRLrlLrllrRlrRrLL", "W", "1", "20434")]
		[InlineData(1, 1, "lRLrllrRlrRrLL", "S", "0", "1")]
		[InlineData(1, 1, "llrrmm", "S", "0", "0")]
		public void RobotConsoleReturnsValidObject(int width, int height, params string[] userInput)
		{
			var battleArena = new BattleArena(width, height);
			IConsole console = GetConsoleWrapper(userInput);

			RobotConsoleService robotConsoleService = new RobotConsoleService(battleArena, console);
			var robot = robotConsoleService.GetRobot();

			robot.Should().NotBeNull();
		}

		[Theory]
		[InlineData(5, 5, "A", "N", "5", "5")]
		[InlineData(25, 34, "LRM", "Q", "5", "5")]
		[InlineData(283, 3455, "LRM", "N", "284", "5")]
		[InlineData(23, 63, "LRM", "N", "5", "64")]
		[InlineData(1, 1, "LRM", "N", "-1", "0")]
		[InlineData(1, 1, "LRM", "N", "1", "-1")]
		[InlineData(10, 10, "LRM", "B", "1", "5")]
		public void RobotConsolThrowInvalidOpException(int width, int height, params string[] userInput)
		{
			var battleArena = new BattleArena(width, height);
			IConsole console = GetConsoleWrapper(userInput);

			RobotConsoleService robotConsoleService = new RobotConsoleService(battleArena, console);

			// Use InvalidOperationException to check the validation as the method will continue until Queue of string in the ConsoleWrapper will run out of items
			Assert.Throws<System.InvalidOperationException>(() => robotConsoleService.GetRobot());
		}

		private IConsole GetConsoleWrapper(params string[] userInput)
		{
			var inputs = new Queue<string>(userInput);
			return new ConsoleWrapper(inputs);
		}
	}
}