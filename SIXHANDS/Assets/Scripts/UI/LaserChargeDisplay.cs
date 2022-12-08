using UnityEngine;
using UnityEngine.UI;
using Weapon;

namespace UI
{
    public class LaserChargeDisplay : MonoBehaviour
    {
        [SerializeField] private Slider _bar;
        [SerializeField] private LaserGun _laserGun;

        private void Awake()
        {
            _laserGun.ChargeChanged += UpdateChargeDisplay;
        }

        private void UpdateChargeDisplay(float value)
        {
            _bar.value = value;
        }

        private void OnDestroy()
        {
            _laserGun.ChargeChanged -= UpdateChargeDisplay;
        }
    }
}
