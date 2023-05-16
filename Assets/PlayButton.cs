using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : MonoBehaviour
{
    [SerializeField]
    GameObject _thisWindow;
    [SerializeField]
    GameObject _nextWindow;
    public void DelayedLoad()
    {
        StartCoroutine(Delay());
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.2f);
        _nextWindow.SetActive(true);
        _thisWindow.SetActive(false);
    }
}
