using RobotWars.Models;
using RobotWars.Models.Common;
using RobotWars.Services.ConsoleServices;

namespace RobotWars.Services
{
	public class BattleArenaService
	{
		public static void ProcessRobotCommands(BattleArena battleArena)
		{
			var console = new ConsoleWrapper();
			var robotConsoleService = new RobotConsoleService(console);
			for (int i = 0; i < battleArena.Robots.Count; i++)
			{
				var robot = battleArena.Robots[i];
				bool CompletedCommands = robot.ProcessCommands();
				if (CompletedCommands)
				{
					robotConsoleService.SendCompletionMessage(robot, i);
				}
				else
				{
					robotConsoleService.SendFailedCommandsError(i);
				}
			}
		}
	}
}