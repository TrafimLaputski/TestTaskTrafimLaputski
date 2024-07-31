using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    [SerializeField] private Animator _animator = null;
    [SerializeField] private Joystick _moveJoystick = null;

    private void Start()
    {
        _moveJoystick.InputAction += AnimationMove;
    }

    private void AnimationMove(Vector2 direction)
    {
        if (direction != Vector2.zero)
        {
            _animator.SetBool("isMove", true);
        }
        else
        {
            _animator.SetBool("isMove", false);
        }
    }
}
