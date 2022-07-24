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