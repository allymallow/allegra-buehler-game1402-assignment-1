using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float jumpForce = 15f;
    [SerializeField] private InputManager inputManager;
    
    [Header("Ground Check")]
    [SerializeField] private  LayerMask groundLayer;
    [SerializeField] private Vector2 startPointOffset;
    [SerializeField] private float groundCheckDistance;
    
    [SerializeField] private float coyoteTime = 0.2f;
    private float _timer;
    
    private float _horizontalInput = 0;
    private Rigidbody2D _playerRb;

    private bool _isOnGround;
    private bool _hasJumped;
    
    void Awake()
    {
        _playerRb = GetComponent<Rigidbody2D>();
    }

    void OnEnable()
    {
        inputManager.OnJump += HandleJumpInput;
        inputManager.OnMove += HandleMoveInput;
    }

    void OnDisable()
    {
        inputManager.OnJump -= HandleJumpInput;
        inputManager.OnMove -= HandleMoveInput;
    }

    void HandleJumpInput()
    {
        if(_playerRb == null) return;
        bool canCoyoteJump = _timer < coyoteTime;
        if (_isOnGround || (canCoyoteJump && !_hasJumped))
        {
            _playerRb.AddForceY(jumpForce);
            _hasJumped = true;
        }
            
    }

    void HandleMoveInput(float value)
    {
        _horizontalInput = value;
    }

    void Update()
    {
        _timer += Time.deltaTime;
        
    }
    
    void FixedUpdate()
    {
        HandleMovement();
        GroundCheck();
    }

    void HandleMovement()
    {
        _playerRb.linearVelocityX = moveSpeed * _horizontalInput;
    }

    void GroundCheck()
    {
        _isOnGround = Physics2D.Raycast((Vector2)transform.position + startPointOffset, Vector2.down, groundCheckDistance,  groundLayer);
        if (_isOnGround == false)
        {
            _timer = 0f;
        }
        else
        {
            _hasJumped = false;
        }
    }

    void OnDrawGizmos()
    {
        Debug.DrawLine((Vector2)transform.position +  startPointOffset, (Vector2)transform.position +  startPointOffset + Vector2.down * groundCheckDistance, _isOnGround? Color.green : Color.red);
    }
}
