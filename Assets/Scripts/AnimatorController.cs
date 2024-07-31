using UnityEngine;

public class AnimatorController
{
    private Animator _animator = null;

    public Animator Animator 
    { 
        get { return _animator; } 
        set { _animator = value; }
    }

    public void AnimationMove(Vector2 direction)
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
