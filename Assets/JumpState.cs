using UnityEngine;

public class JumpState : State {

    private bool isGrounded;

    public JumpState(Player player, PlayerStateMachine stateMachine) : base(player, stateMachine) { }

    public override void Enter() {
        Debug.Log("Enter jump state");
        isGrounded = false;
        _player.Jump();
    }

    public override void PhysicsUpdate() {
        isGrounded = _player.CheckGroundCollision();
        Debug.Log("is grounded = " + isGrounded);
    }

    public override void LogicUpdate() {
        if (isGrounded) {
            _stateMachine.ChangeState(_player.idle);
        }
    }

}