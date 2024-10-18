using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneFarState : ShadowState
{
    public float FarMoveSpeed { get; set; }
    public ZoneFarState(ShadowBase shadow, ShadowStateMachine stateMachine) : base(shadow, stateMachine)
    {

    }
   public override void enterState()
    {
        base.enterState();
        FarMoveSpeed = shadow.MoveSpeed;
    }

    public override void exitState()
    {
        base.exitState();
    }

    public override void FixedUpdateFrame()
    {
        base.FixedUpdateFrame();
        shadow.Move(FarMoveSpeed);
    }

    public override void UpdateFrame()
    {
        base.UpdateFrame();
    }
}
