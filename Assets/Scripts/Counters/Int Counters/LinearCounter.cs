public class LinearCounter : IntCounter
{
    private int _currentValue;
    private int _initValue;

    public int Value { get => _currentValue; }

    public LinearCounter(int value) : base(value)
    {
        _currentValue = value;
        _initValue = value;
    }
    public override void Increase()
    {
        _currentValue++;
    }

    public override void Reset()
    {
        _currentValue = _initValue;
    }
}