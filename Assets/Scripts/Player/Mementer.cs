using UnityEngine;
using DGMKCollections.Memento.Components;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class Mementer : MonoBehaviour
{
    private float _horizontalInput = 0f;
    private bool _jumpInput = false;

    private GroundChecker2D _groundCheck;
    private Horizontal2DMove _horizontalMoveComponent;
    private JumpComponent _jumpComponent;
    private Animator _animator;


    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _horizontalMoveComponent = GetComponent<Horizontal2DMove>();
        _groundCheck = GetComponent<GroundChecker2D>();
        _jumpComponent = GetComponent<JumpComponent>();
    }

    // Update is called once per frame
    void Update()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");

        _animator.SetFloat("HorizontalMove", _horizontalInput);

        if(_groundCheck.IsGrounded && Input.GetButtonDown("Jump"))
        {
            _jumpInput = true;
            _animator.SetTrigger("Jumping");
        }

    }

    void FixedUpdate()
    {
        DEMOMovement();
    }

    void DEMOMovement()
    {
        _horizontalMoveComponent.Move(_horizontalInput);
        
        if(_groundCheck.IsGrounded && _jumpInput)
        {
            _jumpComponent.Jump();
            _jumpInput = false;
        }
    }
}
