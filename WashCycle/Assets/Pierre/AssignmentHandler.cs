using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignmentHandler : MonoBehaviour
{
    [SerializeField] int assignedNumber;



    public void SetAssignedNumber(int assignment)
    {
        assignedNumber = assignment;
    }

    public int GetAssignedNumber()
    {
        return assignedNumber;
    }
}
