using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine
{
    public PlayerState CurrentPlayerState { get; set; }

    public void intizialize(PlayerState startingState)
    {
        CurrentPlayerState = startingState;
        CurrentPlayerState.EnterState();   
    }

    public void ChangeState(PlayerState newState)
    {
        CurrentPlayerState.ExitState();
        CurrentPlayerState = newState;
        CurrentPlayerState.EnterState();
    }
}
