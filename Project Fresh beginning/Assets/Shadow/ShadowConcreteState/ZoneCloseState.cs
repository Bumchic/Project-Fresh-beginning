using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneCloseState : ShadowState
{
    public float CloseMoveSpeed { get; set; }
    public ZoneCloseState(ShadowBase shadow, ShadowStateMachine stateMachine) : base(shadow, stateMachine)
    {
            
    }
    public override void enterState()
    {
        base.enterState();
        CloseMoveSpeed = shadow.MoveSpeed * 60 / 100;
    }

    public override void exitState()
    {
        base.exitState();
    }

    public override void FixedUpdateFrame()
    {
        base.FixedUpdateFrame();
        shadow.Move(CloseMoveSpeed);

    }

    public override void UpdateFrame()
    {
        base.UpdateFrame();
    }
}
