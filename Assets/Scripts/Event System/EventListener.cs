public class EventListener
{
    private GameEvent _gameEvent;

    public delegate void PublicEvent();
    public event PublicEvent EventHook;

    public EventListener(GameEvent gameEvent)
    {
        _gameEvent = gameEvent;
    }

    public void EventRaised()
    {
        EventHook?.Invoke();
    }

    public void Subscribe(PublicEvent pEvent)
    {
        EventHook += pEvent;
        _gameEvent.AddListener(this);
    }

    public void UnSubscribe(PublicEvent pEvent)
    {
        EventHook -= pEvent;
        _gameEvent.RemoveListener(this);
    }

    public void Subscribe()
    {
        _gameEvent.AddListener(this);
    }

    public void UnSubscribe()
    {
        _gameEvent.RemoveListener(this);
    }
}