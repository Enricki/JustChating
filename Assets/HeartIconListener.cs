using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartIconListener : MonoListener
{
    [SerializeField]
    TweenAnimPreset[] _presets;
    [SerializeField]
    LikeCounter _likeCounter;
    [SerializeField]
    TweenAnimController _tweenAnimController;
    [SerializeField]
    Image _image;
    [SerializeField]
    Sprite[] _sprites;

    Vector3 _start;
    private void Awake()
    {
        _start = transform.position;
        AddListener(Events.Turn, ChangeIcon);
        AddListener(Events.Turn, PlayAnims);

    }

    private void ChangeIcon()
    {
        if (_likeCounter.Likes < 0)
        {
            _image.sprite = _sprites[2];
        }
        else if (_likeCounter.Likes > 0 && _likeCounter.Likes < 10)
        {
            _image.sprite = _sprites[0];
        }
        else if(_likeCounter.Likes >=10)
        {
            _image.sprite = _sprites[1];

        }
    }

    private void PlayAnims()
    {
        _tweenAnimController.transform.DOKill();
        _tweenAnimController.PlaySome(_presets[0]);
        _tweenAnimController.PlaySome(_presets[1]);
        transform.position = _start;
    }
}
