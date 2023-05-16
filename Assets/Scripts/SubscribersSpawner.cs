using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

public class SubscribersSpawner : MonoBehaviour
{
    [SerializeField]
    private LikeCounter _likeCounter;
    [SerializeField]
    private SubscriberView _positivePrefab;
    [SerializeField]
    private SubscriberView _neutralPrefab;
    [SerializeField]
    private SubscriberView _negativePrefab;

    private List<SubscriberView> _subscribers = new List<SubscriberView>();

    private SubscriberView _currentView;

    private EventSender _sender;

    private void Awake()
    {
        _sender = new EventSender(Events.ChangeSoundLevel);
    }

    private void OnEnable()
    {

        FullCleean();
        StartCoroutine(CoolDownSpawner());

    }


    private void FullCleean()
    {
        for (int i = 0; i < _subscribers.Count; i++)
        {
            Destroy(_subscribers[i].gameObject);
        }
        _subscribers.Clear();
    }
    private void CheckCurrentView()
    {
        switch (_likeCounter.Mood)
        {
            case UsersMood.negative:
                _currentView = _negativePrefab;
                break;
            case UsersMood.neutral:
                _currentView = _neutralPrefab;
                break;
            case UsersMood.positive:
                _currentView = _positivePrefab;
                break;
        }
    }


    private void CleanSubs(int maxCountToClean)
    {
        if (_subscribers.Count > maxCountToClean)
        {
            Destroy(_subscribers[0].gameObject);
            _subscribers.RemoveAt(0);
        }
    }

    private void CreateSubscriber()
    {
        CleanSubs(20);
        CheckCurrentView();
        SubscriberView subView = Instantiate(_currentView, transform);
        _subscribers.Add(subView);

    }

    private IEnumerator CoolDownSpawner()
    {

        CreateSubscriber();
        _sender.SendEvent();
        float randomDelay = Random.Range(4f, 4.2f);
        float temp = _likeCounter.Likes / randomDelay * 0.1f;
        if (temp < 5 && temp > 0)
        {
            randomDelay -= temp;
        }
        else if (temp > 3 && temp > 0)
        {
            temp = 2.5f;
            randomDelay -= temp;
        }
        yield return new WaitForSeconds(randomDelay);
        StartCoroutine(CoolDownSpawner());
    }
}