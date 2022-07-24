using RobotWars.Models;
using RobotWars.Structs;

namespace RobotWars.Services
{
	public static class RobotService
	{
		public static Robot CreateRobot(char heading, int x, int y, string commands)
		{
			Point Point = new Point(x, y);
			Queue<char> commandQueue = new Queue<char>(commands.ToArray());
			return new Robot(heading, Point, commandQueue);
		}
	}
}