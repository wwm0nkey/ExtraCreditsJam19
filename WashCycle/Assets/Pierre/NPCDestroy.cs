﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDestroy : MonoBehaviour
{
    public GameObject spawn;
    public Randomizer gm;
    GameObject NPC;
    private int usedNumber;
    AssignmentHandler assignmentScript;
    private Animator npcAnimator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "NPC")
        {
            NPC = other.gameObject;
            NPC.transform.position = new Vector3(spawn.transform.position.x, spawn.transform.position.y, spawn.transform.position.z);
            npcAnimator = NPC.GetComponent<Animator>();
            npcAnimator.SetBool("isActive", false);
            gm.AddNPC(NPC);
        }
    }
}
