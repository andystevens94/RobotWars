using RobotWars.Structs;

namespace RobotWars.Models
{
	public class Robot : IRobot
	{
		public Robot(char heading, Point coords, Queue<char> commands)
		{
			Heading = heading;
			Coords = coords;
			Commands = commands;
		}

		public Queue<char> Commands { get; set; }

		//Rename? Can i store X/Y as 1 property?
		public Point Coords { get; set; }

		//Change to an enum?
		public char Heading { get; set; }

		//Does this need to return a bool?
		public bool ProcessCommands()
		{
			while (Commands.Count > 0)
			{
				ProcessCommandItem(Commands.Dequeue());
			}
			return true;
		}

		private void ProcessCommandItem(char command)
		{
			//Logic for controlling robot
		}
	}
}