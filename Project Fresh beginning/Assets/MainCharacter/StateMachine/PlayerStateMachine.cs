using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine
{
    public PlayerState CurrentState { get; private set; }//
    private Player player;//

    public PlayerStateMachine(Player player)//
    {
        this.player = player;
        CurrentState = player.idleState;
    }
    public void intizialize(PlayerState startingState)
    {
        CurrentState = startingState;
        CurrentState.EnterState();   
    }

    public void ChangeState(PlayerState newState)
    {
        CurrentState.ExitState();
        CurrentState = newState;
        CurrentState.EnterState();
    }
}
