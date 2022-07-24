using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotWars.Validation
{
	public class BattleArenaValidation
	{
		public static bool WidthHeightValidation(int value)
		{
			if (value > 0)
			{
				return true;
			}
			return false;
		}
	}
}