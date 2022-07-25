using RobotWars.Models;
using RobotWars.Models.Common;
using RobotWars.Validation;
using System.ComponentModel;

namespace RobotWars.Services.ConsoleServices
{
	public class RobotConsoleService : ConsoleService
	{
		private BattleArena battleArena;

		private IConsole _console;

		public RobotConsoleService(IConsole console) : base(console)
		{
			_console = console;
		}

		[DisplayName("Commands from (L, R ,M)")]
		public string Commands { get; set; }

		[DisplayName("Heading from (N, S, E, W)")]
		public char Heading { get; set; }

		[DisplayName("X Coordinate")]
		public int xCoordinate { get; set; }

		[DisplayName("Y Coordinate")]
		public int yCoordinate { get; set; }

		public Robot GetRobot(BattleArena battleArena)
		{
			this.battleArena = battleArena;
			base.GetInformation();
			return RobotService.CreateRobot(Heading, xCoordinate, yCoordinate, Commands, battleArena);
		}

		protected override string ValidationMessage(string propName)
		{
			switch (propName)
			{
				case "Heading":
					return "Must be a single letter N, S, E, W";

				case "xCoordinate":
					return "Must be an integer between  0 - " + battleArena.Width;

				case "yCoordinate":
					return "Must be an integer between  0 - " + battleArena.Height;

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
			return RobotValidation.xCoordinateValidation(value, battleArena);
		}

		private bool yCoordinateValidation(int value)
		{
			return RobotValidation.yCoordinateValidation(value, battleArena);
		}

		public void SendFailedCommandsError(int robotIndex)
		{
			_console.WriteLine("Robot {0}'s commands took it out of bound of the arena.", robotIndex);
		}

		public void SendCompletionMessage(Robot robot, int robotIndex)
		{
			_console.WriteLine("Robot {0}'s final heading: {1}, X: {2}, Y: {3}", robotIndex, robot.Heading, robot.Coords.X, robot.Coords.Y);
		}
	}
}