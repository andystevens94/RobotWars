using RobotWars.Models.Common;
using System.ComponentModel;
using System.Reflection;

namespace RobotWars.Services.ConsoleServices
{
	public abstract class ConsoleService
	{
		private IConsole _console;

		public ConsoleService(IConsole console)
		{
			_console = console;
		}

		/// <summary>
		/// This Goes through each property in the derived classes and asks the user for an input. Once an input is given it runs validation against the values.
		/// </summary>
		protected void GetInformation()
		{
			PropertyInfo[] props = this.GetType().GetProperties();
			for (int i = 0; i < props.Length; i++)
			{
				string? input = GetUserInput(props[i]);
				try
				{
					object? convertedInput = TryConvertUserInputToType(props[i], input);
					MethodInfo validationMethod = GetValidationMethod(props[i]);
					ValidateUserInput(convertedInput, validationMethod);
					props[i].SetValue(this, convertedInput, null);
				}
				catch (Exception e) when (e is NotSupportedException || e is NotImplementedException)
				{
					// Unhandled exception should break the program

					_console.WriteLine(e.Message);
					return;
				}
				catch (Exception e)
				{
					// Handled exception should show an error message and continue

					_console.WriteLine(ValidationMessage(props[i].Name));
					i--;
				}
			}
		}

		/// <summary>
		///	Writes the <see cref="DisplayNameAttribute"/> or the property name to the console and gets the user input.
		/// </summary>
		/// <param name="prop">Property </param>
		/// <returns>The string input by the user</returns>
		private string? GetUserInput(PropertyInfo prop)
		{
			var displayNameAtt = prop.GetCustomAttribute(typeof(DisplayNameAttribute)) as DisplayNameAttribute;

			string consoleText = displayNameAtt != null ? displayNameAtt.DisplayName : prop.Name;

			_console.WriteLine("Please enter {0}:", consoleText);
			return _console.ReadLine();
		}

		/// <summary>
		/// Attempt to convert a string to the specified properties type.
		/// </summary>
		/// <param name="prop"></param>
		/// <param name="input"></param>
		/// <returns></returns>
		/// <exception cref="NotSupportedException"></exception>
		private static object TryConvertUserInputToType(PropertyInfo prop, string? input)
		{
			var convertedInput = Convert.ChangeType(input, prop.PropertyType);
			if (convertedInput == null)
			{
				throw new NotSupportedException();
			}

			return convertedInput;
		}

		/// <summary>
		/// Get's the Validation method for a property in the devired class's.
		/// </summary>
		/// <param name="prop"></param>
		/// <returns></returns>
		/// <exception cref="NotImplementedException"></exception>
		private MethodInfo GetValidationMethod(PropertyInfo prop)
		{
			var validationMethodsArray = this.GetType().GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);
			var validationMethod = validationMethodsArray.FirstOrDefault(x => x.Name == prop.Name + "Validation");

			if (validationMethod == null)
			{
				throw new NotImplementedException("Valiation Method not implemented");
			}

			return validationMethod;
		}

		/// <summary>
		/// Validated the user's input using on the 'xxxValidation' methods in devired class's. Throw's an exception if the validation fails
		/// </summary>
		/// <param name="prop"></param>
		/// <param name="convertedInput"></param>
		/// <exception cref="NotImplementedException"></exception>
		/// <exception cref="NotSupportedException"></exception>
		/// <exception cref="ArgumentException"></exception>
		private void ValidateUserInput(object convertedInput, MethodInfo validationMethod)
		{
			bool? validationResult = (bool?)validationMethod.Invoke(this, new object[] { convertedInput });
			if (validationResult == null)
			{
				throw new NotSupportedException();
			}
			if ((bool)!validationResult)
			{
				throw new ArgumentException();
			}
		}

		/// <summary>
		/// Returns a user friendly error message in a string ready to send to the user
		/// /// </summary>
		/// <param name="PropName">Name of the property to validate</param>
		/// <returns></returns>
		protected abstract string ValidationMessage(string PropName);
	}
}