using UnityEngine;
using DG.Tweening;

public class TweenAnimController : MonoBehaviour
{
    [SerializeField]
    private TweenAnimPreset _appearanceAnimation;
    [SerializeField]
    private TweenAnimPreset _idleAnimation;
    [SerializeField]
    private TweenAnimPreset _exitAnimation;

    private void OnEnable()
    {
        PlayAnim(_appearanceAnimation);
        if (_idleAnimation != null)
        {
            _appearanceAnimation.Tween.OnComplete(PlayIdle); // Переделать в сиквенцию позже
        }
    }

    public void PlayAnim(TweenAnimPreset preset)
    {
        if (preset != null)
        {
            transform.DOKill();
            preset.PlayAnimation(transform);
        }
    }

    public void PlayIdle()
    {
        PlayAnim(_idleAnimation);
    }

    public void PlayExit()
    {
        PlayAnim(_exitAnimation);
        if (_idleAnimation != null)
        {
            _exitAnimation.Tween.OnComplete(PlayIdle);
        }
    }

    public void PlaySome(TweenAnimPreset preset)
    {
        if (preset != null)
        {
            preset.PlayAnimation(transform);
        }

    }
}
