using System;
using Crystals;
using DG.Tweening;
using UI;
using UnityEngine;

namespace Weapon
{
    public class Magnet : MonoBehaviour
    {
        public Action<float> SetButtonCooldown;

        [SerializeField] private Collider _collider;
        [SerializeField] private MagnetAnimation _anim;
        [Header("Settings")]
        [SerializeField] private float _force = 2f;
        [SerializeField] private float _workTime = 2f;
        [SerializeField] private float _cooldownTime = 10f;

        private Sequence _sequence;
        private bool _isWorking;

        private void Start()
        {
            InputSystem.MagnetPower += UseMagnet;
            ResetGame.ResetLevel += ResetMagnet;
            ResetMagnet();
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.TryGetComponent(out Crystal crystal))
            {
                crystal.MoveToTarget(transform.position, _force);
            }
        }

        private void UseMagnet()
        {
            if (_isWorking) return;
            
            _isWorking = true;
            MagnetWorkCycle();
        }

        private void MagnetWorkCycle()
        {
            _sequence = DOTween.Sequence();
            
            _sequence.AppendCallback(() => _anim.ShowSphere());
            _sequence.AppendCallback(() => SetButtonCooldown?.Invoke(_workTime + _cooldownTime));
            _sequence.AppendCallback(() => _collider.enabled = true);
            _sequence.AppendInterval(_workTime);
            _sequence.AppendCallback(() => _anim.HideSphere());
            _sequence.AppendCallback(() => _collider.enabled = false);
            _sequence.AppendInterval(_cooldownTime);
            _sequence.AppendCallback(() => _isWorking = false);
        }

        private void ResetMagnet()
        {
            _sequence?.Kill();
            _anim.ResetSphere();
            _collider.enabled = false;
            _isWorking = false;
        }

        private void OnDestroy()
        {
            ResetGame.ResetLevel -= ResetMagnet;
            InputSystem.MagnetPower -= UseMagnet;
        }
    }
}
