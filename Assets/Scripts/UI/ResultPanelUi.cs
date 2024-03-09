using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResultPanelUi : MonoBehaviour
{
    [SerializeField] private TMP_Text _distanceText;
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private Image _fillScore;

    public void ShowResult(PointsCounter.CitySelectedEventArgs args)
    {
        _distanceText.text = $"Distance: {args.Distance:F2} km";
        _scoreText.text = $"Score: {args.Points:F0} / {args.MaxPoints:F0}";
        _fillScore.fillAmount = args.Points / args.MaxPoints;
    }
}
