using CelikNETInterop;
using CelikNETInterop.Data;
using System;

namespace CelikNET
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				Interop.Startup();
				CardData cardData = Interop.Read();
				Interop.Cleanup();
			}
			catch (InvalidApiVersionException ex)
			{
				Console.WriteLine(ex.Message);
			}
			catch (ReadingFailedException ex)
			{
				Console.WriteLine("Greska prilikom citanja sa kartice. Poziv {0} nije uspeo, kod greske: {1}", ex.FailedAction, ex.Result);
			}

			Console.ReadLine();
		}
	}
}
