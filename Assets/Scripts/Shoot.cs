using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletSpawnPoint;

    public float shootForce = 300;

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            var bulletClone = Instantiate(bullet,
                    bulletSpawnPoint.position,
                    Quaternion.identity);
            Rigidbody bulletRigidbody = bulletClone.GetComponent<Rigidbody>();
            bulletRigidbody.AddForce(transform.forward * shootForce);

        }


    }

    private void Start()
    {
       
        var z = Calculate(2, 3);
    }

    int Calculate(int x, int y)
    {
        return x + y;
    }
}
