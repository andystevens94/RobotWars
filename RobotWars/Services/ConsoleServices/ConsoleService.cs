using System.ComponentModel;
using System.Reflection;

namespace RobotWars.Services.ConsoleServices
{
	public abstract class ConsoleService
	{
		/// <summary>
		/// Refactor -- This Goes through each property in the derived classes and asks the user for an input. Once an input is given it runs validation against the values.
		/// </summary>
		/// <exception cref="NotSupportedException"></exception>
		/// <exception cref="NotImplementedException"></exception>
		/// <exception cref="ArgumentException"></exception>
		protected void GetInformation()
		{
			string? input = null;
			PropertyInfo[] props = this.GetType().GetProperties();
			for (int i = 0; i < props.Length; i++)
			{
				var displayNameAtt = props[i].GetCustomAttribute(typeof(DisplayNameAttribute)) as DisplayNameAttribute;

				//Better name?
				string consoleText = displayNameAtt != null ? displayNameAtt.DisplayName : props[i].Name;

				Console.WriteLine("Please enter {0}:", consoleText);
				input = Console.ReadLine();
				try
				{
					var convertedInput = Convert.ChangeType(input, props[i].PropertyType);
					if (convertedInput == null)
					{
						throw new NotSupportedException();
					}

					var validationMethodsArray = this.GetType().GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);
					var validationMethod = validationMethodsArray.FirstOrDefault(x => x.Name == props[i].Name + "Validation");

					if (validationMethod == null)
					{
						throw new NotImplementedException("Valiation Method not implemented");
					}

					bool? validationResult = (bool?)validationMethod.Invoke(this, new object[] { convertedInput });
					if (validationResult == null)
					{
						throw new NotSupportedException();
					}
					if ((bool)!validationResult)
					{
						throw new ArgumentException();
					}

					props[i].SetValue(this, convertedInput, null);
				}
				catch (Exception e) when (e is NotSupportedException || e is NotImplementedException || e is ArgumentException)
				{
					Console.WriteLine(e.Message);
					return;
				}
				catch (Exception e)
				{
					Console.WriteLine(ValidationMessage(props[i].Name));
					i--;
				}
			}
		}

		protected abstract string ValidationMessage(string PropName);
	}
}