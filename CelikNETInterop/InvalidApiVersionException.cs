using System;

namespace CelikNETInterop
{
	public class InvalidApiVersionException : Exception
	{
		public InvalidApiVersionException(string msg)
			: base(msg) { }
	}
}
