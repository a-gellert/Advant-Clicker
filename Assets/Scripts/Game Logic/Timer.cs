using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private Image timerImage;

    private Card _card;
    private float _time;
    private float _timeLeft = 0f;

    private IEnumerator StartTimer()
    {
        while (_timeLeft < _time)
        {
            _timeLeft += Time.deltaTime;
            var normalizedValue = Mathf.Clamp(_timeLeft / _time, 0.0f, 1.0f);
            timerImage.fillAmount = normalizedValue;
            yield return null;
        }
    }

    void Update()
    {
        if (_card.Level == 0) return;

        if (_timeLeft == 0f)
        {
            StartCoroutine(StartTimer());
        }


        if (_timeLeft > _time)
        {
            _card.AddBalance();
            _timeLeft = 0f;
            StopAllCoroutines();
            StartCoroutine(StartTimer());
        }
    }

    private void Start()
    {
        _card = GetComponent<Card>();
        _time = _card.Timer;

    }
}