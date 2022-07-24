using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotWars.UnitTests
{
	public class RobotConsoleServiceTests
	{
		[Fact]
		public void RobotConsole()
		{
			RobotConsoleService robotConsoleService = new RobotConsoleService();
			robotConsoleService.GetRobot();
		}
	}
}