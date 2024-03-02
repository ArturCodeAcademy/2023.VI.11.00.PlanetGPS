using UnityEngine;

public static class GeoCoordExtentions
{
	public static Vector3 ToVector3UnitSphere(this GeoCoord coord)
	{
		return Quaternion.Euler(0, -coord.Longitude, 0) * (Quaternion.Euler(-coord.Latitude, 0, 0) * Vector3.forward);
	}

	public static GeoCoord ToGeoCoord(this Vector3 vector)
	{
		vector.Normalize();
		var latitude = Mathf.Asin(vector.y) * Mathf.Rad2Deg;
		var longitude = Mathf.Atan2(vector.z, vector.x) * Mathf.Rad2Deg;
		return new GeoCoord()
		{
			Label = "Custom",
			Latitude = latitude,
			Longitude = longitude
		};
	}
}