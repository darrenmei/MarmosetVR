using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class StartScript : MonoBehaviour {

	public Transform brick;

	private ArrayList allLocations;
	private string locationDataFileName = "data.txt";
	private int num_locations = 0;

	void Start() {
		allLocations = new ArrayList ();
		loadLocation ();
		displayObjects ();
	}

	private void loadLocation()
	{
		// Path.Combine combines strings into a file path
		// Application.StreamingAssets points to Assets/StreamingAssets in the Editor, and the StreamingAssets folder in a build
		string filePath = Path.Combine(Application.streamingAssetsPath, locationDataFileName);

		if(File.Exists(filePath))
		{
			StreamReader reader = File.OpenText (filePath);
			string line;
			while ((line = reader.ReadLine ()) != null) 
			{
				allLocations.Add(readLocation(line));
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


	public struct LocationData
	{
		public int x, y, z;
		public LocationData(string[] locations) {
			x = int.Parse(locations[0]);
			y = int.Parse(locations[1]);
			z = int.Parse(locations[2]);
		}
	}

	private void displayObjects() {
		foreach (LocationData instance in allLocations) {
			Instantiate(brick, new Vector3(instance.x, instance.y, instance.z), Quaternion.identity);
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
