using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowState
{
    protected ShadowBase shadow { get; set; }
    protected ShadowStateMachine stateMachine { get; set; }

    public ShadowState(ShadowBase shadow, ShadowStateMachine stateMachine)
    {
        this.shadow = shadow;
        this.stateMachine = stateMachine;
    }

    public virtual void enterState() { }
    public virtual void exitState() { }
    public virtual void UpdateFrame() { }
    public virtual void FixedUpdateFrame() { }
}
