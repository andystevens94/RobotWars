namespace RobotWars.Models.Common
{
	internal class ConsoleWrapper : IConsole
	{
		public string? ReadLine()
		{
			return Console.ReadLine();
		}

		public void WriteLine(string value)
		{
			Console.WriteLine(value);
		}

		public void WriteLine(string format, object? args0)
		{
			Console.WriteLine(format, args0);
		}
	}
}