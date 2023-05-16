using System.Collections.Generic;
using UnityEngine;

public class MonoListener : MonoBehaviour
{
    private List<EventListener> _listeners = new List<EventListener>();

    public virtual void OnEnable()
    {
        foreach (var listener in _listeners)
        {
            listener.Subscribe();
        }
    }

    public virtual void OnDisable()
    {
        foreach (var listener in _listeners)
        {
            listener.UnSubscribe();
        }
    }
    /// <summary>
    /// Add and initialize new listener
    /// </summary>
    /// <param name="gameEvent">Event you want to listen</param>
    /// <param name="pEvent">Method that will Invoke on EventInit</param>
    protected void AddListener(GameEvent gameEvent, EventListener.PublicEvent pEvent)
    {
        EventListener newListener = new EventListener(gameEvent);
        newListener.EventHook += pEvent;
        _listeners.Add(newListener);
    }
}