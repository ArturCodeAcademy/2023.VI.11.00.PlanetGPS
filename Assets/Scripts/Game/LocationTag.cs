using TMPro;
using UnityEngine;

public class LocationTag : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Transform _canvas;
    [SerializeField, Range(0, 1)] private float _canvasOffset = 0.1f;

    private GeoCoord _geoCoord;

    public void SetGeoCoord(GeoCoord geoCoord)
    {
		_geoCoord = geoCoord;

        transform.position = geoCoord.ToVector3UnitSphere() * Earth.Instance.Radius;
        _canvas.LookAt(Vector3.zero);
        _canvas.position = transform.position - _canvas.forward * _canvasOffset;
        _text.text = geoCoord.Label;
	}
}
