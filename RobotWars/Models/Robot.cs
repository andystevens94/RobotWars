using RobotWars.Enums;
using RobotWars.Structs;

namespace RobotWars.Models
{
	public class Robot : IRobot
	{
		public Robot(RobotHeading heading, Point coords, Queue<RobotCommand> commands)
		{
			Heading = heading;
			Coords = coords;
			Commands = commands;
		}

		public Queue<RobotCommand> Commands { get; set; }

		public Point Coords { get; set; }

		public RobotHeading Heading { get; set; }

		//Does this need to return a bool?
		public bool ProcessCommands()
		{
			while (Commands.Count > 0)
			{
				ProcessCommandItem(Commands.Dequeue());
			}
			return true;
		}

		private void ProcessCommandItem(RobotCommand command)
		{
			//Logic for controlling robot

			switch (command)
			{
				case RobotCommand.Left:
					break;

				case RobotCommand.Right:
					break;

				case RobotCommand.Move:
					break;
			}
		}
	}
}