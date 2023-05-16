public class CyclicCounter : IntCounter
{
    private int _initValue;
    private int _currentValue;
    private int _cyclesCount;
    private int _startValue;
    private int[] _cycles;
    public int Value { get => _currentValue; }

    public CyclicCounter(int startValue, int value, int cyclesCount) : base(value)
    {
        _startValue = startValue;
        _currentValue = value;
        _initValue = value;
        _cyclesCount = cyclesCount;

        _cycles = new int[_cyclesCount];
        int indexer = startValue;
        for (int i = 0; i < cyclesCount; i++)
        {
            _cycles[i] = indexer;
            indexer++;
        }
    }

    public override void Increase()
    {
        if (_currentValue == _cycles[_cycles.Length - 1])
        {
            _currentValue = _startValue;
        }
        else _currentValue++;

    }

    public override void Reset()
    {
        _currentValue = _initValue;
    }
}