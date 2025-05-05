using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    void Start()
    {
        StartCoroutine(DestoryBullet());
    }

    IEnumerator DestoryBullet()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
