using RobotWars.Models.Common;
using RobotWars.Services;
using RobotWars.Services.ConsoleServices;

var console = new ConsoleWrapper();
var battleArenaConsoleService = new BattleArenaConsoleService(console);
var battleArena = battleArenaConsoleService.GetBattleArena();

int robotCount;

while (true)
{
	Console.WriteLine("How many robots do you want to add?");
	string? input = Console.ReadLine();
	if (int.TryParse(input, out robotCount) && robotCount > 0)
	{
		break;
	}
	Console.WriteLine("Please enter a non-negative integer");
}

for (int i = 0; i < robotCount; i++)
{
	var robotConsoleService = new RobotConsoleService(console);
	var robot = robotConsoleService.GetRobot(battleArena);
	battleArena.Robots.Add(robot);
}

BattleArenaService.ProcessRobotCommands(battleArena);