using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : EnemyState
{
    public IdleState(EnemyBaseScript enemy, EnemyStateMachine stateMachine)
        : base(enemy, stateMachine) { }

    public override void EnterState()
    {
        Debug.Log("Entering Idle State");
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        // Logic khi kẻ địch ở trạng thái chờ
    }
}
