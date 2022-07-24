namespace RobotWars.Models
{
	public class BattleArena
	{
		public BattleArena(int width, int height, IList<Robot> robots = null)
		{
			Width = width;
			Height = height;
			Robots = robots ?? new List<Robot>();
		}

		public int Height { get; set; }
		public int Width { get; set; }
		public IList<Robot> Robots { get; set; } = new List<Robot>();
	}
}