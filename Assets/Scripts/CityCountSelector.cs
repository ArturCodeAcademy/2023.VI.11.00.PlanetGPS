using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CityCountSelector : MonoBehaviour
{
	public UnityEvent<int> Aprooved;

    public const int MIN_CITY_COUNT = 1;
    public const int MAX_CITY_COUNT = 25;

    [SerializeField] private TMPro.TMP_InputField _cityCountInputField;
    [SerializeField] private Button _aprooveButton;

    private string _cityCountString = "5";

	private void Awake()
	{
		_cityCountInputField.text = _cityCountString;
		Aprooved ??= new UnityEvent<int>();
	}

	private void OnEnable()
	{
		_cityCountInputField.onValueChanged.AddListener(OnCityCountChanged);
		_aprooveButton.onClick.AddListener(OnAprooveButtonClicked);
	}

	private void OnDisable()
	{
		_cityCountInputField.onValueChanged.RemoveListener(OnCityCountChanged);
		_aprooveButton.onClick.RemoveListener(OnAprooveButtonClicked);
	}

	private void OnCityCountChanged(string value)
	{
		_cityCountString = value;
	}

	private void OnAprooveButtonClicked()
	{
		if (int.TryParse(_cityCountString, out int count))
		{
			if (count >= MIN_CITY_COUNT && count <= MAX_CITY_COUNT)
			{
				Aprooved.Invoke(count);
				return;
			}
		}

		count = Mathf.Clamp(count, MIN_CITY_COUNT, MAX_CITY_COUNT);
		_cityCountInputField.text = count.ToString();
	}
}
