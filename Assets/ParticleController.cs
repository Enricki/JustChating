using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoListener
{
    [SerializeField]
    Texture2D _good;
    [SerializeField]
    Texture2D _bad;
    [SerializeField]
    Material _material;

    [SerializeField]
    LikeCounter _likeCounter;
    [SerializeField]
    ParticleSystem _particleSystem;


    private void Awake()
    {
        AddListener(Events.Turn, Plush);
        AddListener(Events.DropU, PlayDrop);
    }


    private void PlayDrop()
    {
        _material.SetTexture("_MainTex", _bad);
        _particleSystem.Play();
    }

    private void Plush()
    {
        if (_likeCounter.Mood != UsersMood.neutral)
        {
            if (_likeCounter.Mood == UsersMood.negative)
            {
                if (_likeCounter.TempAntiCombo == _likeCounter.AntiCombo)
                {
                    _material.SetTexture("_MainTex", _bad);
                    _particleSystem.Play();
                    _likeCounter.TempAntiCombo = 0;
                }

            }
            else
            {
                if (_likeCounter.Combo > 1)
                {
                    _material.SetTexture("_MainTex", _good);
                    _particleSystem.Play();
                }
            }
        }
    }
}
