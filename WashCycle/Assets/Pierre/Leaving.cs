using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaving : StateMachineBehaviour
{
    GameObject NPC;
    public GameObject goal;
    UnityEngine.AI.NavMeshAgent agent;
    private Animator thisAnimator;
    private int myNumber;
    AssignmentHandler assignmentScript;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        NPC = animator.gameObject;
        agent = NPC.GetComponent<UnityEngine.AI.NavMeshAgent>();
        thisAnimator = NPC.GetComponent<Animator>();
        assignmentScript = NPC.GetComponent<AssignmentHandler>();
        myNumber = assignmentScript.GetAssignedNumber();

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(goal.transform.position); //0 will be assignedNumber
    }
}
