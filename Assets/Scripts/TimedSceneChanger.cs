using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimedSceneChanger : MonoBehaviour
{
    [SerializeField]
    float _timer;
    private void Awake()
    {
        StartCoroutine(ChangeScene(_timer));
    }

    IEnumerator ChangeScene(float timer)
    {
        yield return new WaitForSeconds(timer);
        SceneManager.LoadScene(1);
    }
}
