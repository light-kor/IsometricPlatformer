using DG.Tweening;
using UnityEngine;

namespace Crystals
{
    public class CrystalAnimation : MonoBehaviour
    {
        [SerializeField] private float _duration = 1.5f;
        [SerializeField] private float _distance = 0.2f;

        private void Start()
        {
            transform.DOMoveY(transform.position.y + _distance, _duration).SetLoops(-1, LoopType.Yoyo);
        }
    }
}
