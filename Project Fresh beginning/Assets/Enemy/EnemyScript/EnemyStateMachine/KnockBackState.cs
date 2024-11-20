using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBackState : EnemyState
{
    private Rigidbody2D rb;

    public KnockBackState(EnemyBaseScript enemy, EnemyStateMachine stateMachine) : base(enemy, stateMachine)
    {
        
    }

    public override void EnterState()
    {
        Debug.Log("Entering Knockback State");
        rb.velocity = new Vector2(-5f, rb.velocity.y); // Ví dụ về lực đẩy lùi
    }

    public override void ExitState() { }
    public override void FrameUpdate() { }
    public override void PhysicUpdate() { }

}
