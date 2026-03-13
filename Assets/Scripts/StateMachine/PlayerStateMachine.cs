using System;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    [field: SerializeField] public InputReader InputReader { get; private set; }
    [field: SerializeField] public PlayerStats PlayerStats { get; private set; }
    [field: SerializeField] public CharacterController Controller { get; private set; }
    [field: SerializeField] public ForceReceiver ForceReceiver { get; private set; }
    [field: SerializeField] public Animator Animator { get; private set; }
    [field: SerializeField] public CollisionHandler CollisionHandler { get; private set; }

    private void Start()
    {
        SwitchState(new PlayerMoveState(this));
        CollisionHandler.OnCollideWithHazard += HandleCollideWithHazard;
        CollisionHandler.OnCollideWithObstacle += HandleCollideWithObstacle;
    }

    private void HandleCollideWithHazard()
    {
        SwitchState(new PlayerStumbleState(this));
        Debug.Log("Collided with Hazard");
    }

    private void HandleCollideWithObstacle()
    {
        SwitchState(new PlayerStumbleState(this));
        Debug.Log("Collided with Obstacle");
    }
}
