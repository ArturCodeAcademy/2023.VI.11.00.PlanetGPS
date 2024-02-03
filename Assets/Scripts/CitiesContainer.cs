using Newtonsoft.Json;
using System.Linq;
using UnityEngine;

public static class CitiesContainer
{
    private static readonly int CITIES_COUNT;

    private const string CITIES_PATH = "Cities";

    static CitiesContainer()
    {
		CITIES_COUNT = Resources.Load<TextAsset>(CITIES_PATH)
                        .text.Count(c => c == '\n');
	}

    public static GeoCoord[] GetRandomCities(int count)
    {
		if (count > CITIES_COUNT)
			count = CITIES_COUNT;

		var cities = new GeoCoord[count];
		var citiesText = Resources.Load<TextAsset>(CITIES_PATH).text.Split('\n')
								  .OrderBy(_ => Random.Range(0, 10)).ToArray();
		int skip = CITIES_COUNT - count;
		int index = 0;

		for (int i = 0;  index < count && i < citiesText.Length; i++)
		{
			if (skip > 0 && Random.Range(0, 1f) > 0.5f)
			{
				skip--;
				continue;
			}

			cities[index] = JsonConvert.DeserializeObject<GeoCoord>(citiesText[i]);
			index++;
		}

		return cities;
	}
}
