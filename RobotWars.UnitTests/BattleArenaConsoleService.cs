namespace RobotWars.UnitTests
{
	public class BattleArenaConsoleServiceTests
	{
		[Theory]
		[InlineData("5", "5")]
		[InlineData("1", "1")]
		[InlineData("100000", "9999999")]
		public void BattleArenaConsoleReturnsValidObject(params string[] userInput)
		{
			IConsole console = GetConsoleWrapper(userInput);
			var battleArenaConsoleService = new BattleArenaConsoleService(console);
			battleArenaConsoleService.GetBattleArena().Should().NotBeNull();
		}

		[Theory]
		[InlineData("-1", "-1")]
		[InlineData("0", "0")]
		[InlineData("0", "10")]
		[InlineData("10", "0")]
		public void BattleArenaThrowInvalidOpException(params string[] userInput)
		{
			IConsole console = GetConsoleWrapper(userInput);
			var battleArenaConsoleService = new BattleArenaConsoleService(console);

			// Use InvalidOperationException to check the validation as the method will continue until Queue of string in the ConsoleWrapper will run out of items
			Assert.Throws<System.InvalidOperationException>(() => battleArenaConsoleService.GetBattleArena());
		}

		private IConsole GetConsoleWrapper(params string[] userInput)
		{
			var inputs = new Queue<string>(userInput);
			return new ConsoleWrapper(inputs);
		}
	}
}