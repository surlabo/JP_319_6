using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotateSpeed = 100f;
    [SerializeField] private float groundCheckDistance = 0.2f;
    [SerializeField] private LayerMask groundMask;

    private Rigidbody _rb;
    private bool _isGrounded;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Ground check using raycast
        _isGrounded = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, groundMask);

        Debug.DrawRay(transform.position, Vector3.down * groundCheckDistance, Color.green);
    }

    private void FixedUpdate()
    {
        if (_isGrounded)
        {
            // Move
            float moveInput = Input.GetAxis("Vertical");
            Vector3 moveDirection = transform.forward * moveInput * moveSpeed;
            _rb.linearVelocity = new Vector3(moveDirection.x, _rb.linearVelocity.y, moveDirection.z);

            // Rotate
            float rotateInput = Input.GetAxis("Horizontal");
            Quaternion deltaRotation = Quaternion.Euler(0f, rotateInput * rotateSpeed * Time.fixedDeltaTime, 0f);
            _rb.MoveRotation(_rb.rotation * deltaRotation);
        }
        else
        {
            // Keep falling smoothly without horizontal control
            _rb.linearVelocity = new Vector3(0, _rb.linearVelocity.y, 0);
        }
    }
}

