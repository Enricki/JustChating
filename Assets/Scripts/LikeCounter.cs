using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LikeCounter : MonoBehaviour, IView
{
    [SerializeField]
    private TMP_Text _valueField;
    [SerializeField]
    private AudioSource _source;
    [SerializeField]
    private AudioClip[] _clips;

    private AudioClip _currentClip;

    private int _likesCount;
    public int Likes { get => _likesCount; }

    public UsersMood Mood = UsersMood.neutral;

    private int _combo;
    private int _anticomboCounter;

    public readonly int AntiCombo = 4;
    public int Combo { get => _combo; }
    public int AntiComboCounter { get => _anticomboCounter; }

    private int _randomValue = -1;
    private int _randomCount = -1;


    private void Awake()
    {
        _currentClip = _clips[0];
    }


    private void OnEnable()
    {
        GenerateNewRandom(out _randomValue, out _randomCount);
        _likesCount = 0;
        _combo = 0;
        _anticomboCounter = 0;
        UpdateView();
    }


    public void GenerateNewRandom(out int value, out int count)
    {
        int randomValue = Random.Range(0, 3);
        int randomCount = Random.Range(3, 6);

        value = randomValue;
        count = randomCount;
    }


    public IEnumerator UpdateMood()
    {
        yield return new WaitForSeconds(100f);
        Mood = UsersMood.neutral;
    }



    public void MoodUp()
    {
        StopAllCoroutines();
        StartCoroutine(UpdateMood());
    }


    public void UpdateView()
    {
        int value = _likesCount;
        _valueField.text = value.ToString();
    }


    public void DecreaseCounter()
    {
        _likesCount -= 5;
        Mood = UsersMood.negative;
        _combo = 0;
        UpdateView();
        MoodUp();
    }

    public void UpdateValue(int inputValue)
    {
        int newRandom = -1;
        int newCount = -1;
        if (_randomCount <= 0)
        {
            GenerateNewRandom(out newRandom, out newCount);
            while (newRandom == _randomValue)
            {
                GenerateNewRandom(out newRandom, out newCount);
            }
            _randomValue = newRandom;
            _randomCount = newCount;
        }
        _randomCount--;

        int likesCount = _likesCount;
        if (inputValue == _randomValue)
        {
            likesCount++;
        }
        else
        {
            switch (inputValue)
            {
                case 0:
                    if (_randomValue == 1)
                    {
                        likesCount--;
                    }
                    break;
                case 1:
                    if (_randomValue == 2)
                    {
                        likesCount--;
                    }
                    break;
                case 2:
                    if (_randomValue == 0)
                    {
                        likesCount--;
                    }
                    break;
            }
        }

        //Сравниваем изменения счетчика и меняем значение модификаторов
        int anticombo = 10;


        if (likesCount < _likesCount)
        {
            Mood = UsersMood.negative;
            _anticomboCounter++;
            _combo = 0;
            _currentClip = _clips[1];
        }
        else if (likesCount == _likesCount)
        {
            Mood = UsersMood.neutral;
            _currentClip = _clips[0];
        }
        else if (likesCount > _likesCount)
        {
            Mood = UsersMood.positive;
            _anticomboCounter = 0;
            _combo++;
            likesCount += _combo;
            _currentClip = _clips[2];
        }
        TempAntiCombo = _anticomboCounter;
        if (_anticomboCounter == AntiCombo)
        {
            likesCount -= anticombo;
        }

        _likesCount = likesCount;
        _source.clip = _currentClip;
        _source.Play();
        UpdateView();
        MoodUp();
    }
    public int TempAntiCombo;
}

public enum UsersMood
{
    negative = -1,
    neutral = 0,
    positive = 1
}