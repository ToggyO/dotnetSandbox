namespace Validator.Resources
{
    /// <summary>
	/// Allows the default error message to be managed.
	/// </summary>
    public interface IMessageManager
    {
		/// <summary>
		/// Gets a string based on its key.
		/// </summary>
		/// <param name="key">The key.</param>
		/// <returns></returns>
		string GetString(string key);
    }
}
