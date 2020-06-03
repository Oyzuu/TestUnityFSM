using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private PlayerStateMachine stateMachine;
    private Rigidbody rigidbody;

    public State idle;
    public State moving;
    public State jumping;

    public LayerMask ground;
    public GameObject groundCaptor;

    void Awake() {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.freezeRotation = true;
    }

    void Start() {
        stateMachine = new PlayerStateMachine();

        idle = new IdleState(this, stateMachine);
        moving = new MoveState(this, stateMachine);
        jumping = new JumpState(this, stateMachine);

        stateMachine.Init(idle);
    }

    void Update() {
        stateMachine.state.HandleInput();
        stateMachine.state.LogicUpdate();
    }

    void FixedUpdate() {
        stateMachine.state.PhysicsUpdate();
    }

    public bool CheckGroundCollision() {
        return Physics.OverlapSphere(groundCaptor.transform.position, .1f, ground.value).Length > 0;
    }

    public void Jump() {
        this.transform.Translate(Vector3.up * .15f);
        rigidbody.AddForce(Vector3.up * 5f, ForceMode.Impulse);
    }

    public void Move(float movement) {
        rigidbody.AddForce(transform.right * movement, ForceMode.VelocityChange);
    }

}