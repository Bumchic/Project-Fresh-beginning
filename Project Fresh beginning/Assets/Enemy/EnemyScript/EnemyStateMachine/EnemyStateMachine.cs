using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Collections.Unicode;

public class EnemyStateMachine
{
    public EnemyState enemyState { get; set; }

    public void Initialize(EnemyState InitState)
    {
        enemyState = InitState;
        InitState.EnterState();
    }

    public void ChangeState(EnemyState newState)
    {
        enemyState.ExitState();
        enemyState = newState;
        enemyState.EnterState();
    }
}
