using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerTransform;


    private void Update()
    {
        transform.position = new Vector3(playerTransform.position.x, 0, transform.position.z);
    }

}
