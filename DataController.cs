using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.IO;                                                        // The System.IO namespace contains functions related to loading and saving files

public class DataController : MonoBehaviour {
	private LocationData[] allLocations;
	private string locationDataFileName = "data.txt";
	private int num_locations = 0;

	void Start() {
		LoadLocation ();
	}

	private void LoadLocation()
	{
		// Path.Combine combines strings into a file path
		// Application.StreamingAssets points to Assets/StreamingAssets in the Editor, and the StreamingAssets folder in a build
		string filePath = Path.Combine(Application.streamingAssetsPath, locationDataFileName);

		if(File.Exists(filePath))
		{
			StreamReader reader = File.OpenText (locationDataFileName);
			string line;
			while ((line = reader.ReadLine ()) != null) 
			{
				allLocations [num_locations] = readLocation(line);
				num_locations++;
			}
		}
		else
		{
			Debug.LogError("Cannot load data!");
		}
	}

	private LocationData readLocation(string line) {
		return new LocationData (line.Split (','));
	}
		
}
	