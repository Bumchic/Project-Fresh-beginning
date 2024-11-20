using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine
{
    public EnemyState enemyState { get; private set; }
    //public IdleState idleState;
    //public KnockBackState knockbackState;

    //private EnemyBaseScript enemy;


    //public EnemyStateMachine(EnemyBaseScript enemy, Rigidbody2D rb)
    //{
    //    this.enemy = enemy;
    //   /* idleState = new IdleState(enemy, this); // LOC ADD*/
    //    //knockbackState = new KnockBackState(enemy, this);
    //}

    public void Initialize(EnemyState initialState)
    {
        enemyState = initialState;
        enemyState.EnterState();
    }

    public void ChangeState(EnemyState newState)
    {
        enemyState.ExitState();
        enemyState = newState;
        enemyState.EnterState();
    }

    //public void Update()
    //{
    //    enemyState.FrameUpdate();
    //}
}
