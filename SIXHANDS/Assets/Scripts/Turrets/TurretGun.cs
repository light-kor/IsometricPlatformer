using DG.Tweening;
using UI;
using UnityEngine;
using Weapon;

namespace Turrets
{
    public class TurretGun : MonoBehaviour
    {
        [SerializeField] private Turret _turret;
        [SerializeField] private Transform _shootPoint;
        [Header("Settings")]
        [SerializeField] private int _shotsInLine;
        [SerializeField] private float _timeBetweenShots;
        [SerializeField] private float _timeBetweenLines;
        [SerializeField] private float _damage;
        
        private BulletContainer _bullets;
        private Sequence _sequence;

        private void Awake()
        {
            _bullets = GetComponentInParent<BulletContainer>();
            _turret.TurnOnTurret += StartShooting;
            _turret.Destroyed += StopShooting;
            EndGame.StopGame += StopShooting;
        }

        private void StartShooting()
        {
            if (_sequence != null)
                _sequence.Restart();
            else
                Shoot();
        }

        private void Shoot()
        {
            _sequence = DOTween.Sequence();

            for (var i = 0; i < _shotsInLine; i++)
            {
                _sequence.AppendInterval(_timeBetweenShots);
                _sequence.AppendCallback(() => _bullets.ReleaseBullet(_shootPoint.position, transform.forward, _damage));
            }

            _sequence.AppendInterval(_timeBetweenLines);
            _sequence.SetLoops(-1, LoopType.Restart);
        }

        private void StopShooting()
        {
            _sequence.Pause();
        }

        private void OnDestroy()
        {
            _turret.TurnOnTurret -= StartShooting;
            _turret.Destroyed -= StopShooting;
            EndGame.StopGame -= StopShooting;
        }
    }
}
