using System;
using DG.Tweening;
using UI;
using UnityEngine;

namespace Weapon
{
    public class SimpleGun : MonoBehaviour
    {
        public Action<int> AmmoInClip;
        public Action Reload;

        [SerializeField] private Transform _shootPoint;
        [SerializeField] private BulletContainer _bulletContainer;
        [Header("Settings")]
        [SerializeField] private int _maxAmmo;
        [SerializeField] private float _reloadTime;
        [SerializeField] private float _damage;

        private Sequence _sequence;
        private int _ammo;
        private bool _canShoot;

        private void Start()
        {
            InputSystem.SimpleShot += Shoot;
            ResetGame.ResetLevel += ResetGun;
            ResetGun();
        }

        private void Shoot()
        {
            if (!_canShoot) return;
            
            _bulletContainer.ReleaseBullet(_shootPoint.position, transform.forward, _damage);
            _ammo--;
            AmmoInClip?.Invoke(_ammo);

            if (_ammo == 0)
            {
                _canShoot = false;
                ReloadGun();
            }
        } 

        private void ReloadGun()
        {
            _sequence = DOTween.Sequence();
            _sequence.AppendInterval(_reloadTime);
            _sequence.AppendCallback(() => ResetGun());
        }

        private void ResetGun()
        {
            _canShoot = true;
            _ammo = _maxAmmo;
            Reload?.Invoke();
        }

        private void OnDestroy()
        {
            InputSystem.SimpleShot -= Shoot;
            ResetGame.ResetLevel -= ResetGun;
        }
    }
}
