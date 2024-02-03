using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField, Min(1)] private int _count = 10;
    [SerializeField] private LocationTag _locationTagPrefab;

    void Start()
    {
        GeoCoord[] cities = CitiesContainer.GetRandomCities(_count);
        
        foreach (var city in cities)
        {
			var locationTag = Instantiate(_locationTagPrefab, transform);
			locationTag.SetGeoCoord(city);
		}
    }
}
