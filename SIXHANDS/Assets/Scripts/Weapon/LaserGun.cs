using System;
using System.Collections;
using Turrets;
using UI;
using UnityEngine;

namespace Weapon
{
    [RequireComponent(typeof(LineRenderer))]
    public class LaserGun : MonoBehaviour
    {
        public Action<float> ChargeChanged;
        [SerializeField] private Transform _shootPoint;
        [SerializeField] private LineRenderer _lineRenderer;

        [Header("Settings")]
        [SerializeField] private float _workTime = 1.5f;
        [SerializeField] private float _cooldownTime = 10f;
        [SerializeField] private float _damage;

        private Coroutine _coroutine;
        private Turret _buffer;
        private Collider _lastTarget;
        private float _laserCharge;
        private bool _empty;

        private const float MaxLaserRange = 50f;

        private void Start()
        {
            InputSystem.LaserShot += TryStartShooting;
            ResetGame.ResetLevel += ResetGun;
            _lineRenderer.positionCount = 2;
            ResetGun();
        }

        private void TryStartShooting(bool state)
        {
            if (_empty) return;
            
            if (_coroutine != null)
                StopCoroutine(_coroutine);
            
            _coroutine = StartCoroutine(state ? Shooting() : ChargeRecovery());
        }

        private IEnumerator Shooting()
        {
            _lineRenderer.enabled = true;

            while (_laserCharge > 0f)
            {
                _laserCharge -= Time.deltaTime / _workTime;
                Shoot();
                ChargeChanged?.Invoke(_laserCharge);
                yield return null;
            }

            _empty = true;
            _coroutine = StartCoroutine(ChargeRecovery());
        }
        
        private IEnumerator ChargeRecovery()
        {
            _lineRenderer.enabled = false;

            while (_laserCharge < 1f)
            {
                _laserCharge += Time.deltaTime / _cooldownTime;
                ChargeChanged?.Invoke(_laserCharge);
                yield return null;
            }
            
            _empty = false;
        }
        
        private void Shoot()
        {
            Vector3 target;

            var ray = new Ray(transform.position, transform.forward);
            //Debug.DrawRay(pos, transform.forward * 100, Color.yellow);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                target = hit.point;

                if (hit.collider == _lastTarget)
                {
                    _buffer.TakeDamage(_damage * 10 * Time.deltaTime);
                }
                else if (hit.collider.gameObject.TryGetComponent(out Turret turret))
                {
                    _lastTarget = hit.collider;
                    _buffer = turret;
                }
            }
            else
                target = transform.forward * MaxLaserRange;

            _lineRenderer.SetPosition(0, _shootPoint.position);
            _lineRenderer.SetPosition(1, target);
        }
        
        private void ResetGun()
        {
            if (_coroutine != null)
                StopCoroutine(_coroutine);

            _lineRenderer.enabled = false;
            _laserCharge = 1f;
            ChargeChanged?.Invoke(_laserCharge);
        }

        private void OnDestroy()
        {
            ResetGame.ResetLevel -= ResetGun;
            InputSystem.LaserShot -= TryStartShooting;
        }
    }
}
