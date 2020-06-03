using System;
using UnityEngine;

public class IdleState : State {

    public IdleState(Player player, PlayerStateMachine stateMachine) : base(player, stateMachine) { }

    private float deadzone = .1f;

    public override void Enter() {
        base.Enter();
        Debug.Log("Enter idle state");
    }

    public override void HandleInput() {
        base.HandleInput();
        var horizontalInput = Input.GetAxis("Horizontal");
        var jumpInput = Input.GetButtonDown("Jump");

        if (Math.Abs(horizontalInput) > deadzone) {
            _stateMachine.ChangeState(_player.moving);
        }

        if (jumpInput) {
            _stateMachine.ChangeState(_player.jumping);
        }
    }

}