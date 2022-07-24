namespace RobotWars.UnitTests
{
	public class RobotServiceTests
	{
		[Theory]
		[InlineData('N', RobotHeading.North)]
		[InlineData('E', RobotHeading.East)]
		[InlineData('S', RobotHeading.South)]
		[InlineData('W', RobotHeading.West)]
		public void CharToRobotHeadingReturnsCorrectEnum(char value, RobotHeading expected)
		{
			RobotHeading robotHeading = RobotService.CharToRobotHeading(value);
			robotHeading.Should().Be(expected);
		}

		[Theory]
		[InlineData('Q')]
		[InlineData('m')]
		[InlineData('1')]
		[InlineData(' ')]
		[InlineData('A')]
		public void CharToRobotHeadingThrowsException(char value)
		{
			Func<RobotHeading> func = () => RobotService.CharToRobotHeading(value);
			func.Should().Throw<ArgumentException>();
		}

		[Theory]
		[InlineData("MLR", RobotCommand.Move, RobotCommand.Left, RobotCommand.Right)]
		[InlineData("LRM", RobotCommand.Left, RobotCommand.Right, RobotCommand.Move)]
		[InlineData("LLL", RobotCommand.Left, RobotCommand.Left, RobotCommand.Left)]
		[InlineData("M", RobotCommand.Move)]
		public void StringToCommandQueueReturnsQueue(string value, params RobotCommand[] expected)
		{
			Queue<RobotCommand> robotCommands = RobotService.StringToCommandQueue(value);
			robotCommands.Should().BeEquivalentTo(expected);
		}

		[Theory]
		[InlineData("sadjknfew")]
		[InlineData(" ")]
		[InlineData("1")]
		[InlineData("mmmmmmmlllllrrrrrrrv")]
		[InlineData("mmmmmmmlllllrrrrrrr ")]
		public void StringToCommandQueueThrowsException(string value)
		{
			Func<Queue<RobotCommand>> func = () => RobotService.StringToCommandQueue(value);
			func.Should().Throw<ArgumentException>();
		}

		[Theory]
		[InlineData('M', RobotCommand.Move)]
		[InlineData('L', RobotCommand.Left)]
		[InlineData('R', RobotCommand.Right)]
		[InlineData('m', RobotCommand.Move)]
		[InlineData('l', RobotCommand.Left)]
		[InlineData('r', RobotCommand.Right)]
		public void CharToRobotCommandReturnsQueue(char value, RobotCommand expected)
		{
			var robotCommand = RobotService.CharToRobotCommand(value);
			robotCommand.Should().Be(expected);
		}

		[Theory]
		[InlineData('x')]
		[InlineData(' ')]
		[InlineData('/')]
		[InlineData('3')]
		[InlineData('h')]
		[InlineData('v')]
		public void CharToRobotCommandThrowsException(char value)
		{
			Func<RobotCommand> func = () => RobotService.CharToRobotCommand(value);
			func.Should().Throw<ArgumentException>();
		}
	}
}