using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : StateMachineBehaviour
{
    GameObject NPC;
    public GameObject[] goal;
    UnityEngine.AI.NavMeshAgent agent;
    private int assignedNumber;
    private Animator thisAnimator;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        NPC = animator.gameObject;
        agent = NPC.GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.SetDestination(goal[0].transform.position); //0 will be assignedNumber
        thisAnimator = NPC.GetComponent<Animator>();


    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //CHECK IF WE'RE AT GOAL POSITION THEN TRANSITION STATE 
        if (Vector3.Distance(goal[0].transform.position, NPC.transform.position) < 3.0f)
        {
            //Change State
            thisAnimator.SetBool("atDestination", true); 
        }
    }
    

    public void setAssignedNumber(int assignment)
    {
        assignedNumber = assignment;
    }
}
