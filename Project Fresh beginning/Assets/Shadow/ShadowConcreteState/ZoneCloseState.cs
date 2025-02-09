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
        Debug.Log("CloseState");
        CloseMoveSpeed = shadow.MoveSpeed * 50 / 100;
        shadow.Move(CloseMoveSpeed);
    }

    public override void exitState()
    {
        base.exitState();
        shadow.InZoneClose = false;
    }

  

    public override void UpdateFrame()
    {
        base.UpdateFrame();
        
        if (shadow.InZoneMiddle)
        {
            shadow.stateMachine.ChangeState(shadow.zoneMiddleState);
        }
    }
    public override void FixedUpdateFrame()
    {
        base.FixedUpdateFrame();
        shadow.Move(CloseMoveSpeed);

    }
}
