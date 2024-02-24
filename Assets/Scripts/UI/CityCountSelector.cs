using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CityCountSelector : MonoBehaviour
{
	public UnityEvent<int> Approved;

    public const int MIN_CITY_COUNT = 1;
    public const int MAX_CITY_COUNT = 25;

    [SerializeField] private TMPro.TMP_InputField _cityCountInputField;
    [SerializeField] private Button _aprooveButton;

    private string _cityCountString = "5";

	private void Awake()
	{
		_cityCountInputField.text = _cityCountString;
		Approved ??= new UnityEvent<int>();
	}

	private void OnEnable()
	{
		_cityCountInputField.onValueChanged.AddListener(OnCityCountChanged);
		_aprooveButton.onClick.AddListener(OnApproveButtonClicked);
	}

	private void OnDisable()
	{
		_cityCountInputField.onValueChanged.RemoveListener(OnCityCountChanged);
		_aprooveButton.onClick.RemoveListener(OnApproveButtonClicked);
	}

	private void OnCityCountChanged(string value)
	{
		_cityCountString = value;
	}

	private void OnApproveButtonClicked()
	{
		if (int.TryParse(_cityCountString, out int count))
		{
			if (count >= MIN_CITY_COUNT && count <= MAX_CITY_COUNT)
			{
				Approved.Invoke(count);
				return;
			}
		}

		count = Mathf.Clamp(count, MIN_CITY_COUNT, MAX_CITY_COUNT);
		_cityCountInputField.text = count.ToString();
	}
}
