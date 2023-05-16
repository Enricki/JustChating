using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollSlider : MonoListener
{
    [SerializeField]
    ScrollRect _scrollRect;

    private void Awake()
    {
        AddListener(Events.ChangeSoundLevel, DelayedScroll);
    }

    private void ScrollDown()
    {
        _scrollRect.verticalNormalizedPosition = 0;
    }

    private void DelayedScroll()
    {
        StartCoroutine(Delay());
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.1f);
        ScrollDown();
    }
}
