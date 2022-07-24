using RobotWars.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
	}
}