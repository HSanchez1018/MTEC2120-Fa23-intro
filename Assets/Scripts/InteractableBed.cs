using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InteractableBed : Interactable
{
public float interactionTime = 2.0f;
private bool isSleeping = false;
private RuntimeAnimatorController originalAnimController;
public RuntimeAnimatorController interactableAnimController;
private Animator animator;
public GameObject Marker;
private CharacterController characterController;
private ThirdPersonController thirdPersonController;
public UnityEvent onInteract;
    public InputActionReference inputAction;
public override void Start()
{
base.Start();
// Initialize Bed rotation angles​
}
protected override void Interaction(GameObject player)
{
base.Interaction(player);
Debug.Log("InteractableBed : Interaction was called. ");
// Move Player to Marker       // Move the player to the Marker GameObject
// Get the Animator component attached to this GameObject
animator = player.GetComponent<Animator>();
originalAnimController = player.GetComponent<Animator>().runtimeAnimatorController;
characterController = player.GetComponent<CharacterController>();
thirdPersonController = player.GetComponent<ThirdPersonController>();
player.transform.position = Marker.transform.position;
player.transform.rotation = Marker.transform.rotation;
characterController.enabled = false;
thirdPersonController.enabled = true;
// Swap Animations
StartCoroutine(SwapAnimation());
}
private void SleepExit(InputAction.CallbackContext context)
{
Debug.Log("SitExit.");
if (animator != null)
{
isSleeping = false;
animator.SetBool("IsSleeping", isSleeping);
StartCoroutine(OnSleepExit());
Debug.Log("OnSleepExit.");
}
}
private IEnumerator OnSleepExit()
{
yield return new WaitForSeconds(4);
if (originalAnimController != null)
{
animator.applyRootMotion = false;
animator.runtimeAnimatorController = originalAnimController;
}
OnAnimationComplete();
inputAction.action.started -= SleepExit;
        
yield return null;
}
private IEnumerator SwapAnimation()
{
// Ensure we have an Animator component
if (animator == null)
{
Debug.LogError("Animator component not found!");
}
else
{
// Assign the initial RuntimeAnimatorController
if (interactableAnimController != null)
{
if (!isSleeping)
{
animator.applyRootMotion = true;
animator.runtimeAnimatorController = interactableAnimController;
}
}
isSleeping = true;
animator.SetBool("IsSleeping", isSleeping);
yield return new WaitForSeconds(interactionTime);
inputAction.action.started += SleepExit;

}
yield return null;
}
public void OnAnimationComplete()
{
// This method is called from an Animation Event when the default animation clip finishes playing​
// Swap to the other controller and play its default animation
characterController.enabled = true;
thirdPersonController.enabled = true;
}
}
