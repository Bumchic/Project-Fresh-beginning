using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBackState : EnemyState
{
    private Rigidbody2D rb;

    public KnockBackState(EnemyBaseScript enemy, EnemyStateMachine stateMachine, Rigidbody2D rb)
        : base(enemy, stateMachine)
    {
        this.rb = rb;
    }

    public override void EnterState()
    {
        Debug.Log("Entering Knockback State");
        rb.velocity = new Vector2(-5f, rb.velocity.y); // Ví dụ về lực đẩy lùi
    }
}
