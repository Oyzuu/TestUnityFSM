public class PlayerStateMachine {

    private State _state;
    public State state { get { return _state; } }

    public void Init(State initialState) {
        _state = initialState;
        _state.Enter();
    }

    public void ChangeState(State state) {
        _state.Exit();
        _state = state;
        _state.Enter();
    }

}