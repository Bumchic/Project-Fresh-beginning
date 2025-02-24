using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEditor.Search;
using UnityEngine;

public class IdleState : EnemyState
{
    public float TimeToPatrol { get; set; } = 2f;
    public IdleState(EnemyBaseScript enemy, EnemyStateMachine stateMachine): base(enemy, stateMachine)
    {

    }
    public override void EnterState()
    {
        base.EnterState();
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        TimeToPatrolTimer();
        if(enemy.isChasingPlayer)
        {
            enemy.stateMachine.ChangeState(enemy.chasingPlayerState);
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }
    public void TimeToPatrolTimer()
    {
        if(TimeToPatrol <= 0)
        {
            enemy.stateMachine.ChangeState(enemy.patrolState);
        }
        TimeToPatrol -= Time.deltaTime;
    }
}
