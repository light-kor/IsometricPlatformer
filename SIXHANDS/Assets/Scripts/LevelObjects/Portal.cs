using DG.Tweening;
using Player;
using UnityEngine;

namespace LevelObjects
{
    public class Portal : MonoBehaviour
    {
        [SerializeField] private Portal _targetStation;

        private Sequence _sequence;
        private float _moveTime = 0.2f;
        private bool _blocked;

        private void OnTriggerEnter(Collider obj)
        {
            if (_blocked || !obj.TryGetComponent(out PlayerStartPosition player)) return;
            if (_targetStation == null) return;
            
            _blocked = true;
            Teleportation(obj.gameObject);
        }

        private void Teleportation(GameObject player)
        {
            _sequence = DOTween.Sequence();
            _sequence.AppendCallback(() => InputSystem.DisablePlayerInput());
            _sequence.AppendCallback(() => player.transform.position = transform.position + Vector3.up / 1.5f);
            _sequence.AppendInterval(_moveTime);
            _sequence.AppendCallback(() => _targetStation.AcceptPlayer());
            _sequence.AppendCallback(() => player.transform.position = _targetStation.transform.position + Vector3.up / 1.5f);
            _sequence.AppendCallback(() => InputSystem.EnablePlayerInput());
        }

        private void OnTriggerExit(Collider other)
        {
            _blocked = false;
        }

        private void AcceptPlayer()
        {
            _blocked = true;      
        }
    }
}
