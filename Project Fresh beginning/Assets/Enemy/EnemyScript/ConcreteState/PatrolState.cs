using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PatrolState : EnemyState
{
    
    Ray ray;
    
    public PatrolState(Grunt enemy, EnemyStateMachine stateMachine) : base(enemy, stateMachine)
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
        RayCast();
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
        
    }
    public void RayCast()
    {

        RaycastHit2D hit = Physics2D.Raycast(enemy.HeadTransform.transform.position, enemy.HeadTransform.transform.right);
        if(hit)
        {
            Debug.Log("Hit");
        }
        
    }
}
