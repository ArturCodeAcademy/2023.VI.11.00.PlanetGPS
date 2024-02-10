using System;
using UnityEngine;

public class CityEnumerator : MonoBehaviour
{
    public int CitiesCount => _cities.Length;
    public int CurrentCity => _currentCityIndex + 1;

    public event Action<GeoCoord> OnCityChanged;

    private GeoCoord[] _cities;
    private int _currentCityIndex;

    public void StartGame(int count)
    {
		_cities = CitiesContainer.GetRandomCities(count);
        _currentCityIndex = 0;

        OnCityChanged?.Invoke(_cities[_currentCityIndex]);
	}

    public void SetNextCity()
    {
        if (_currentCityIndex < _cities.Length - 1)
        {
			_currentCityIndex++;
            OnCityChanged?.Invoke(_cities[_currentCityIndex]);
		}
    }
}
