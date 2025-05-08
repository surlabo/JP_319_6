using System.Collections;
using Unity.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private float stopWatchCount = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int n = 0;
        var cordinates = new Cordinates { x = 0, y = 0 };

        TestOne(out n);
        TestTwo(cordinates);

        Debug.Log(n);
        Debug.Log(cordinates.x + " - " + cordinates.y);
    }


    private bool TestOne(out int x)
    {
        x = 10;
        return true;
    }

    private void TestTwo(Cordinates cordinates) 
    {
        cordinates.x = 20;
    }


    class Cordinates
    {
        public int x; public int y;
    }








    private IEnumerator StopWatch()
    {

        while (true)
        {
            stopWatchCount += Time.deltaTime;
            yield return null;
            Debug.Log(stopWatchCount);
            yield return null;
        }
    }
   

   
}

