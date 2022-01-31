using UnityEngine;
using UnityEngine.Events;

public class Turret : MonoBehaviour
{
    public UnityAction<float, float> HealthChanged;
    public UnityAction Destroyed;
    public UnityAction TurnOnTurret;

    [SerializeField] private float _StartHealthCount = 30f;

    private float _healthCount;
    private bool _isWorking;

    private void Start()
    {
        ResetGame.ResetLevel += ResetTurret;
        ResetTurret();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Bullet bullet))
        {
            bullet.ResetBullet();

            if (_isWorking)
                TakeDamage(10);
        }
    }

    public void TakeDamage(float value)
    {
        _healthCount -= value;
        HealthChanged?.Invoke(_healthCount, _StartHealthCount);
        TryDisable();
    }

    private void TryDisable()
    {
        if (_healthCount <= 0)
        {
            _isWorking = false;
            Destroyed?.Invoke();
        }
    }

    private void ResetTurret()
    {
        _healthCount = _StartHealthCount;
        _isWorking = true;
        TurnOnTurret?.Invoke();
        HealthChanged?.Invoke(_healthCount, _StartHealthCount);
    }

    private void OnDestroy()
    {
        ResetGame.ResetLevel -= ResetTurret;
    }
}
