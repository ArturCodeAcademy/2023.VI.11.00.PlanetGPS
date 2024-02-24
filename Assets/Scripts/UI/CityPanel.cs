using UnityEngine;

public class CityPanel : MonoBehaviour
{
    [SerializeField] private CityEnumerator _cityEnumerator;

	[Header("UI")]
	[SerializeField] private TMPro.TextMeshProUGUI _cityNameText;
	[SerializeField] private TMPro.TextMeshProUGUI _cityNumberText;

    private void OnEnable()
    {
		_cityEnumerator.OnCityChanged += OnCityChanged;
	}

    private void OnDisable()
    {
		_cityEnumerator.OnCityChanged -= OnCityChanged;
	}

	private void OnCityChanged(GeoCoord city)
	{
		_cityNameText.text = $"Find\n{city.Label}";
		_cityNumberText.text = $"{_cityEnumerator.CurrentCity} / {_cityEnumerator.CitiesCount}";
	}
}
