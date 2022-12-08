using DG.Tweening;
using UnityEngine;

namespace Weapon
{
    public class MagnetAnimation : MonoBehaviour
    {
        [SerializeField] private MeshRenderer _renderer;
        [SerializeField] private float _scale;
        [SerializeField] private float _fadeTime;

        public void ShowSphere()
        {
            _renderer.enabled = true;
            transform.DOScale(_scale, _fadeTime);
        }

        public void HideSphere() 
        {
            transform.DOScale(0f, _fadeTime).OnComplete(() => _renderer.enabled = false);
        }

        public void ResetSphere()
        {
            transform.DOScale(0f, 0f);
            _renderer.enabled = false;
        }
    }
}
