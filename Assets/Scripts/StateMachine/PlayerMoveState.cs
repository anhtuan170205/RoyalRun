using UnityEngine;

public class PlayerMoveState : PlayerBaseState
{

    public PlayerMoveState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        
    }

    public override void Tick(float deltaTime)
    {
        Vector3 movement = CalculateMovement();
        Move(movement * StateMachine.PlayerStats.MoveSpeed, deltaTime);
    }

    public override void Exit()
    {
        
    }

    private Vector3 CalculateMovement()
    {
        Vector2 inputMovement = StateMachine.InputReader.MovementValue;
        Vector3 movement = new Vector3(inputMovement.x, 0f, inputMovement.y);
        return movement;
    }
}
