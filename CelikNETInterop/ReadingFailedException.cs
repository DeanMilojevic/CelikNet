using System;

namespace CelikNETInterop
{
	public class ReadingFailedException : Exception
	{
		public ReadingFailedException(string msg)
			: base(msg) { }

		public int Result { get; set; }

		public string FailedAction { get; set; }
	}
}
