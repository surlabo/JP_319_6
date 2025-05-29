using System.Collections;
using UnityEngine;

public class JumpController : MonoBehaviour
{
    [SerializeField] private Rigidbody _body;
    [SerializeField] private Animator _anim;
    [SerializeField] private float _jumpForce = 5f;
    [SerializeField] private float _detectionDistance = 0.2f;
    [SerializeField] private LayerMask _layerMask;

    private bool _isJumping;
    private bool _isGrounded;
    private Coroutine _jumpCoroutine;

    void Update()
    {
        // Ground check
        _isGrounded = Physics.Raycast(transform.position + Vector3.up * 0.05f, Vector3.down, _detectionDistance, _layerMask);

        // Handle jump input
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded && !_isJumping)
        {
            Jump();
        }

        // Animation logic
        if (_isGrounded)
        {
            _anim.SetBool("IsGrounded", true);
            _anim.SetBool("IsFalling", false);
            _anim.SetBool("IsJumping", false);
            _isJumping = false;
        }
        else
        {
            if (_body.linearVelocity.y > 0.1f)
            {
                _anim.SetBool("IsJumping", true);
                _anim.SetBool("IsFalling", false);
                _anim.SetBool("IsGrounded", false);
            }
            else if (_body.linearVelocity.y < -0.1f)
            {
                _anim.SetBool("IsJumping", false);
                _anim.SetBool("IsFalling", false);
                _anim.SetBool("IsGrounded", false);
            }
            else
            {
                _anim.SetBool("IsJumping", false);
                _anim.SetBool("IsFalling", true);
                _anim.SetBool("IsGrounded", false);
            }
        }

        Debug.DrawRay(transform.position + Vector3.up * 0.05f, Vector3.down * _detectionDistance, Color.red);
    }

    private void Jump()
    {
        _isJumping = true;
        _body.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        _anim.SetBool("IsJumping", true);
        _anim.SetBool("IsFalling", false);
        _anim.SetBool("IsGrounded", false);

        if (_jumpCoroutine != null)
            StopCoroutine(_jumpCoroutine);

        _jumpCoroutine = StartCoroutine(JumpCoroutine());
    }

    IEnumerator JumpCoroutine()
    {
        // Wait until player lands
        yield return new WaitUntil(() => _isGrounded);
        _isJumping = false;
    }
}
