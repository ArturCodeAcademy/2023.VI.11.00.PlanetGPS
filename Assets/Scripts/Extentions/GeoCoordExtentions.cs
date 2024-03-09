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

		longitude -= 90;
		if (longitude < -180)
			longitude += 360;

		return new GeoCoord()
		{
			Label = "Custom",
			Latitude = latitude,
			Longitude = longitude
		};
	}

	public static float DistanceTo(this GeoCoord from, GeoCoord to)
	{
		const float RADIUS = 6371; // km
        float lat1 = from.Latitude * Mathf.Deg2Rad;
        float lat2 = to.Latitude * Mathf.Deg2Rad;
        float lon1 = from.Longitude * Mathf.Deg2Rad;
        float lon2 = to.Longitude * Mathf.Deg2Rad;

        float dLat = lat2 - lat1;
        float dLon = lon2 - lon1;

        float a = Mathf.Sin(dLat / 2) * Mathf.Sin(dLat / 2) +
            Mathf.Cos(lat1) * Mathf.Cos(lat2) *
            Mathf.Sin(dLon / 2) * Mathf.Sin(dLon / 2);

        float c = 2 * Mathf.Atan2(Mathf.Sqrt(a), Mathf.Sqrt(1 - a));

        return RADIUS * c;
	}
}