using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameEvent", menuName = "Events/Create Game Event")]
public class GameEvent : ScriptableObject
{
    private List<EventListener> listeners = new List<EventListener>();

    private void OnEnable() => hideFlags = HideFlags.DontUnloadUnusedAsset;
    public void AddListener(EventListener listener)
    {
        listeners.Add(listener);
    }

    public void RemoveListener(EventListener listener)
    {
        listeners.Remove(listener);
    }

    public void EventInit()
    {
        foreach (var listener in listeners)
        {
            int listenersCount = listeners.Count;
            listener.EventRaised();
            if (listeners.Count != listenersCount)
            {
                break;
            }
        }
    }
}