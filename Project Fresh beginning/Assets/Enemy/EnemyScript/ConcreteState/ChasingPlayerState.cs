using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class ChasingPlayerState : EnemyState
{
    public ChasingPlayerState(EnemyBaseScript enemy, EnemyStateMachine stateMachine) : base(enemy, stateMachine) { }
/*    enemy.stateMachine.ChangeState(//StateName);
*/
    public override void EnterState()
    {
        base.EnterState(); // like void start
    }

    public override void ExitState()
    {
        base.ExitState(); // stop state and change new state
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate(); // like void update
        enemy.stateMachine.ChangeState(enemy.patrolState);
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate(); // like fix update 
    }
}
