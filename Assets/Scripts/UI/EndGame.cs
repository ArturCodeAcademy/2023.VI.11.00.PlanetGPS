using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField] private CityEnumerator _cityEnumerator;
    [SerializeField] private GameObject _nextButton;

    private void OnEnable()
    {
		_cityEnumerator.OnCityChanged += OnCityChanged;
	}

    private void OnDisable()
    {
		_cityEnumerator.OnCityChanged -= OnCityChanged;
	}

	private void OnCityChanged(GeoCoord _)
	{
		if (_cityEnumerator.CurrentCity == _cityEnumerator.CitiesCount)
		{
			_nextButton.SetActive(false);
		}
	}

	public void QuitGame()
	{
		Application.Quit();

#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
#endif
	}
}
