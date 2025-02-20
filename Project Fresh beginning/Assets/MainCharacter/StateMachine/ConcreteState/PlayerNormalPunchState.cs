using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNormalPunchState : PlayerState
{

    private int CurrentCombo { get; set; }
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
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();

    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }
    private void ComboPunch1()
    {
        if(CurrentCombo != 1)
        {
            return;
        }

    }

}
