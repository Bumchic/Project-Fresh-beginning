using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasingPlayerState : EnemyState
{
    private Transform playerTransform; // Loc add
    private float chaseSpeed = 4f; // Loc add
    private float stopChaseDistance = 10f; // Loc add
    public ChasingPlayerState(EnemyBaseScript enemy, EnemyStateMachine stateMachine) : base(enemy, stateMachine)
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform; // Loc add 
    }
    public override void EnterState()
    {
        base.EnterState();
        Debug.Log("Chasing Player");
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        if (playerTransform == null || !enemy.isChasingPlayer)
        {
            stateMachine.ChangeState(enemy.patrolState);
            return;
        }

        // Tính toán khoảng cách tới người chơi
        float distanceToPlayer = Vector2.Distance(enemy.transform.position, playerTransform.position);

        // Nếu người chơi ra khỏi phạm vi đuổi bắt, quay về tuần tra
        if (distanceToPlayer > stopChaseDistance)
        {
            enemy.isChasingPlayer = false;
            stateMachine.ChangeState(enemy.patrolState);
            return;
        }

        // Di chuyển về phía người chơi
        Vector2 direction = (playerTransform.position - enemy.transform.position).normalized;
        enemy.Move(direction.x * chaseSpeed);
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }
}
