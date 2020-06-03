using UnityEngine;

public class MoveState : State {

    private float horizontal;

    public MoveState(Player player, PlayerStateMachine stateMachine) : base(player, stateMachine) { }

    public override void Enter() {
        Debug.Log("Enter move state");
    }

    public override void PhysicsUpdate() {
        _player.Move(horizontal);
    }

    public override void HandleInput() {
        horizontal = Input.GetAxis("Horizontal");
        if (Input.GetButton("Jump")) {
            _stateMachine.ChangeState(_player.jumping);
        }
    }

}