using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PaladinController : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private void Update()
    {
        animator.SetFloat("Runing", Input.GetAxis("Vertical"));

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            animator.SetTrigger("Attack");
        }


    }
}
