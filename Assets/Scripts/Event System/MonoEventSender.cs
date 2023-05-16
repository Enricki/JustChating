using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MonoEventSender : MonoBehaviour
{
    [SerializeField]
    protected GameEvent[] _sendingEvents;
    protected EventSender _sender;

    private void SendEvent()
    {
        _sender.SendEvent();
    }

    private void OnEnable()
    {
     //   ScreenPointPicker.OnMouseDown += CheckForSend;
    }

    private void OnDisable()
    {
    //    ScreenPointPicker.OnMouseDown -= CheckForSend;
    }

    protected virtual void CheckForSend()
    {

    }
    protected void InitSender(GameEvent gameEvent)
    {
        _sender = new EventSender(gameEvent);
    }
}