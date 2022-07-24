using RobotWars.Services;
using RobotWars.Services.ConsoleServices;

// See https://aka.ms/new-console-template for more information
//Console.WriteLine("What heading!");
//string? cmd = Console.ReadLine();

//if (cmd != null){
//	Robot robot = new Robot();
//	robot.Heading = cmd;
//}

var battleArenaConsoleService = new BattleArenaConsoleService();
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
	var robotConsoleService = new RobotConsoleService(battleArena);
	var robot = robotConsoleService.GetRobot();
	battleArena.Robots.Add(robot);
}
battleArena.Robots[0].ProcessCommands();
Console.WriteLine("END");