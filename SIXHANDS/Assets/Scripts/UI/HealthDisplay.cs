using Player;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Slider _bar;

    private void Awake()
    {
        _health.HealthChanged += UpdateHealthDisplay;
    }

    private void UpdateHealthDisplay(float count, float maxCount)
    {
        _bar.value = count / maxCount;
    }

    private void OnDestroy()
    {
        _health.HealthChanged -= UpdateHealthDisplay;
    }
}
