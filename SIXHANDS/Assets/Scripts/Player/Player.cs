using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 _startPosition;
    private Quaternion _startRotation;

    private void Start()
    {
        _startPosition = transform.position;
        _startRotation = transform.rotation;
        ResetGame.ResetLevel += ResetTransform;
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
