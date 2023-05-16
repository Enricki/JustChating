using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ImageTimer : MonoListener
{
    [SerializeField]
    private LikeCounter _likeCounter;
    [SerializeField]
    private float time;
    [SerializeField]
    private Image timerImage;

    private float _timeLeft = 0f;

    private EventSender _sender;

    private void Awake()
    {
        _sender = new EventSender(Events.DropU);
    }

    public override void OnEnable()
    {
        base.OnEnable();
        CyclicCounter();
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
        _likeCounter.DecreaseCounter();
        _sender.SendEvent();
        _timeLeft = time;
        StartCoroutine(StartTimer());
    }




    private void Reset()
    {
        StopAllCoroutines();
        _timeLeft = time;
    }

    public void CyclicCounter()
    {
        Reset();
        StartCoroutine(StartTimer());
    }

    public void ResetTimer()
    {
        StopAllCoroutines();
        _timeLeft = time;
        timerImage.fillAmount = 1;
    }
}