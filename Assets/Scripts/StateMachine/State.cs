using UnityEngine;

public abstract class State
{
    public abstract void Enter();
    public abstract void Tick(float deltaTime);
    public abstract void Exit();

    protected float GetNormalizedTime(Animator animator, string tag)
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        AnimatorStateInfo nextStateInfo = animator.GetNextAnimatorStateInfo(0);

        if (animator.IsInTransition(0) && nextStateInfo.IsTag(tag))
        {
            return nextStateInfo.normalizedTime;
        }
        else if (!animator.IsInTransition(0) && stateInfo.IsTag(tag))
        {
            return stateInfo.normalizedTime;
        }
        return 0f;
    }
}
