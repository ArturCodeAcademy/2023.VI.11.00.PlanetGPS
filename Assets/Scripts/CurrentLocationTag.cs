using UnityEngine;

public class CurrentLocationTag : MonoBehaviour
{
	[SerializeField] private CityEnumerator _cityEnumerator;

    private LocationTag _locationTag;

	private void Awake()
	{
		_locationTag = GetComponent<LocationTag>();
	}

	public void Show()
    {
		gameObject.SetActive(true);
		_locationTag.SetGeoCoord(_cityEnumerator.CurrentCityCoord);
	}

    public void Hide()
    {
        gameObject.SetActive(false);
	}
}
