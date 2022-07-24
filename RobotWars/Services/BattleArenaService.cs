using RobotWars.Models;
using RobotWars.Services.ConsoleServices;

namespace RobotWars.Services
{
	public class BattleArenaService
	{
		public static void ProcessRobotCommands(BattleArena battleArena)
		{
			for (int i = 0; i < battleArena.Robots.Count; i++)
			{
				var robot = battleArena.Robots[i];
				bool CompletedCommands = robot.ProcessCommands();
				if (CompletedCommands)
				{
					RobotConsoleService.SendCompletionMessage(robot, i);
				}
				else
				{
					RobotConsoleService.SendFailedCommandsError(i);
				}
			}
		}
	}
}