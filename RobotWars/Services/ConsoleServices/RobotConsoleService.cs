using RobotWars.Models;
using RobotWars.Models.Common;
using RobotWars.Validation;
using System.ComponentModel;

namespace RobotWars.Services.ConsoleServices
{
	public class RobotConsoleService : ConsoleService
	{
		//Can i change these to fields and add an ignore attribute?
		private BattleArena _battleArena;

		public RobotConsoleService(BattleArena battleArena, IConsole console) : base(console)
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
					return "Must be an integer between  0 - " + _battleArena.Width;

				case "yCoordinate":
					return "Must be an integer between  0 - " + _battleArena.Height;

				case "Commands":
					return "Must be a string composing of the letters: L, R, M";
			}
			throw new NotImplementedException();
		}

		private bool CommandsValidation(string value)
		{
			return RobotValidation.CommandsValidation(value);
		}

		private bool HeadingValidation(char value)
		{
			return RobotValidation.HeadingValidation(value);
		}

		private bool xCoordinateValidation(int value)
		{
			return RobotValidation.xCoordinateValidation(value, _battleArena);
		}

		private bool yCoordinateValidation(int value)
		{
			return RobotValidation.yCoordinateValidation(value, _battleArena);
		}
	}
}