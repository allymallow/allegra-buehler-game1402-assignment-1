using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //variables that allow for player movement & health
        
    [Header("Player Movement")]
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float jumpForce = 15f;
    [SerializeField] private InputManager inputManager;
    
    private float _horizontalInput = 0;
    private Rigidbody2D _playerRb;
    
    [Header("Ground Check")]
    [SerializeField] private  LayerMask groundLayer;
    [SerializeField] private Vector2 startPointOffset; // variable to tell where to start the ground check on the player
    [SerializeField] private float groundCheckDistance; // variable to check how far player is from ground/when they are in the air
    
    [Header("Coyote Time & Time in Air")]
    [SerializeField] private float coyoteTime = 1f; // maximum timeframe to allow for coyote time 
    private float _timer;
    
    private bool _isOnGround;
    private bool _hasJumped;
    

    
    [SerializeField] private AudioSource jumpSound;
    
    void Awake()
    {
        _playerRb = GetComponent<Rigidbody2D>();
    }

    //Input manager handling jump and movement input
    void OnEnable()
    {
        inputManager.OnJump += HandleJumpInput;
        inputManager.OnMove += HandleMoveInput;
    }
    
    //Disabling jump and movement when not actively receiving input from player
    void OnDisable()
    {
        inputManager.OnJump -= HandleJumpInput;
        inputManager.OnMove -= HandleMoveInput;
    }

    void HandleJumpInput()
    {
        if(_playerRb == null) return; // if no rigidbody found on player, stop
        bool canCoyoteJump = _timer < coyoteTime; // bool will only be true if the timer is less than the allowed time for coyote time
        if (_isOnGround || (canCoyoteJump && !_hasJumped)) // allowing jump only if player is on ground OR coyote jump bool is true and player has not already jumped
        {
            _playerRb.AddForceY(jumpForce); // adding upwards force to allow player to jump
            _hasJumped = true;
            jumpSound.Play(); // play the jump sound effect
        }
    }

    void HandleMoveInput(float value)
    {
        _horizontalInput = value;
    }

    void Update()
    {
        _timer += Time.deltaTime; //set the game timer to delta time to ensure accuracy/consistency
        
    }
    
    //ensure ground check and movement input are updating consistently 
    void FixedUpdate()
    {
        HandleMovement();
        GroundCheck();
    }

    void HandleMovement()
    {
        _playerRb.linearVelocityX = moveSpeed * _horizontalInput; // moves the player's rigidbody in time with the player's move speed and input direction
    }

    void GroundCheck()
    {
        _isOnGround = Physics2D.Raycast((Vector2)transform.position + startPointOffset, Vector2.down, groundCheckDistance,  groundLayer);
        if (_isOnGround == false)
        {
          
        }
        else
        {
            _hasJumped = false;
            _timer = 0f; // timer starts when player is grounded to ensure accurate timer for coyote time 
        }
    }

    //once player collides with the win point trigger, switch to the "win game" screen
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Win Point")
            SceneManager.LoadScene(2);
    }
    
    //debug draw to allow me to see the ground check
    void OnDrawGizmos()
    {
        Debug.DrawLine((Vector2)transform.position +  startPointOffset, (Vector2)transform.position +  startPointOffset + Vector2.down * groundCheckDistance, _isOnGround? Color.green : Color.red);
    }

  
}
