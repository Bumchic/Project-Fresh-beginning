using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowStateMachine
{
    public ShadowState CurrentState { get; set; }
    public void initialize(ShadowState startingState)
    {
        CurrentState = startingState;
        CurrentState.enterState();
    }
    public void ChangeState(ShadowState newState)
    {
        CurrentState.exitState();
        CurrentState = newState;
        CurrentState.enterState();
    }
}
