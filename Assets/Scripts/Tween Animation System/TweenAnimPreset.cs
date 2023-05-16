using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TweenAnimPreset : ScriptableObject
{
    [SerializeField]
    Ease _easeType = Ease.Linear;
    [Space(5)]
    [SerializeField]
    private bool _loop = false;
    [SerializeField]
    private int _loopCount;
    [SerializeField]
    private LoopType _loopType = LoopType.Restart;
    [Space(5)]
    [SerializeField]
    protected float _time = 1f;
    [SerializeField]
    private float _delay = 0;


    protected Tween _tween = null;

    public Tween Tween { get => _tween; }

    public virtual void PlayAnimation(Transform transform)
    {
        _tween.SetEase(_easeType).SetDelay(_delay);
        if (_loop)
        {
            _tween.SetLoops(_loopCount, _loopType);
        }
    }
}
