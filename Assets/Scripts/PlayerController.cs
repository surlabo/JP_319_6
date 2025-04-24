using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public float maxY, minY;

    private Rigidbody rb;
    

    void Start()
    {

        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);

        if (Input.GetKeyDown(KeyCode.Space))
        { 
            rb.AddForce(0, jumpForce, 0);
        }
        

        if (transform.position.y > maxY || transform.position.y < minY)
        {
            Debug.Log("out of bound");
            DeathController.Instance.Death();
        }
    }


   


}

