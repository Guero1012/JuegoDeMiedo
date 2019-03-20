using UnityEngine;
using System.IO;

public class FileManager
{
	/// <summary>
	/// Load the specified filename.
	/// </summary>
	/// <param name="filename">Filename.</param>
	/// <typeparam name="T">The 1st type parameter.</typeparam>

	public static T Load<T>(string filename) where T : new()
	{
		string filePath = Path.Combine (Application.persistentDataPath, filename);
		T output;

		if (File.Exists (filePath)) 
		{
			string dataAsJson = File.ReadAllText (filePath);
			output = JsonUtility.FromJson<T> (dataAsJson);
		} 
		else 
		{
			output = new T ();
		}
		return output;
	}


	/// <summary>
	/// Save the specified filename and content.
	/// </summary>
	/// <param name="filename">Filename.</param>
	/// <param name="content">Content.</param>
	/// <typeparam name="T">The 1st type parameter.</typeparam>

	public static void Save<T>(string filename, T content)
	{
		string filePath = Path.Combine (Application.persistentDataPath, filename);

		string dataAsJson = JsonUtility.ToJson (content);
		File.WriteAllText (filePath, dataAsJson);
	}
}
	