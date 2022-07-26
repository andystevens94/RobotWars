# RobotWars
This is a Console app in .NET 6
To run the project download the code, open the .sln file to open the project. Run the project to open the Console and view the the app.

## Reflection & Abstraction
The abstract ConsoleService class implement's a method called `GetInformation()`, this method serves as the base method for all class's devriving from it. The method uses reflection to get the properties of the derived class and will prompt the user to input a value in the console for each property. I use reflection again to get the the validation method's for each property from within the derived class. The inputs are then validated using these methods before assigning the value to the property.

The reason for using reflection and abstraction here was that it allows new models to be added much more easily, say an "Obstruction" was needed in the `BattleArena` then all we would have to do is add the appriopiate models, validation methods and create an `ObstructionConsoleService` which derives from `ConsoleService`. You wouldn't have to touch the orginal code. 

## Interfaces
I've used interfaces to provide a contract for `IBattleArena` and `IRobot` as I believe that if you were to expand this game you may want different types of arena and robots but you will always need the core properties and methods of these interfaces which any new object types will have to implement.


## Potential improvements
* Improve the messaging formatting to make it clearer 
* Add a visual aspect, e.g change to a web app
* Add collisons (First to collide with opponent wins?) 
* Turn based movement
* Add obstacles/traps
* Add a health property and turn the app into a game

