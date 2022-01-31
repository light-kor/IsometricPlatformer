using DG.Tweening;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] private Teleport _targetStation;

    private Sequence _sequence;
    private float _delayTime = 1f;
    private bool _readyForUse = true;

    private void OnTriggerEnter(Collider other)
    {
        if (_readyForUse && other.TryGetComponent(out Player player))
        {
            if (_targetStation != null)
            {
                _readyForUse = false;
                Teleportation(other.gameObject);
            }
            else Debug.Log("Отсутствует целевая точка!");        
        }
    }

    private void Teleportation(GameObject player)
    {
        _sequence = DOTween.Sequence();
        _sequence.AppendCallback(() => InputSystem.DisablePlayerInput());
        _sequence.AppendCallback(() => player.transform.position = transform.position + Vector3.up / 1.5f);
        _sequence.AppendInterval(_delayTime);
        _sequence.AppendCallback(() => _targetStation.AcceptPlayer());
        _sequence.AppendCallback(() => player.transform.position = _targetStation.transform.position + Vector3.up / 1.5f);
        _sequence.AppendCallback(() => InputSystem.EnablePlayerInput());
    }

    private void OnTriggerExit(Collider other)
    {
        _readyForUse = true;
    }

    public void AcceptPlayer()
    {
        _readyForUse = false;      
    }
}
