using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ResetGame : MonoBehaviour
{
    public static UnityAction ResetLevel;

    [SerializeField] private Image _image;
    private Sequence _sequence;

    private void Start()
    {
        _image.gameObject.SetActive(false);
        InputSystem.Input.General.ResetLevel.performed += ctx => ResetInFadeTransition();
    }

    private void ResetInFadeTransition()
    {
        _sequence = DOTween.Sequence();

        _sequence.AppendCallback(() => InputSystem.Input.General.Disable());
        _sequence.AppendCallback(() => InputSystem.DisablePlayerInput());
        _sequence.AppendCallback(() => _image.gameObject.SetActive(true));

        _sequence.Append(_image.DOFade(1f, 1f));
        _sequence.AppendCallback(() => ResetLevel?.Invoke());
        _sequence.AppendInterval(0.5f);
        _sequence.Append(_image.DOFade(0f, 1f));
        _sequence.AppendInterval(1f);

        _sequence.AppendCallback(() => _image.gameObject.SetActive(false));
        _sequence.AppendCallback(() => InputSystem.EnablePlayerInput());
        _sequence.AppendCallback(() => InputSystem.Input.General.Enable());
    }
}
