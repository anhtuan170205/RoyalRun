using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    private Vector2 _movement;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Move(InputAction.CallbackContext context)
    {
        _movement = context.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        Vector3 currentPosition = transform.position;
        Vector3 movementDirection = new Vector3(_movement.x, 0, _movement.y);
        Vector3 newPosition = currentPosition + movementDirection * Time.fixedDeltaTime * _moveSpeed;
        _rigidbody.MovePosition(newPosition);
    }
}
