using UnityEngine;
using DG.Tweening;

[CreateAssetMenu(fileName = "Transform Animation", menuName = "Tween Animation/Create Transform Animation Preset")]
public class TweenAnimPositionalPreset : TweenAnimPreset
{
    [Space(10)]
    [SerializeField]
    private bool _useStartPosition = true;
    [SerializeField]
    private Vector2 _startPosition;
    [Space(10)]
    [SerializeField]
    private Vector2 _targetPosition;

    [SerializeField]
    bool useRelativeTransform;


    public override void PlayAnimation(Transform transform)
    {
        Vector3 relativePos = _targetPosition;
        if (_useStartPosition)
        {
            transform.localPosition = _startPosition;
        }
        if (useRelativeTransform)
        {
           _targetPosition = transform.localPosition + relativePos;

        }
        _tween = transform.DOLocalMove(_targetPosition, _time);
        _targetPosition = relativePos;

        base.PlayAnimation(transform);
    }
}