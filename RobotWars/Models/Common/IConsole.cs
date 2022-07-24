namespace RobotWars.Models.Common
{
	public interface IConsole
	{
		string? ReadLine();

		void WriteLine(string value);

		void WriteLine(string format, object? arg0);
	}
}