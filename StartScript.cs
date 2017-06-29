using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using TeamDev.Redis;

public class StartScript : MonoBehaviour {

	public Transform bar;

	private ArrayList allLocations;
	private string locationDataFileName = "data.txt";
	private int num_locations = 0;
	public RedisDataAccessProvider dataLink;

	void Start() {
		allLocations = new ArrayList ();
		loadLocation ();
		displayObjects ();
		dataLink = new RedisDataAccessProvider ();
		dataLink.Connect ();
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
		public int x, y, z, pitch, yaw;
		public LocationData(string[] locations) {
			x = int.Parse(locations[0]);
			y = int.Parse(locations[1]);
			z = int.Parse(locations[2]);
			pitch = int.Parse(locations[3]);
			yaw = int.Parse(locations[4]);
		}
	}

	private void displayObjects() {
		foreach (LocationData instance in allLocations) {
			Instantiate(bar, new Vector3(instance.x, instance.y, instance.z), Quaternion.Euler(instance.pitch,0,instance.yaw));
		}
	}

	// Update is called once per frame
	void Update () {

	}
}
