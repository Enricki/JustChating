public abstract class IntCounter: ICounter
{
    private int _value;
    public IntCounter(int value)
    {
        _value = value;
    }
    public abstract void Increase();
    public abstract void Reset();
}