using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNormalPunchState : PlayerState
{


    public float Combo2Time { get; set; } = 0.4f;
    public float Combo3Time { get; set; } = 0.6f;
    public PlayerNormalPunchState(Player player, PlayerStateMachine playerStateMachine) : base(player, playerStateMachine)
    {

    }
    public override void AnimationTriggerEvent(Player.AnimationTriggerType triggertype)
    {
        base.AnimationTriggerEvent(triggertype);
        if (triggertype == Player.AnimationTriggerType.PunchToIdle)
        {
            player.playerStateMachine.ChangeState(player.idleState);
        }

    }

    public override void EnterState()
    {
        base.EnterState();
        switch(player.Combo)
        {
            case 0: player.animator.SetTrigger("runningAttack");
                break;
            case 1: player.animator.SetTrigger("Attack1");
                break;
            default: player.Combo = 1;
                player.animator.SetTrigger("Attack1");
                break;
        }
    }

    public override void ExitState()
    {
        base.ExitState();
        player.Combo = -1;
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();

    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }

    public bool ComboTimeCounter(float ComboTime)
    {
        float Timer = ComboTime;
        while(Timer >= 0)
        {
            Timer -= Time.deltaTime;
        }
        return true;
    }
    public void Combo2Attack()
    {
        if (ComboTimeCounter(Combo2Time))
        {
            
        }

    }
}
