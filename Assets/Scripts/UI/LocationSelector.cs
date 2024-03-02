using TMPro;
using UnityEngine;

public class LocationSelector : MonoBehaviour
{
	[SerializeField]
	private TMP_Text _coordText;

	private GeoCoord _selectedCoord;

	private void OnEnable()
	{
		Earth.Instance.Click += OnEarthClicked;
	}

	private void OnDisable()
	{
		Earth.Instance.Click -= OnEarthClicked;
	}

	private void OnEarthClicked(Vector3 position)
	{
		_selectedCoord = position.ToGeoCoord();
		_coordText.text =
			$"({_selectedCoord.Latitude:F6}, {_selectedCoord.Longitude:F6})";

		transform.position = position;
		transform.LookAt(Vector3.zero, Vector3.up);
	}
}
