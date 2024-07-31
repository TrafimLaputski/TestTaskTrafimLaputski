using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    [SerializeField] private Rigidbody _playerBody = null;
    [SerializeField] private float _speed = 0f;
    [SerializeField] private Joystick _moveJoystick = null;

    private void Start()
    {
        _moveJoystick.InputAction += Move;
    }

    public void Move(Vector2 direction)
    {
        Vector3 moveVector = new Vector3(direction.x, 0, direction.y);

        _playerBody.velocity = moveVector * _speed;

        _playerBody.gameObject.transform.LookAt(transform.position + moveVector);
    }
}
