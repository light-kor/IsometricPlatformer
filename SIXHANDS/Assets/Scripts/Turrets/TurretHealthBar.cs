using UnityEngine;
using UnityEngine.UI;

namespace Turrets
{
    public class TurretHealthBar : MonoBehaviour
    {
        [SerializeField] private Canvas _canvas;
        [SerializeField] private Turret _turret;
        [SerializeField] private Slider _bar;

        private void Start()
        {
            _turret.HealthChanged += UpdateHealthBar;
            _turret.Destroyed += HideCanvas;
            _turret.TurnOnTurret += ShowCanvas;
        }

        private void Update()
        {
            _canvas.transform.LookAt(Camera.main.transform);
        }

        private void HideCanvas()
        {
            _canvas.gameObject.SetActive(false);
        }

        private void ShowCanvas()
        {
            _canvas.gameObject.SetActive(true);
        }

        private void UpdateHealthBar(float value, float maxValue)
        {
            _bar.value = value / maxValue;
        }

        private void OnDestroy()
        {
            _turret.HealthChanged -= UpdateHealthBar;
            _turret.Destroyed -= HideCanvas;
            _turret.TurnOnTurret -= ShowCanvas;
        }
    }
}
