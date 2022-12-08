using System;
using UI;
using UnityEngine;
using Weapon;

namespace Turrets
{
    public class Turret : MonoBehaviour
    {
        public Action<float, float> HealthChanged;
        public Action Destroyed;
        public Action TurnOnTurret;

        [SerializeField] private float _startHealthValue = 35f;

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
                TakeDamage(bullet.Damage);
                bullet.ResetBullet();
            }
        }

        public void TakeDamage(float value)
        {
            if (!_isWorking) return;
            
            _healthCount -= value;
            HealthChanged?.Invoke(_healthCount, _startHealthValue);
            TryDisable();
        }

        private void TryDisable()
        {
            if (_healthCount > 0) return;
            
            _isWorking = false;
            Destroyed?.Invoke();
        }

        private void ResetTurret()
        {
            _healthCount = _startHealthValue;
            _isWorking = true;
            TurnOnTurret?.Invoke();
            HealthChanged?.Invoke(_healthCount, _startHealthValue);
        }

        private void OnDestroy()
        {
            ResetGame.ResetLevel -= ResetTurret;
        }
    }
}
