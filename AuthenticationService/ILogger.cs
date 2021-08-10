namespace AuthenticationService
{
	public interface ILogger
	{
		void WriteEvent(string eventMessage);
		void WriteError(string errorMessage);
	}
}
