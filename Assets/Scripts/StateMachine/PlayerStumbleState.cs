using UnityEngine;

public class PlayerStumbleState : PlayerBaseState
{
    private readonly int STUMBLE_HASH = Animator.StringToHash("Stumble");
    private const float CROSS_FADE_DURATION = 0.1f;
    public PlayerStumbleState(PlayerStateMachine stateMachine) : base(stateMachine) {}

    public override void Enter()
    {
        StateMachine.Animator.CrossFade(STUMBLE_HASH, CROSS_FADE_DURATION);
    }

    public override void Tick(float deltaTime)
    {
        if (GetNormalizedTime(StateMachine.Animator, "Stumble") >= 1f)
        {
            ReturnToLocomotion();
        }
    }

    public override void Exit() { }

}
