using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotateSpeed;

    private Vector2 _moveDirection;

    private void Update()
    {
        _moveDirection = InputSystem.Input.Player.Move.ReadValue<Vector2>();

        if (_moveDirection != Vector2.zero)
        {
            Move(new Vector3(_moveDirection.x, 0, _moveDirection.y));
            //Move(_moveDirection.x, _moveDirection.y);
        }
    }

    public void Move(Vector3 direction)
    {
        Vector3 offset = _moveSpeed * Time.deltaTime * direction;
        _rigidbody.MovePosition(_rigidbody.position + offset);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * _rotateSpeed);
    }

    // Второй тип управления
    public void Move(float XAxis, float YAxis)
    {
        float moving = _moveSpeed * Time.deltaTime * YAxis;

        _rigidbody.MovePosition(_rigidbody.position + transform.forward * moving);
        transform.rotation *= Quaternion.Euler(0f, XAxis * 50f * _rotateSpeed * Time.deltaTime, 0f);
    }
}
