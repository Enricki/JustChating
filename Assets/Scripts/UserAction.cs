using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserAction : MonoBehaviour
{
    private int _action;
    public int Action { get => _action; }
    [SerializeField]
    private LikeCounter _likeCounter;
    [SerializeField]
    private ImageTimer _imageTimer;
    private EventSender _sender;
    private void Awake()
    {
        _sender = new EventSender(Events.Turn);
    }

    public void SendAction(int value)
    {
        _action = value;
        _imageTimer.CyclicCounter();
        _likeCounter.UpdateValue(value);
        _sender.SendEvent();
    }
}
