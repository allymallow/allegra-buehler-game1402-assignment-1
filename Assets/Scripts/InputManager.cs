using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInputActions _playerInputActions; // allowing access to the PlayerInputManager

    public System.Action OnJump;
    
    public System.Action<float> OnMove;
    
    private bool _isPaused = false; // bool to allow pause toggle
    
    void Awake()
    {
        _playerInputActions = new PlayerInputActions();
        _playerInputActions.Enable(); // enabling the input action maps once program runs
    }

    //Enable and disable input actions when pressed/not pressed
    void OnEnable()
    {
        _playerInputActions.Player.Jump.performed += OnJumpPressed;
        _playerInputActions.Player.Pause.performed += OnPausePressed;
    }

    void OnDisable()
    {
        _playerInputActions.Player.Jump.performed -= OnJumpPressed;
        _playerInputActions.Player.Pause.performed -= OnPausePressed;
    }

    void OnJumpPressed(InputAction.CallbackContext context)
    {
      OnJump?.Invoke();
    }

    void OnMovement()
    {
        OnMove?.Invoke(_playerInputActions.Player.Horizontal.ReadValue<float>());
    }

    void OnPausePressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            TogglePauseMenu(); // start pause method when input pressed
        }
    }

    void TogglePauseMenu()
    {
        _isPaused = !_isPaused; // switch _isPaused bool to true/false
        
        Time.timeScale = _isPaused ? 0f : 1f; // if _isPaused true set time scale to 0, if false set to 1.
    }
    
    void Update()
    {
        OnMovement();   
    }
}
