using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDestroy : MonoBehaviour
{
    GameObject NPC;
    private int usedNumber;
    AssignmentHandler assignmentScript;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "NPC")
        {
            NPC = other.gameObject;
            assignmentScript = NPC.GetComponent<AssignmentHandler>();
            usedNumber = assignmentScript.GetAssignedNumber();
           

            Debug.Log("Add "+ usedNumber + " back into available list");

            Destroy(other.gameObject);
        }
    }
}
