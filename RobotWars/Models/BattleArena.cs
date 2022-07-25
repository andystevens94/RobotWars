namespace RobotWars.Models
{
	public class BattleArena : IBattleArena
	{
		public BattleArena(int width, int height)
		{
			Width = width;
			Height = height;
		}

		public int Height { get; init; }
		public int Width { get; init; }
		public IList<Robot> Robots { get; set; } = new List<Robot>();
	}
}