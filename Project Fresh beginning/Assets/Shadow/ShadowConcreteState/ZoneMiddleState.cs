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
        MiddleMoveSpeed = shadow.MoveSpeed * 80 / 100;
        Debug.Log("MiddleState");
        shadow.Move(MiddleMoveSpeed);
    }

    public override void exitState()
    {
        base.exitState();
        shadow.InZoneMiddle = false;
    }

    public override void UpdateFrame()
    {
        base.UpdateFrame();
        

        if (shadow.InZoneFar)
        {
            shadow.stateMachine.ChangeState(shadow.zoneFarState);
        }
        if (shadow.InZoneClose)
        {
            shadow.stateMachine.ChangeState(shadow.zoneCloseState);
        }

    }

    public override void FixedUpdateFrame()
    {
        base.FixedUpdateFrame();
        shadow.Move(MiddleMoveSpeed);
    }

}
