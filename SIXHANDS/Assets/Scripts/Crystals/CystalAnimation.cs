using DG.Tweening;
using UnityEngine;

public class CystalAnimation : MonoBehaviour
{
    [SerializeField] private float _duration = 1.5f;
    [SerializeField] private float _distance = 0.2f;

    private void Start()
    {
        transform.DOMoveY(transform.position.y + _distance, _duration).SetLoops(-1, LoopType.Yoyo);
    }
}
