using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MagnetButton : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Button _button;
    [SerializeField] private Magnet _magnet;

    private Coroutine _coroutine;

    private void Start()
    {
        ResetGame.ResetLevel += ResetButton;
        _magnet.DisableUIButton += StartTimer;
        ResetButton();
    }

    private void StartTimer(float time)
    {
        _button.interactable = false;
        _text.gameObject.SetActive(true);

        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(Countdown(time));
    }

    private IEnumerator Countdown(float time)
    {
        double progress = time;

        while (progress > 0)
        {
            progress -= Time.deltaTime;
            _text.text = Math.Round(progress, 1).ToString();
            yield return null;
        }

        _button.interactable = true;
        _text.gameObject.SetActive(false);
    }

    private void ResetButton()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _button.interactable = true;
        _text.gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        ResetGame.ResetLevel -= ResetButton;
        _magnet.DisableUIButton -= StartTimer;
    }
}
