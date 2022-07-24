using RobotWars.Models;

namespace RobotWars.Services
{
	public class BattleArenaService
	{
		public static BattleArena CreateBattleArena(int width, int height)
		{
			return new BattleArena(width, height, null);
		}
	}
}