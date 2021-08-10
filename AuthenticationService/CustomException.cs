using System;

namespace AuthenticationService
{
	public class CustomException : Exception
	{
		public CustomException(string message) : base(message) { }
	}
}
