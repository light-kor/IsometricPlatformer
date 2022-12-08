using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _rotateSpeed;
        private Vector2 _moveDirection;

        private void Update()
        {
            _moveDirection = InputSystem.ReadMoveValue();

            if (_moveDirection != Vector2.zero)
            {
                Move(new Vector3(_moveDirection.x, 0, _moveDirection.y));
                //Move(_moveDirection.x, _moveDirection.y);
            }
        }

        private void Move(Vector3 direction)
        {
            var offset = _moveSpeed * Time.deltaTime * direction;
            _rigidbody.MovePosition(_rigidbody.position + offset);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * _rotateSpeed);
        }

        // Second type of movement
        private void Move(float axisX, float axisY)
        {
            var moving = _moveSpeed * Time.deltaTime * axisY;

            _rigidbody.MovePosition(_rigidbody.position + transform.forward * moving);
            transform.rotation *= Quaternion.Euler(0f, axisX * 50f * _rotateSpeed * Time.deltaTime, 0f);
        }
    }
}
