using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHandler : MonoBehaviour
{
    GameObject NPC;
    private int usedNumber;
    AssignmentHandler assignmentScript;
    private Animator npcAnimator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "NPC")
        {
            NPC = other.gameObject;
            npcAnimator = NPC.GetComponent<Animator>();
            npcAnimator.SetBool("isActive", true);

        }
    }
}
