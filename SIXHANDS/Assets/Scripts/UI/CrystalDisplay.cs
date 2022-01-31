using TMPro;
using UnityEngine;

public class CrystalDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private CrystalCollector _collector;

    void Awake()
    {
        _collector.ValueChanged += UpdateCrystalDisplay;
    }

    private void UpdateCrystalDisplay(int value, int maxValue)
    {
        _text.text = $"{value}/{maxValue}";
    }

    private void OnDestroy()
    {
        _collector.ValueChanged -= UpdateCrystalDisplay;
    }
}
