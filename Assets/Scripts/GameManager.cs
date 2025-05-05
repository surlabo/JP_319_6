using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private float stopWatchCount = 0;
    private Coroutine stopWatchCoroutine;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        stopWatchCoroutine = StartCoroutine(StopWatch());
        
    }

    private IEnumerator StopWatch()
    {
        while (true)
        {
            yield return null;
            stopWatchCount += Time.deltaTime;
            Debug.Log(stopWatchCount);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            StopCoroutine(stopWatchCoroutine);
        }
    }

   
}
