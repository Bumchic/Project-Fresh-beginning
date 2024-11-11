using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockbackEffect : EnemyState
{
    private float knockbackDuration;
    private float knockbackStartTime;
    private float knockbackForce;
    private Vector2 knockbackDirection;

    private Rigidbody2D rigidbody;
    public KnockbackEffect(EnemyBaseScript enemy, EnemyStateMachine stateMachine, Rigidbody2D rigidbody) : base(enemy, stateMachine)
    {
        this.rigidbody = rigidbody;
    }

    // set knockback information
    public void SetKnockbackData(Vector2 direction, float force, float duration)
    {
        knockbackDirection = direction;
        knockbackDuration = duration;
        knockbackForce = force;
    }

    public override void EnterState()
    {
        base.EnterState();
        knockbackStartTime = Time.time;

        // Execute knockback
        rigidbody.velocity = knockbackDirection * knockbackForce;
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        // Check if knockback timeout is over then switch to Idle state or other state
        if (Time.time >= knockbackStartTime + knockbackDuration)
        {
           /* stateMachine.ChangeState(enemy.idleState);*/

        }
    }

    public override void ExitState()
    {
        base.ExitState();
/*        rigidbody = Vector2.zero; // Stop movement when exiting state
*/    }
}
