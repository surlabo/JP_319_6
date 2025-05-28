using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class JumpController : MonoBehaviour
{
    [SerializeField] private Rigidbody _body;
    [SerializeField] private Animator _anim;

    [SerializeField] private float _jumpForce;
    [SerializeField] private float _detectionDistance;

    [SerializeField] private LayerMask _layerMask;


    private bool _isJumping;
    private Coroutine _jumpCoroutine;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            Jump();
        }


        Debug.DrawRay(transform.position, Vector3.down * _detectionDistance, Color.red);
    }


    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, _detectionDistance, _layerMask);
    }

    private void Jump()
    {
        _isJumping = true;
        _anim.SetTrigger("JumpUp");
        _body.AddForce(Vector3.up * _jumpForce); // Use Impulse for jumping
        if (_jumpCoroutine != null)
            StopCoroutine(_jumpCoroutine);

        _jumpCoroutine = StartCoroutine(JumpCoroutine());
    }

    IEnumerator JumpCoroutine()
    {
        bool hasStartedFalling = false;

        while (_isJumping)
        {
            // Detect falling
            if (!hasStartedFalling && _body.linearVelocity.y < 0)
            {
                hasStartedFalling = true;
                _anim.SetTrigger("JumpDown");
            }

            // Detect landing
            if (hasStartedFalling && IsGrounded())
            {
                _isJumping = false;
            }

            yield return null;
        }
    }
}
