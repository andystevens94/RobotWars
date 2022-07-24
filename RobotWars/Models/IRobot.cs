using RobotWars.Enums;
using RobotWars.Structs;

namespace RobotWars.Models
{
	public interface IRobot
	{
		public Queue<RobotCommand> Commands { get; set; }
		public Point Coords { get; set; }
		public RobotHeading Heading { get; set; }

		bool ProcessCommands();
	}
}