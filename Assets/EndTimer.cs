using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndTimer : MonoBehaviour
{
    [SerializeField]
    private float time;
    [SerializeField]
    private Image timerImage;

    private float _timeLeft = 0f;

    public void OnEnable()
    {
        _timeLeft = time;
        timerImage.fillAmount = 1;
        StartCoroutine(StartTimer());
    }

    private IEnumerator StartTimer()
    {
        while (_timeLeft > 0)
        {
            _timeLeft -= Time.deltaTime;
            var normalizedValue = Mathf.Clamp(_timeLeft / time, 0.0f, 1.0f);
            timerImage.fillAmount = normalizedValue;
            yield return null;
        }
    }
}
