using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IState
{
    public void OnEnter(StateController controller);
    public void UpdateState(StateController controller);
    public void OnExit(StateController controller);
}




public class StateController : MonoBehaviour
{
    IState currentState;

    private void Start()
    {
        //Debug.Log("In current state");
        currentState = new CarryWalkRight();
    }

    void Update()
    {
        currentState.UpdateState(this);
    }

    public void ChangeState(IState newState)
    {
        currentState.OnExit(this);
        currentState = newState;
        currentState.OnEnter(this);
    }
}
