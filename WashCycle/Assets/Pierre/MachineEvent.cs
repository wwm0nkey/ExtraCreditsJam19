using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MachineEvent: MonoBehaviour
{
    public TMP_Text readyText;

    public GameObject progressbar;
    [SerializeField] bool isBroken;
    public GameManager gm;
    public double fixValue;
    public double instantRepairCost;
    public float stressAmount;
    [SerializeField] float timePerStressTick = 1f;
    private float timer = 0f;

    Collider thisTrigger;
    InputManager inputManager;

    GameObject NPC;
    Animator npcAnimator;
    [SerializeField] float timePerCheck = 30f;
    [SerializeField] int checksToPerform = 4;
    private int checksPerformed;
    private bool npcIsHere = false;

    // Start is called before the first frame update
    void Start()
    {
        //readyText = GameObject.Find("Press E").GetComponent<TMP_Text>();
        //progressbar = GameObject.Find("Action Progress");
        //gm = GameObject.Find("GameManager").GetComponent<GameManager>();


        thisTrigger = GetComponent<BoxCollider>();
        inputManager = GetComponent<InputManager>();
        inputManager.enabled = false;
        thisTrigger.enabled = false;
        isBroken = false;
    }

    // Update is called once per frame
    void Update()
    {
        IncreaseStress();
        if (npcIsHere)
        {
            DoingLaundry();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (isBroken == true)
            {
                string text = "Hold@E@To Fix";
                readyText.text = text.Replace("@", System.Environment.NewLine);
                inputManager.enabled = true;
                progressbar.SetActive(true);
            }
        }

        if(other.tag == "NPC")
        {
            Debug.Log("NPC IS HERE");
            NPC = other.gameObject;
            npcAnimator = NPC.GetComponent<Animator>();

            npcIsHere = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            readyText.text = "";
            inputManager.enabled = false;
            progressbar.SetActive(false);
        }
    }
    
    public void interactMachine()
    {
        if (isBroken) { 
            isBroken = false;
            gm.UpdateMoney(fixValue);
            CheckIfFixed();
        }
    }

    private void CheckIfFixed() { 
    if (!isBroken) {
            readyText.text = "";
            progressbar.SetActive(false);
            thisTrigger.enabled = false;
            inputManager.enabled = false;
        }
    }

    public void Break()
    {
        //********* THIS IS NOT SETTING BROKEN TO TRUE
        isBroken = true;
        thisTrigger = GetComponent<BoxCollider>();
        thisTrigger.enabled = true;
        Debug.Log("This Machine Broke! :C");
    }

    private void DoingLaundry()
    {
        timer += Time.deltaTime;

        if (timer > timePerCheck)
        {
            //MAKE CHECK AND IF CHECK IS SUCCESSFUL THEN RUN THIS FUNCTION
            Break();
            //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
            checksPerformed++;
            timer = timer - timePerCheck;

        }

        if (checksPerformed == checksToPerform)
        {
            npcAnimator.SetBool("laundryDone", true);
        }
    }

   // private void checkMoney()
   // {
   //     Debug.Log("check money");
   //     if (gm.moneyAmount < instantRepairCost)
   //     {
   //         string text = "Not Enough Money";
   //         readyText.text = text.Replace("@", System.Environment.NewLine);
   //     }
   // }

    private void IncreaseStress()
    {
        if (isBroken)
        {
            //TurnOnSmokeAndMakeMachineRedFunction();
            timer += Time.deltaTime;

            if (timer > timePerStressTick)
            {
                timer = timer - timePerStressTick;
                gm.UpdateStress(stressAmount);
            }

        }
    }

}
