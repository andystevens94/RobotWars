using RobotWars.Enums;
using RobotWars.Structs;

namespace RobotWars.Models
{
	public class Robot : IRobot
	{
		private BattleArena _battleArena;

		public Robot(RobotHeading heading, Point coords, Queue<RobotCommand> commands, BattleArena battleArena)
		{
			Heading = heading;
			Coords = coords;
			Commands = commands;
			_battleArena = battleArena;
		}

		public Queue<RobotCommand> Commands { get; set; }

		public Point Coords { get; set; }

		public RobotHeading Heading { get; set; }

		/// <summary>
		/// Process's the queue of commands for this <see cref="Robot"/>.
		/// </summary>
		/// <returns>A bool showing if the commands were executed succesfully</returns>
		public bool ProcessCommands()
		{
			while (Commands.Count > 0)
			{
				if (!ProcessCommandItem(Commands.Dequeue()))
				{
					return false;
				}
			}
			return true;
		}

		private bool ProcessCommandItem(RobotCommand command)
		{
			switch (command)
			{
				case RobotCommand.Left:
				case RobotCommand.Right:
					Turn(command);
					break;

				case RobotCommand.Move:
					return Move();

				default:
					throw new NotImplementedException();
			}
			return true;
		}

		private bool Move()
		{
			Point nextLocation;
			switch (Heading)
			{
				case RobotHeading.North:
					nextLocation = new Point(Coords.X, Coords.Y + 1);
					break;

				case RobotHeading.East:
					nextLocation = new Point(Coords.X + 1, Coords.Y);
					break;

				case RobotHeading.South:
					nextLocation = new Point(Coords.X, Coords.Y - 1);
					break;

				case RobotHeading.West:
					nextLocation = new Point(Coords.X - 1, Coords.Y);
					break;

				default:
					throw new InvalidOperationException();
			}
			if (!Validation.RobotValidation.FullCoordinateValidation(nextLocation, _battleArena))
			{
				return false;
			}
			Coords = nextLocation;
			return true;
		}

		private void Turn(RobotCommand direction)
		{
			int newHeading;
			switch (direction)
			{
				case RobotCommand.Left:
					newHeading = Mod((int)Heading - 1, 4);
					break;

				case RobotCommand.Right:
					newHeading = Mod((int)Heading + 1, 4);
					break;

				default:
					throw new InvalidOperationException();
			}
			Heading = (RobotHeading)newHeading;
		}

		//Allow for negative mod
		private static int Mod(int x, int m)
		{
			return (x % m + m) % m;
		}
	}
}