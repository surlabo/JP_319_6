using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class JumpController : MonoBehaviour
{
    [SerializeField] private Rigidbody _body;
    [SerializeField] private Animator _anim;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _detectionDistance;
    [SerializeField] private float _canJumpDetectionDistance;
    [SerializeField] private LayerMask _layerMask;


    private bool _canJump = true;
    private float _previousPositionY;
    private Coroutine _jumpCoroutine;

    void Start()
    {
        _previousPositionY = transform.position.y;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _canJump)
        {
            _canJump = false;
            _anim.SetTrigger("JumpUp");
            _body.linearVelocity = Vector3.zero;
            _body.AddForce(0, _jumpForce, 0);

            if (_jumpCoroutine == null)
            {
                _jumpCoroutine = StartCoroutine(JumpCoroutine());
            }

        }
        
        
        Debug.DrawRay(transform.position, Vector3.down * _detectionDistance, Color.red);
    }

    IEnumerator JumpCoroutine()
    {
        while (!_canJump)
        {
            yield return null;
            if (transform.position.y < _previousPositionY)
            {
                if (Physics.Raycast(transform.position, Vector3.down, _detectionDistance, _layerMask))
                {
                    _anim.SetTrigger("JumpDown");
                    
                }
                if (Physics.Raycast(transform.position, Vector3.down, _detectionDistance, _layerMask))
                {
                    _canJump = true;
                    StopCoroutine(_jumpCoroutine);
                    _jumpCoroutine = null;
                }
            }

            _previousPositionY = transform.position.y;
        }
        
    }
}
