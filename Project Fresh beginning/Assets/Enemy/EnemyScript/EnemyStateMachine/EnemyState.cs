using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState
{
    public EnemyBaseScript enemy { get; set; }
    public EnemyStateMachine stateMachine { get; set; }
    public EnemyState(EnemyBaseScript enemy, EnemyStateMachine stateMachine)
    {
        this.enemy = enemy;
        this.stateMachine = stateMachine;
    }

    public virtual void EnterState() { }
    public virtual void ExitState() { }
    public virtual void FrameUpdate() { }
    public virtual void PhysicUpdate() { }
}
