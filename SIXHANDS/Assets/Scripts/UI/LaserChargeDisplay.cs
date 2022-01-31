using UnityEngine;
using UnityEngine.UI;

public class LaserChargeDisplay : MonoBehaviour
{
    [SerializeField] private LaserGun _laser;
    [SerializeField] private Slider _bar;

    void Awake()
    {
        _laser.ChargeChanged += UpdateChargeDisplay;
    }

    private void UpdateChargeDisplay(float value)
    {
        _bar.value = value;
    }

    private void OnDestroy()
    {
        _laser.ChargeChanged -= UpdateChargeDisplay;
    }
}
