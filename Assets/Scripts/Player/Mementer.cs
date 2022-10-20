using UnityEngine;
using DGMKCollections.Memento.Components;
using System;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class Mementer : MonoBehaviour
{
    public enum MementerState
    {
        PLAYING,
        FINISHED
    }

    private MementerState _state;

    private float _horizontalInput = 0f;
    private bool _jumpInput = false;

    private GroundChecker2D _groundCheck;
    private Horizontal2DMove _horizontalMoveComponent;
    private JumpComponent _jumpComponent;
    private Animator _animator;
    private Rigidbody2D _rigidbody;
    private float _originalGravityScale;

    private bool _allowInputs;
    private Vector3 _initialPosition = Vector3.zero;


    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _horizontalMoveComponent = GetComponent<Horizontal2DMove>();
        _groundCheck = GetComponent<GroundChecker2D>();
        _jumpComponent = GetComponent<JumpComponent>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _originalGravityScale = _rigidbody.gravityScale;

        _state = MementerState.PLAYING;

        _initialPosition = gameObject.transform.position;
    }

    public void EnableInputs()
    {
        _allowInputs = true;
        _rigidbody.gravityScale = _originalGravityScale;
    }

    public void DisableInputs()
    {
        _allowInputs = false;
        _rigidbody.gravityScale = 0f;
        _rigidbody.velocity = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if(_allowInputs)
        {
            _horizontalInput = Input.GetAxisRaw("Horizontal");

            _animator.SetFloat("HorizontalMove", _horizontalInput);
            _animator.SetBool("IsGrounded", _groundCheck.IsGrounded);

            if(_groundCheck.IsGrounded && Input.GetButtonDown("Jump"))
            {
                _jumpInput = true;
                _animator.SetTrigger("Jump");
            }
        }
        else
        {
            _horizontalInput = 0f;
            if(_state == MementerState.FINISHED)
            {
                _animator.SetTrigger("Finish");
                _state = MementerState.FINISHED;
            }
        }

    }

    public void Reset()
    {
        //Initial position
        gameObject.transform.position = _initialPosition;

        //New state playing
        _state = MementerState.PLAYING;
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
