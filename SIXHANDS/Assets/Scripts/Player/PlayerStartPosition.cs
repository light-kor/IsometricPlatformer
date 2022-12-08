using UI;
using UnityEngine;

namespace Player
{
    public class PlayerStartPosition : MonoBehaviour
    {
        private Vector3 _startPosition;
        private Quaternion _startRotation;

        private void Start()
        {
            ResetGame.ResetLevel += ResetTransform;
            _startPosition = transform.position;
            _startRotation = transform.rotation;
        }

        private void ResetTransform()
        {
            transform.position = _startPosition;
            transform.rotation = _startRotation;
        }

        private void OnDestroy()
        {
            ResetGame.ResetLevel -= ResetTransform;
        }
    }
}
