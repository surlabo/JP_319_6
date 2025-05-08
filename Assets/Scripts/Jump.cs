using UnityEngine;

public class Jump : MonoBehaviour
{
    public float jumpForce = 300;
    public float jumpDetectionDistance = 1;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Physics.Raycast(transform.position, Vector3.down, jumpDetectionDistance))
            {
                GetComponent<Rigidbody>().AddForce(0, jumpForce, 0);
            }
        }
        Debug.DrawRay(transform.position, Vector3.down * jumpDetectionDistance, Color.red);
    }
}
