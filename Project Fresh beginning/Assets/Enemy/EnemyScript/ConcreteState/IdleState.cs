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
    private CancellationTokenSource cts;
    private CancellationToken ct;
    private bool finishedWaiting;
    Thread thread;
    public IdleState(EnemyBaseScript enemy, EnemyStateMachine stateMachine): base(enemy, stateMachine)
    {
        cts = new CancellationTokenSource();
        finishedWaiting = false;
        thread = Thread.CurrentThread;
    }
    public override void EnterState()
    {
        base.EnterState();
        
        CancellationToken ct = cts.Token;
        try
        {
            Task.Run(() =>
            {
                Task.Delay(2000).Wait(ct);
                Debug.Log(ct.IsCancellationRequested);
                if (ct.IsCancellationRequested)
                {
                    ct.ThrowIfCancellationRequested();
                }
                Dispatcher.Enqueue(() =>
                {
                    enemy.stateMachine.ChangeState(enemy.patrolState);
                }); 
            }, ct);
        } catch(OperationCanceledException)
        {

        }
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        if(enemy.isChasingPlayer)
        {
            cts.Cancel();
            enemy.stateMachine.ChangeState(enemy.chasingPlayerState);
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }
}
