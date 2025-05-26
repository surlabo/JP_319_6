using UnityEngine;

public class ShootWithRaycast : MonoBehaviour
{
    public LayerMask shouldBeRedLayer;
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            // if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, 100, 1 << 3 | 1 << 4))
            if (Physics.Raycast(transform.position, transform.forward, 
                out RaycastHit hit,100, shouldBeRedLayer))
            {
                hit.transform.GetComponent<MeshRenderer>().material.color = Color.red;
            }
        }
    }
}
