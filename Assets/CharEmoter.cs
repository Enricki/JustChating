using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharEmoter : MonoListener
{
    [SerializeField]
    private AudioSource _audioSource;
    [SerializeField]
    private AudioClip[] _goodClips;
    [SerializeField]
    private AudioClip[] _badClips;
    [SerializeField]
    private AudioClip _MegaClip;
    [Space(20)]
    [SerializeField]
    private LikeCounter _likeCounter;
    [SerializeField]
    private UserAction _action;
    [SerializeField]
    private Image _image;
    [Space(20)]
    [SerializeField]
    private Sprite _normalIdle;
    [SerializeField]
    private Sprite _badIdle;
    [SerializeField]
    private Sprite _goodIdle;
    [Space(20)]
    [SerializeField]
    private Sprite _joke;
    [SerializeField]
    private Sprite _story;
    [SerializeField]
    private Sprite _aggro;
    [Space(20)]
    [SerializeField]
    private Sprite _pog;
    [SerializeField]
    private Sprite _buggurt;


    private Sprite _currentIdle;
    private Sprite _currentSprite;

    private void Awake()
    {
        AddListener(Events.Turn, UpdateIdleEmotion);
        AddListener(Events.Turn, UpdateEmote);
        AddListener(Events.DropU, UpdateIdleEmotion);
    }

    private void UpdateEmote()
    {
        StopAllCoroutines();
        StartCoroutine(UpdateToIdle());
    }

    public override void OnEnable()
    {
        base.OnEnable();
        _currentIdle = _normalIdle;
        _currentSprite = _currentIdle;
        _image.sprite = _currentSprite;
    }





    //Установка при количестве лайков
    private void UpdateIdleEmotion()
    {
        if (_likeCounter.Likes < -10)
        {
            _currentIdle = _badIdle;
        }
        else if (_likeCounter.Likes > 0 && _likeCounter.Likes < 10)
        {
            _currentIdle = _normalIdle;
        }
        else if (_likeCounter.Likes > 10)
        {
            _currentIdle = _goodIdle;
        }
        _image.sprite = _currentIdle;
    }

    //Установка при на жатии на клавишу
    private void UpdateOnActionEmotion()
    {
        if (_action.Action == 0)
        {
            _currentSprite = _joke;
        }
        else if (_action.Action == 1)
        {
            _currentSprite = _story;
        }
        else if (_action.Action == 2)
        {
            _currentSprite = _aggro;
        }
        _image.sprite = _currentSprite;
    }

    private IEnumerator UpdateToIdle()
    {
        UpdateOnActionEmotion();
        yield return new WaitForSeconds(1f);
        StartCoroutine( Wait());
    }

    //Установка при большом комбо
    private IEnumerator Wait()
    {
        if (_likeCounter.AntiComboCounter >= _likeCounter.AntiCombo)
        {
            int index = Random.Range(0, _badClips.Length);
            _audioSource.clip = _badClips[index];
            if (_likeCounter.Mood == UsersMood.negative)
            {
                _image.sprite = _buggurt;
                _audioSource.Play();
            }
            yield return new WaitForSeconds(1f);
            _image.sprite = _currentIdle;
        }
        else
        {
            _image.sprite = _currentIdle;
        }


        if (_likeCounter.Combo >= 5)
        {
            if (_likeCounter.Combo >= 10)
            {
                _audioSource.clip = _MegaClip;
            }
            else
            {
                int index = Random.Range(0, _goodClips.Length);
                _audioSource.clip = _goodClips[index];
            }
            if (_likeCounter.Mood == UsersMood.positive)
                {
                    _image.sprite = _pog;
                    _audioSource.Play();
                }
            yield return new WaitForSeconds(1f);
            _image.sprite = _currentIdle;
        }
        else
        {
            _image.sprite = _currentIdle;
        }
    }
}