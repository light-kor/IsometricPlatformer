using Crystals;
using TMPro;
using UnityEngine;

namespace UI
{
    public class CrystalDisplay : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        [SerializeField] private CrystalCollector _crystalCollector;

        private void Awake()
        {
            _crystalCollector.CrystalCountChanged += UpdateCrystalDisplay;
        }

        private void UpdateCrystalDisplay(int value, int maxValue)
        {
            _text.text = $"{value}/{maxValue}";
        }

        private void OnDestroy()
        {
            _crystalCollector.CrystalCountChanged -= UpdateCrystalDisplay;
        }
    }
}
