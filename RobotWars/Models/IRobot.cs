using RobotWars.Structs;

namespace RobotWars.Models
{
	public interface IRobot
	{
		public Queue<char> Commands { get; set; }
		public Point Coords { get; set; }
		public char Heading { get; set; }

		bool ProcessCommands();
	}
}