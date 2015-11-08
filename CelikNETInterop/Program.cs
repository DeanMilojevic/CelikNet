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
				using (Interop interop = new Interop())
				{
					interop.Startup();
					CardData cardData = interop.Read();
					interop.Cleanup();
				}
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
