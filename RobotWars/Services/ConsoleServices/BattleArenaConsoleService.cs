using RobotWars.Models;
using System.ComponentModel;

namespace RobotWars.Services.ConsoleServices
{
	public class BattleArenaConsoleService : ConsoleService
	{
		[DisplayName("Height of Battle Arena")]
		public int Height { get; set; }

		[DisplayName("Width of Battle Arena")]
		public int Width { get; set; }

		public BattleArena GetBattleArena()
		{
			base.GetInformation();
			return BattleArenaService.CreateBattleArena(Width, Height);
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

		private bool WidthHeightValidation(int value)
		{
			if (value > 0)
			{
				return true;
			}
			return false;
		}

		private bool HeightValidation(int value)
		{
			return WidthHeightValidation(value);
		}

		private bool WidthValidation(int value)
		{
			return WidthHeightValidation(value);
		}
	}
}