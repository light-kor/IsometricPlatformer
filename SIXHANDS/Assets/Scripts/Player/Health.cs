using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public UnityAction<int, int> HealthChanged;
    public UnityAction<bool> Death;

    [SerializeField] private int _startHealth = 10;
    private int _healthCount;
    private bool _isDead = false;

    private void Start()
    {
        ResetGame.ResetLevel += ResetHealth;
        ResetHealth();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Bullet bullet))
        {
            TakeDamage();
            bullet.gameObject.SetActive(false);
        }
    }

    public void TakeDamage()
    {
        _healthCount--;
        HealthChanged?.Invoke(_healthCount, _startHealth);
        ChechHealth();
    }

    public void ChechHealth()
    {
        if (!_isDead && _healthCount <= 0)
        {
            _isDead = true;
            Death?.Invoke(false);
        }
    }

    private void ResetHealth()
    {
        _healthCount = _startHealth;
        HealthChanged?.Invoke(_healthCount, _startHealth);
        _isDead = false;
    }
}
