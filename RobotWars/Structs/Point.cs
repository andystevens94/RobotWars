namespace RobotWars.Structs
{
	//Don't need the extra features provided by system.drawing for this project, so decided to create a simple version
	public struct Point
	{
		public Point(int x, int y)
		{
			X = x;
			Y = y;
		}

		public int X { get; set; }
		public int Y { get; set; }
	}
}