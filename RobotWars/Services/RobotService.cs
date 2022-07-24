using RobotWars.Enums;
using RobotWars.Models;
using RobotWars.Structs;

namespace RobotWars.Services
{
	public static class RobotService
	{
		public static Robot CreateRobot(char headingValue, int x, int y, string commands, BattleArena battleArena)
		{
			Point Point = new Point(x, y);
			Queue<RobotCommand> commandQueue = StringToCommandQueue(commands);
			RobotHeading heading = CharToRobotHeading(headingValue);
			return new Robot(heading, Point, commandQueue, battleArena);
		}

		public static Queue<RobotCommand> StringToCommandQueue(string commands)
		{
			var commandQueue = new Queue<RobotCommand>();
			char[] aCommands = commands.ToArray();
			for (int i = 0; i < aCommands.Length; i++)
			{
				RobotCommand command = CharToRobotCommand(aCommands[i]);
				commandQueue.Enqueue(command);
			}
			return commandQueue;
		}

		public static RobotCommand CharToRobotCommand(char command)
		{
			switch (Char.ToUpper(command))
			{
				case 'L':
					return RobotCommand.Left;

				case 'R':
					return RobotCommand.Right;

				case 'M':
					return RobotCommand.Move;

				default:
					throw new ArgumentException();
			}
		}

		public static RobotHeading CharToRobotHeading(char command)
		{
			switch (Char.ToUpper(command))
			{
				case 'N':
					return RobotHeading.North;

				case 'E':
					return RobotHeading.East;

				case 'S':
					return RobotHeading.South;

				case 'W':
					return RobotHeading.West;

				default:
					throw new ArgumentException();
			}
		}
	}
}