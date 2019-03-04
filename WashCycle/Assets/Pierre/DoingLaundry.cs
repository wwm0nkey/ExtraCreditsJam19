using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoingLaundry : StateMachineBehaviour
{
    GameObject NPC;
    [SerializeField] float timePerCheck = 30f;
    [SerializeField] int checksToPerform = 4;
    private GameObject[] machines;
    private float timer = 0f;
    private int checksPerformed;
    private Animator thisAnimator;
    private int myNumber;
    AssignmentHandler assignmentScript;
    MachineEvent machineScript;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        machines = GameObject.FindGameObjectsWithTag("Machine");
        NPC = animator.gameObject;
        thisAnimator = NPC.GetComponent<Animator>();
        assignmentScript = NPC.GetComponent<AssignmentHandler>();
        myNumber = assignmentScript.GetAssignedNumber();

        machineScript = machines[myNumber].GetComponent<MachineEvent>();


        Debug.Log("I'm doing laundry");    
    }
    
}
