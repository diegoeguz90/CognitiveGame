using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTimer : MonoBehaviour
{
    public float _waitTime { get; private set; }

    public void StartTimer(float _duration)
    {
        _waitTime = _duration;
        StartCoroutine("StopWatch");
    }

    IEnumerator StopWatch()
    {
        while(_waitTime > 0)
        {
            _waitTime -= Time.deltaTime;
            UIController.Instance.CountDownTxt.text = _waitTime.ToString("F2");
            yield return null;
        }
        yield return new WaitForEndOfFrame();
        GameManager.Instance.gameStates.Update();
    }
}