using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasingPlayerState : EnemyState
{
    public GameObject Player { get; set; }
    public Transform PlayerTransform { get; set; }
    public ChasingPlayerState(EnemyBaseScript enemy, EnemyStateMachine stateMachine) : base(enemy, stateMachine)
    {

    }
    public override void EnterState()
    {
        base.EnterState();
        enemy.animator.SetBool("isRunning", true);
        Player = GameObject.Find("MainCharacter");
        if(Player != null)
        {
            PlayerTransform = Player.GetComponent<Transform>();
        }
        else
        {
            enemy.stateMachine.ChangeState(enemy.patrolState);
        }


    }

    public override void ExitState()
    {
        base.ExitState();
        enemy.animator.SetBool("isRunning", false);
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        TurnAround();
        enemy.Move(4);
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }

    public void TurnAround()
    {
        if(PlayerTransform.localPosition.x - enemy.gameObject.transform.localPosition.x > 0f)
        {
            enemy.isFacingRight = 1;
        }
        else
        {
            enemy.isFacingRight = 0;
        }
    }
}
