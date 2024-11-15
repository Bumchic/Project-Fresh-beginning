using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PatrolState : EnemyState
{
    public PatrolState(EnemyBaseScript enemy, EnemyStateMachine stateMachine) : base(enemy, stateMachine)
    {

    }
    public override void EnterState()
    {
        base.EnterState();       
        Debug.Log("Patrol");
        enemy.animator.SetBool("isWalking", true);
    }

    public override void ExitState()
    {
        base.ExitState();
        enemy.animator.SetBool("isWalking", false);
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        enemy.Move(2);
        enemy.HitWallCheck();
        FaceOtherWay();
        if(enemy.isChasingPlayer)
        {
            enemy.stateMachine.ChangeState(enemy.chasingPlayerState);
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
        
    }

    public void FaceOtherWay()
    {
        if (enemy.WalkingIntoWall == true)
        {
            enemy.isFacingRight = 1 - enemy.isFacingRight;
        }
    }

}
