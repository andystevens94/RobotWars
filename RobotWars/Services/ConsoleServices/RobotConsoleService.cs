using RobotWars.Models;
using System.ComponentModel;

namespace RobotWars.Services.ConsoleServices
{
	public class RobotConsoleService : ConsoleService
	{
		//Can i change these to fields and add an ignore attribute?
		private BattleArena _battleArena;

		public RobotConsoleService(BattleArena battleArena)
		{
			_battleArena = battleArena;
		}

		[DisplayName("Commands from (L, R ,M)")]
		public string Commands { get; set; }

		[DisplayName("Heading from (N, S, E, W)")]
		public char Heading { get; set; }

		[DisplayName("X Coordinate")]
		public int xCoordinate { get; set; }

		[DisplayName("Y Coordinate")]
		public int yCoordinate { get; set; }

		public Robot GetRobot()
		{
			base.GetInformation();
			return RobotService.CreateRobot(Heading, xCoordinate, yCoordinate, Commands);
		}

		protected override string ValidationMessage(string propName)
		{
			switch (propName)
			{
				case "Heading":
					return "Must be a single letter N, S, E, W";

				case "xCoordinate":
					return "Must be an integer between  1 - " + _battleArena.Width;

				case "yCoordinate":
					return "Must be an integer between  1 - " + _battleArena.Height;

				case "Commands":
					return "Must be a string composing of the letters: L, R, M";
			}
			throw new NotImplementedException();
		}

		private bool CommandsValidation(string value)
		{
			char[] AcceptableValues = new char[] { 'L', 'R', 'M' };
			bool result = true;
			value.ToUpper().ToList().ForEach(x =>
			{
				if (!AcceptableValues.Contains(x))
				{
					result = false;
				}
			});
			return result;
		}

		private bool HeadingValidation(char value)
		{
			char[] AcceptableValues = new char[] { 'N', 'S', 'E', 'W' };
			return AcceptableValues.Contains(Char.ToUpper(value));
		}

		private bool xCoordinateValidation(int value)
		{
			//Add validation against board size
			if (value < 1 || value > _battleArena.Width)
			{
				throw new Exception("Robot out of bounds");
			}
			return true;
		}

		private bool yCoordinateValidation(int value)
		{
			//Add validation against board size
			if (value < 1 || value > _battleArena.Height)
			{
				throw new Exception("Robot out of bounds");
			}
			return true;
		}
	}
}