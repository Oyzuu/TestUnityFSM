public class State {

    protected Player _player;
    protected PlayerStateMachine _stateMachine;

    protected State(Player player, PlayerStateMachine stateMachine) {
        this._player = player;
        this._stateMachine = stateMachine;
    }

    public virtual void Enter() { }
    public virtual void Exit() { }
    public virtual void PhysicsUpdate() { }
    public virtual void LogicUpdate() { }
    public virtual void HandleInput() { }
}