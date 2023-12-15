using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryWalkRight : IState
{
    
    public void OnEnter(StateController controller)
    {
        Debug.Log("Enter CarryWalkRight State");
        controller.gameObject.GetComponent<Animator>().SetBool("CarryWalkRight", true);
    }

    // Update is called once per frame
    public void UpdateState(StateController controller)
    {
        // test conditions for transition
        if(controller.gameObject.GetComponent<StarterAssets.StarterAssetsInputs>().sprint)
        {
            controller.ChangeState(new IdleState());
        }


    }

    public void OnExit(StateController controller)
    {
        Debug.Log("Exit CarryWalkRight State");
        controller.gameObject.GetComponent<Animator>().SetBool("CarryWalkRight", false);

    }
}

