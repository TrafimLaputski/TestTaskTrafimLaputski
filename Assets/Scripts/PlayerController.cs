using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Move Settings")]
    [SerializeField] private float _speed = 0f;
    [SerializeField] private Rigidbody _playerBody = null;
    [SerializeField] private Joystick _joystickMove = null;

    [Space(10)]
    [Header("Animator Settings")]
    [SerializeField] private Animator _playerAnimator = null;

    private PlayerMovment _playerMovment = new PlayerMovment();
    private AnimatorController _animatorController = new AnimatorController();

    private void Start()
    {
        PlayerAssembly();
        AnimatorAssembly();
    }

    private void PlayerAssembly()
    {
        _playerMovment.PlayerBody = _playerBody;
        _playerMovment.Speed = _speed;
        _joystickMove.InputAction += _playerMovment.Move;
    }

    private void AnimatorAssembly()
    {
        _animatorController.Animator = _playerAnimator;
        _joystickMove.InputAction += _animatorController.AnimationMove;
    }
}
