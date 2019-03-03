using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoingLaundry : StateMachineBehaviour
{
    GameObject NPC;
    [SerializeField] float timePerCheck = 30f;
    [SerializeField] int checksToPerform = 4;
    private float timer = 0f;
    private int checksPerformed;
    private Animator thisAnimator;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        NPC = animator.gameObject;
        thisAnimator = NPC.GetComponent<Animator>();
        Debug.Log("I'm doing laundry");    
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //wait certain amount of time
        timer += Time.deltaTime;

        if (timer > timePerCheck)
        {
            Debug.Log("Preform Break Check"); //TODO do break checks
            checksPerformed++;
            timer = timer - timePerCheck;
            
        }
        
        if(checksPerformed == checksToPerform)
        {
            thisAnimator.SetBool("laundryDone", true);
        }

    }
    
}
