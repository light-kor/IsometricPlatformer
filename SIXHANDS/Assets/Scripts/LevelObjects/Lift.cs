using DG.Tweening;
using UnityEngine;

namespace LevelObjects
{
    public class Lift : MonoBehaviour
    {
        [SerializeField] private float _distance;
        [SerializeField] private float _duration;
        [SerializeField] private float _delay;

        private Sequence _sequence;
        private float _startPositionY;

        private void Start()
        {
            _startPositionY = transform.position.y;
            StartAnimation();
        }

        private void StartAnimation()
        {
            _sequence = DOTween.Sequence();

            _sequence.AppendInterval(_delay);
            _sequence.Append(transform.DOMoveY(_startPositionY + _distance, _duration));
            _sequence.AppendInterval(_delay);
            _sequence.Append(transform.DOMoveY(_startPositionY, _duration));

            _sequence.SetLoops(-1, LoopType.Restart);
        }
    }
}
