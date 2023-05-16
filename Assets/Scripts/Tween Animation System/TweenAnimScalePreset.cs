using UnityEngine;
using DG.Tweening;

[CreateAssetMenu(fileName = "Scale Animation", menuName = "Tween Animation/Create Scale Animation Preset")]
public class TweenAnimScalePreset : TweenAnimPreset
{
    [Space(10)]
    [SerializeField]
    private bool _useStartValue = true;
    [SerializeField]
    private Vector2 _startScale = Vector2.one;
    [Space(10)]
    [SerializeField]
    private Vector2 _targetScale = Vector2.one;

    public override void PlayAnimation(Transform transform)
    {
        if (_useStartValue)
        {
            transform.localScale = _startScale;
        }

        _tween = transform.DOScale(_targetScale, _time);

        base.PlayAnimation(transform);
    }
}
