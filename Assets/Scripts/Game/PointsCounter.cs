using UnityEngine;
using UnityEngine.Events;

public class PointsCounter : MonoBehaviour
{
    public UnityEvent<CitySelectedEventArgs> CitySelected;
    public UnityEvent<float> TotalPointsChanged;

    [SerializeField, Min(0)] private int _pointsPerKm = 100;
    [SerializeField] private float _maxDistance = 5000;

    [Space(3)]
    [SerializeField] private LocationSelector _locationSelector;
    [SerializeField] private CityEnumerator _cityEnumerator;

    private float _totalPoints = 0;
    private GeoCoord _currentTarget;

    private void Awake()
    {
        CitySelected ??= new UnityEvent<CitySelectedEventArgs>();
        TotalPointsChanged ??= new UnityEvent<float>();
    }

    private void OnEnable()
    {
        _cityEnumerator.OnCityChanged += OnCityChanged;
    }

    private void OnDisable()
    {
        _cityEnumerator.OnCityChanged -= OnCityChanged;
    }

    private void OnCityChanged(GeoCoord coord)
    {
        _currentTarget = coord;
    }

    public void OnCoordSelected()
    {
        float distance = _locationSelector.SelectedCoord.DistanceTo(_currentTarget);
        float points = Mathf.Max(_maxDistance - distance, 0) * _pointsPerKm;
        _totalPoints += points;
        TotalPointsChanged?.Invoke(_totalPoints);
        CitySelected?.Invoke(new CitySelectedEventArgs()
        {
            Distance = distance,
            Points = points,
            MaxPoints = _maxDistance * _pointsPerKm
        });
    }

    public class CitySelectedEventArgs
    {
        public float Distance { get; set; }
        public float Points { get; set; }
        public float MaxPoints { get; set; }
    }
}
