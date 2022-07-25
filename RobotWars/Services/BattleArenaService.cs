using RobotWars.Models;
using RobotWars.Models.Common;
using RobotWars.Services.ConsoleServices;

namespace RobotWars.Services
{
	public class BattleArenaService
	{
		/// <summary>
		/// Process all of the commands for each of the robots contained within the <see cref="BattleArena"/>
		/// </summary>
		/// <param name="battleArena"></param>
		public static void ProcessRobotCommands(BattleArena battleArena)
		{
			var console = new ConsoleWrapper();
			var robotConsoleService = new RobotConsoleService(console);
			for (int i = 0; i < battleArena.Robots.Count; i++)
			{
				var robot = battleArena.Robots[i];
				ProcessCommandsSendMessage(robotConsoleService, i, robot);
			}
		}

		/// <summary>
		/// Process the commands for a <see cref="Robot"/> and send the final location or error message.
		/// </summary>
		/// <param name="robotConsoleService"></param>
		/// <param name="index"></param>
		/// <param name="robot"></param>
		private static void ProcessCommandsSendMessage(RobotConsoleService robotConsoleService, int index, Robot robot)
		{
			bool CompletedCommands = robot.ProcessCommands();
			if (CompletedCommands)
			{
				robotConsoleService.SendCompletionMessage(robot, index);
			}
			else
			{
				robotConsoleService.SendFailedCommandsError(index);
			}
		}
	}
}