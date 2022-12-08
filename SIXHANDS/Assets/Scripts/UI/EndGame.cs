using System;
using Crystals;
using DG.Tweening;
using Player;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class EndGame : MonoBehaviour
    {
        public static Action StopGame;

        [SerializeField] private Image _background;
        [SerializeField] private Image _infoPanel;
        [SerializeField] private GameObject _positiveText;
        [SerializeField] private GameObject _negativeText;
        [SerializeField] private Health _player;

        private Sequence _sequence;

        private void Start()
        {
            _player.Death += ShowLosePanel;
            CrystalCollector.AllCollected += ShowWinPanel;
            ResetGame.ResetLevel += HidePanel;
            HidePanel();
        }
        
        private void ShowLosePanel()
        {
            _negativeText.SetActive(true);
            ShowPanel();
        }
        
        private void ShowWinPanel()
        {
            _positiveText.SetActive(true);
            ShowPanel();
        }
        
        private void ShowPanel()
        {
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
            CrystalCollector.AllCollected -= ShowWinPanel;
            _player.Death -= ShowLosePanel;
        }
    }
}
