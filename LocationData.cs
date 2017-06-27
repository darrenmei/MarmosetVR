using System;

public struct LocationData
{
	public int x, y, z;
	public LocationData(string[] locations) {
		x = int.Parse(locations[0]);
		y = int.Parse(locations[1]);
		z = int.Parse(locations[2]);
	}
}

