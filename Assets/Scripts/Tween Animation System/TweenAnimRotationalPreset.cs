using UnityEngine;
using DG.Tweening;

[CreateAssetMenu(fileName = "Rotate Animation", menuName = "Tween Animation/Create Rotate Animation Preset")]
public class TweenAnimRotationalPreset : TweenAnimPreset
{ 
    [Space(10)]
    [SerializeField]
    private bool _useStartRotation = true;
    [SerializeField]
    private float _startRotationValue;
    [Space(10)]
    [SerializeField]
    private Vector3 _rotationVector;

    public override void PlayAnimation(Transform transform)
    {
        
        if (_useStartRotation)
        {
            transform.Rotate(new Vector3(0, 0, _startRotationValue));
        }

        _tween = transform.DORotate(_rotationVector, _time);
        base.PlayAnimation(transform);
    }
}