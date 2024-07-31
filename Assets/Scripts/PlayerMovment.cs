using UnityEngine;

public class PlayerMovment
{
    private Rigidbody _playerBody = null;
    private float _speed = 0f;

    public Rigidbody PlayerBody
    {
        get { return _playerBody; }
        set { _playerBody = value; }
    }

    public float Speed
    {
        get { return _speed; }
        set { _speed = value; }
    }

    public void Move(Vector2 direction)
    {
        Vector3 moveVector = new Vector3(direction.x, 0, direction.y);

        _playerBody.velocity = moveVector * _speed;

        _playerBody.gameObject.transform.LookAt(_playerBody.transform.position + moveVector);
    }
}
