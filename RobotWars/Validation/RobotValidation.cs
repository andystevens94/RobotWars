using RobotWars.Models;
using RobotWars.Structs;

namespace RobotWars.Validation
{
	public static class RobotValidation
	{
		public static bool CommandsValidation(string value)
		{
			if (value.Length == 0)
			{
				return false;
			}
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

		public static bool HeadingValidation(char value)
		{
			char[] AcceptableValues = new char[] { 'N', 'S', 'E', 'W' };
			return AcceptableValues.Contains(Char.ToUpper(value));
		}

		public static bool xCoordinateValidation(int value, BattleArena battleArena)
		{
			if (value < 0 || value > battleArena.Width)
			{
				return false;
			}
			return true;
		}

		public static bool yCoordinateValidation(int value, BattleArena battleArena)
		{
			if (value < 0 || value > battleArena.Height)
			{
				return false;
			}
			return true;
		}

		public static bool FullCoordinateValidation(Point point, BattleArena battleArena)
		{
			if (point.X < 0 || point.Y < 0 || point.Y > battleArena.Height || point.X > battleArena.Width)
			{
				return false;
			}
			return true;
		}
	}
}