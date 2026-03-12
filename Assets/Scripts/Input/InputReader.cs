using System;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "InputReader", menuName = "Scriptable Objects/InputReader")]
public class InputReader : ScriptableObject, PlayerControls.IPlayerActions
{
    public Vector2 MovementValue { get; private set; }
    public event Action JumpEvent;

    private PlayerControls _playerControls;

    private void OnEnable()
    {
        _playerControls = new PlayerControls();
        _playerControls.Player.SetCallbacks(this);
        _playerControls.Player.Enable();
    }

    private void OnDisable()
    {
        _playerControls.Player.Disable();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        MovementValue = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (!context.performed) { return; }
        JumpEvent?.Invoke();
    }
}
