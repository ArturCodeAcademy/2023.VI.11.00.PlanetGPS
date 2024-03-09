using TMPro;
using UnityEngine;

public class PointsPanelUi : MonoBehaviour
{
    [SerializeField] private TMP_Text _pointsText;

	private void Awake()
	{
		_pointsText.text = "0 P.";
	}

	public void UpdatePoints(float points)
    {
		_pointsText.text = $"{points:F0} P.";
	}
}
