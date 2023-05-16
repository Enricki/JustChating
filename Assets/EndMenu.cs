using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EndMenu : MonoListener
{
    [SerializeField]
    private LikeCounter _likeCounter;
    [Space(20)]
    [SerializeField]
    private GameObject _LooseMenu;
    [SerializeField]
    private GameObject _WinMenu;
    [SerializeField]
    private GameObject _endTimer;
    [Space(20)]
    [SerializeField]
    private TMP_Text _bestValue;
    [SerializeField]
    private TMP_Text _currentValue;
    [Space(20)]
    [SerializeField]
    private Button[] _buttons;


    private int _best = 100;
    private int _current = 0;

    private void Awake()
    {
        AddListener(Events.Turn, CheckEndGame);
        AddListener(Events.DropU, CheckEndGame);
    }

    private void CheckEndGame()
    {
        if (_likeCounter.Likes >= 100)
        {
            _endTimer.SetActive(true);
            StartCoroutine(EndTimer());
        }
        else if (_likeCounter.Likes <= -100)
        {
            Time.timeScale = 0;
            _LooseMenu.SetActive(true);
            for (int i = 0; i < _buttons.Length; i++)
            {
                _buttons[i].interactable = false;
            }
        }
    }

    private IEnumerator EndTimer()
    {
        yield return new WaitForSeconds(20);
        _endTimer.SetActive(false);
        Time.timeScale = 0;
        _current = _likeCounter.Likes;
        if (_current > _best)
        {
            _best = _current;
        }

        _WinMenu.SetActive(true);
        for (int i = 0; i < _buttons.Length; i++)
        {
            _buttons[i].interactable = false;
        }

        _bestValue.text = _best.ToString();
        _currentValue.text = _current.ToString();
        StopAllCoroutines();
    }
}
