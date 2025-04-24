using UnityEngine;

public class PillerController : MonoBehaviour
{
    public GameObject pillerPrefab;
    public int pillersCount;
    public float distanceBetweenPillers;

    private void Start()
    {
        for (int i = 0; i < pillersCount; i++)
        {
            Instantiate(pillerPrefab, new Vector3(i * distanceBetweenPillers, Random.Range(-3f, 3f), 0), 
                Quaternion.identity);
        }
    }
}
