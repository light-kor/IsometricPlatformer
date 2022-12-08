using System;
using UI;
using UnityEngine;
using Weapon;

namespace Player
{
    public class Health : MonoBehaviour
    {
        public Action<float, float> HealthChanged;
        public Action Death;

        [SerializeField] private float _startHealthValue = 50;
        private float _healthValue;

        private void Start()
        {
            ResetGame.ResetLevel += ResetHealth;
            ResetHealth();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out Bullet bullet))
            {
                TakeDamage(bullet.Damage);
                bullet.ResetBullet();
            }
        }

        private void TakeDamage(float damage)
        {
            _healthValue -= damage;
            HealthChanged?.Invoke(_healthValue, _startHealthValue);
            CheckHealth();
        }

        private void CheckHealth()
        {
            if (_healthValue > 0) return;
            Death?.Invoke();
        }

        private void ResetHealth()
        {
            _healthValue = _startHealthValue;
            HealthChanged?.Invoke(_healthValue, _startHealthValue);
        }

        private void OnDestroy()
        {
            ResetGame.ResetLevel -= ResetHealth;
        }
    }
}
