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
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        enemy.Move(5);
        enemy.HitWallCheck();
        FaceOtherWay();
        

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
