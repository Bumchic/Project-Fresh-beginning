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
        shadow.Move(FarMoveSpeed);
    }

    public override void exitState()
    {
        base.exitState();
        shadow.InZoneFar = false;
        Debug.Log("FarState");
    }

    public override void UpdateFrame()
    {
        base.UpdateFrame();
        if(shadow.InZoneMiddle)
        {
            shadow.stateMachine.ChangeState(shadow.zoneMiddleState);
        }
    }

    public override void FixedUpdateFrame()
    {
        base.FixedUpdateFrame();
        shadow.Move(FarMoveSpeed);
    }
}
