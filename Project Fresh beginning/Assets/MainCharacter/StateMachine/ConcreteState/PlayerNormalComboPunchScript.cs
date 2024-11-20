using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNormalComboPunchScript : PlayerState
{
    public float Combo1Time { get; set; }
    public float Combo2Time { get; set; }
    public float Combo3Time { get; set; }
    public PlayerNormalComboPunchScript(Player player, PlayerStateMachine playerStateMachine) : base(player, playerStateMachine)
    {

    }
    public override void AnimationTriggerEvent(Player.AnimationTriggerType triggertype)
    {
        base.AnimationTriggerEvent(triggertype);
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
}
