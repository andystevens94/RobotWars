﻿using RobotWars.Models;
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
			//Add validation against board size
			if (value < 0 || value > battleArena.Width)
			{
				//throw new Exception("Robot out of bounds");
				return false;
			}
			return true;
		}

		public static bool yCoordinateValidation(int value, BattleArena battleArena)
		{
			//Add validation against board size
			if (value < 0 || value > battleArena.Height)
			{
				//throw new Exception("Robot out of bounds");
				return false;
			}
			return true;
		}

		public static bool FullCoordinateValidation(Point point, BattleArena battleArena)
		{
			//Add validation against board size
			if (point.X < 0 || point.Y < 0 || point.Y > battleArena.Height || point.X > battleArena.Width)
			{
				//throw new Exception("Robot out of bounds");
				return false;
			}
			return true;
		}
	}
}