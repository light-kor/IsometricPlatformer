using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Slider _bar;

    void Awake()
    {
        _health.HealthChanged += UpdateHealthDisplay;
    }

    private void UpdateHealthDisplay(int count, int maxCount)
    {
        _bar.value = (float)count / maxCount;
    }

    private void OnDestroy()
    {
        _health.HealthChanged -= UpdateHealthDisplay;
    }
}
