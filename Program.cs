using System;

namespace Opgave2
{
	interface IInput
	{
		// Deklarere et event. Her sættes typen af parameteren til eventhandleren til "ConsoleInputEventArgs"
		event EventHandler<ConsoleInputEventArgs> ConsoleInput;
	}
	
	class Program : IInput // Klassen Program implementerer IInput og har derfor eventet ConsoleInput
	{
		static void Main(string[] args)
			{
			new Program().Run();
		}
		
		public void Run()
		{
			Printer p = new Printer(this);
			bool run = true;
			while(run)
			{
				string line = System.Console.ReadLine();
				if(line == "EXIT")
					run = false;
				ConsoleInput.Invoke(this, new ConsoleInputEventArgs(line)); // Med Invoke fyres der et event, som alle eventhandler kommer til at modtage.
			}
		}
		
		public event EventHandler<ConsoleInputEventArgs> ConsoleInput; // Eventet skal igen deklareres her for at implementere IInput.
	}
	
	class Printer
	{
		public Printer(IInput input)
		{
			// Her tilføjes denne Printers handler til eventet af IInput.
			// Som svarer til vores Program klasse, som implementerer IInput.
			input.ConsoleInput += ConsoleInputHandler;
		}
		
		// For at funktionen kan agere som eventhandler, skal den have parameterne brugt til "Invoke".
		// Dvs. et object der svarer til senderen af event.
		// Og "ConsoleInputEventArgs"
		public void ConsoleInputHandler(object sender, ConsoleInputEventArgs arg)
		{
			Console.WriteLine(arg.Line);
		}
	}
	
	// I klassen ConsoleInputEventArgs er så informationer omkring eventet.
	// Som data til et input event, vil inputtet (dvs. den intastede linje) være dataene.
	class ConsoleInputEventArgs : EventArgs
	{
		public string Line { get; }
		public ConsoleInputEventArgs(string Line)
		{
			this.Line = Line;
		}
	}
}
