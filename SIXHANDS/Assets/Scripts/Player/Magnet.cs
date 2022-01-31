using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class Magnet : MonoBehaviour
{
    public UnityAction<float> DisableUIButton;

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
        InputSystem.Input.Player.MagnetPower.performed += ctx => UseMagnet();
        ResetGame.ResetLevel += ResetMagnet;
        ResetMagnet();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out Crystal crystal))
        {
            crystal.MoveToTarget(transform.position, _force / 2);
        }
    }

    private void UseMagnet()
    {
        if (!_isWorking)
        {
            _isWorking = true;
            MagnetWorkCycle();
        }
    }

    public void MagnetWorkCycle()
    {
        _sequence = DOTween.Sequence();

        _sequence.AppendCallback(() => _anim.ShowSphere());
        _sequence.AppendCallback(() => DisableUIButton?.Invoke(_workTime + _cooldownTime));
        _sequence.AppendCallback(() => _collider.enabled = true);
        _sequence.AppendInterval(_workTime);
        _sequence.AppendCallback(() => _anim.HideSphere());
        _sequence.AppendCallback(() => _collider.enabled = false);
        _sequence.AppendInterval(_cooldownTime);
        _sequence.AppendCallback(() => _isWorking = false);
    }

    private void ResetMagnet()
    {
        if (_sequence != null)
        {
            _sequence.Kill();
        }

        _anim.ResetSphere();
        _collider.enabled = false;
        _isWorking = false;
    }

    private void OnDestroy()
    {
        ResetGame.ResetLevel -= ResetMagnet;
    }
}
