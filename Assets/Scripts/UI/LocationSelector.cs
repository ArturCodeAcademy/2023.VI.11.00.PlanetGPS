using TMPro;
using UnityEngine;

public class LocationSelector : MonoBehaviour
{
	[SerializeField]
	private TMP_Text _coordText;

	public GeoCoord SelectedCoord { get; private set; }

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
		SelectedCoord = position.ToGeoCoord();
		_coordText.text =
			$"({SelectedCoord.Latitude:F6}, {SelectedCoord.Longitude:F6})";

		transform.position = position;
		transform.LookAt(Vector3.zero, Vector3.up);
	}

	public void MoveToOrigin()
	{
		transform.position = Vector3.zero;
	}

	public void Unsubscribe()
	{
		Earth.Instance.Click -= OnEarthClicked;
	}

	public void Subscribe()
	{
		Earth.Instance.Click += OnEarthClicked;
	}
}
