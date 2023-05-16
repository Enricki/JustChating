using UnityEngine;

public class EventSender
{
    private GameEvent _gameEvent;
    public EventSender(GameEvent gameEvent)
    {
        _gameEvent = gameEvent;
    }
    public void SendEvent()
    {
        _gameEvent.EventInit();
    }
}