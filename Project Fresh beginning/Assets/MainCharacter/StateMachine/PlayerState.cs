using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    protected Player player;
    protected PlayerStateMachine playerstatemachine;

    public PlayerState(Player player, PlayerStateMachine playerstatemachine)
    {
        this.player = player;
        this.playerstatemachine = playerstatemachine;
    }

    public virtual void EnterState() { }
    public virtual void ExitState() { }
    public virtual void FrameUpdate() { }
    public virtual void PhysicUpdate() { }
    public virtual void AnimationTriggerEvent(Player.AnimationTriggerType triggertype) { }
}
