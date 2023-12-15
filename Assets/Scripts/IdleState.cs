using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState
{ 
    public void OnEnter(StateController controller)
    {
        Debug.Log("Enter Idle State");
    }

    public void UpdateState(StateController controller)
    {
        Debug.Log("Idle State Update");
    }

    public void OnExit(StateController controller)
    {
        Debug.Log("Exit Idle State");
    }
}
