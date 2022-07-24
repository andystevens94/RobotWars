using RobotWars.Models;
using RobotWars.Models.Common;
using RobotWars.Validation;
using System.ComponentModel;

namespace RobotWars.Services.ConsoleServices
{
	public class BattleArenaConsoleService : ConsoleService
	{
		[DisplayName("Height of Battle Arena")]
		public int Height { get; set; }

		[DisplayName("Width of Battle Arena")]
		public int Width { get; set; }

		public BattleArenaConsoleService(IConsole console) : base(console)
		{
		}

		public BattleArena GetBattleArena()
		{
			base.GetInformation();
			return new BattleArena(Width, Height);
		}

		protected override string ValidationMessage(string propName)
		{
			switch (propName)
			{
				case "Width":
					return "Must be a non-negative integer";

				case "Height":
					return "Must be a non-negative integer";
			}
			throw new NotImplementedException();
		}

		private bool HeightValidation(int value)
		{
			return BattleArenaValidation.WidthHeightValidation(value);
		}

		private bool WidthValidation(int value)
		{
			return BattleArenaValidation.WidthHeightValidation(value);
		}
	}
}