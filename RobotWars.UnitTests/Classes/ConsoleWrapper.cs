namespace RobotWars.UnitTests.Classes
{
	internal class ConsoleWrapper : IConsole
	{
		private Queue<string> _userInputText = new Queue<string>();

		public ConsoleWrapper(Queue<string> userInputText)
		{
			_userInputText = userInputText;
		}

		public string? ReadLine()
		{
			return _userInputText.Dequeue();
		}

		public void WriteLine(string value)
		{
		}

		public void WriteLine(string format, object? args0)
		{
		}

		public void WriteLine(string format, params object?[]? args0)
		{
		}
	}
}