using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneMiddleState : ShadowState
{
    public float MiddleMoveSpeed { get; set; }
    public ZoneMiddleState(ShadowBase shadow, ShadowStateMachine stateMachine) : base(shadow, stateMachine)
    {

    }
   public override void enterState()
    {
        base.enterState();
        MiddleMoveSpeed = shadow.MoveSpeed * 60 / 100;
    }

    public override void exitState()
    {
        base.exitState();
    }

    public override void FixedUpdateFrame()
    {
        base.FixedUpdateFrame();
        shadow.Move(MiddleMoveSpeed);
    }

    public override void UpdateFrame()
    {
        base.UpdateFrame();
    }
}
