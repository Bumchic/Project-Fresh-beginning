using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasingPlayerState : EnemyState
{
    private Transform playerTransform;

    public ChasingPlayerState(EnemyBaseScript enemy, EnemyStateMachine stateMachine)
        : base(enemy, stateMachine)
    {
       
    }

    public override void EnterState()
    {
        Debug.Log("Chasing Player");
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        // Logic để đuổi theo player
        Vector2 direction = (playerTransform.position - enemy.transform.position).normalized;
        enemy.Move(direction.x * enemy.maxSpeed);
    }
}
