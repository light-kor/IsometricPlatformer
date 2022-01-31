using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    public static UnityAction StopGame;

    [SerializeField] private Image _background;
    [SerializeField] private Image _infoPanel;
    [SerializeField] private GameObject _positiveText;
    [SerializeField] private GameObject _negativeText;
    [SerializeField] private CrystalCollector _crystalCollector;
    [SerializeField] private Health _player;

    private Sequence _sequence;

    private void Start()
    {
        _player.Death += ShowPanel;
        _crystalCollector.AllCollected += ShowPanel;
        ResetGame.ResetLevel += HidePanel;
        HidePanel();
    }

    private void ShowPanel(bool isWin)
    {
        if (isWin)
            _positiveText.SetActive(true);
        else
            _negativeText.SetActive(true);

        _sequence = DOTween.Sequence();

        _sequence.AppendCallback(() => StopGame?.Invoke());
        _sequence.AppendCallback(() => InputSystem.DisablePlayerInput());
        _sequence.AppendCallback(() => _background.gameObject.SetActive(true));
        _sequence.AppendCallback(() => _infoPanel.gameObject.SetActive(true));

        _sequence.Append(_background.DOFade(0.4f, 1f));
        _sequence.Insert(0, _infoPanel.transform.DOMoveY(-900f, 1f).From());
    }

    private void HidePanel()
    {
        _background.gameObject.SetActive(false);
        _infoPanel.transform.localPosition = Vector3.zero;
        _infoPanel.gameObject.SetActive(false);
        _positiveText.SetActive(false);
        _negativeText.SetActive(false);
    }

    private void OnDestroy()
    {
        ResetGame.ResetLevel -= HidePanel;
        _crystalCollector.AllCollected -= ShowPanel;
        _player.Death -= ShowPanel;
    }
}
