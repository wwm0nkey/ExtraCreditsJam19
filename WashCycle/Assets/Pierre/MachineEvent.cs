using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MachineEvent: MonoBehaviour
{
    public TMP_Text readyText;

    public GameObject smoke;
    public GameObject progressbar;
    [SerializeField] bool isBroken;
    public GameManager gm;
    public double fixValue;
    public double instantRepairCost;
    public float stressAmount;
    [SerializeField] float timePerStressTick = 1f;
    [SerializeField] float timer = 0f;
    [SerializeField] float npcTimer = 0f;
    Collider thisTrigger;
    InputManager inputManager;

    GameObject NPC;
    Animator npcAnimator;
    [SerializeField] float timePerCheck = 30f;
    [SerializeField] int checksToPerform = 4;
    [SerializeField] int checksPerformed;
    [SerializeField] bool npcIsHere = false;

    // Start is called before the first frame update
    void Start()
    {
        //readyText = GameObject.Find("Press E").GetComponent<TMP_Text>();
        //progressbar = GameObject.Find("Action Progress");
        //gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        thisTrigger = GetComponent<BoxCollider>();
        inputManager = GetComponent<InputManager>();
        inputManager.enabled = false;
        isBroken = false;
    }

    // Update is called once per frame
    void Update()
    {
        IncreaseStress();
        if (npcIsHere)
        {
            npcTimer += Time.deltaTime;
            if (npcTimer > timePerCheck)
            {
                //MAKE CHECK AND IF CHECK IS SUCCESSFUL THEN RUN THIS FUNCTION
                Break();
                //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
                checksPerformed++;
                npcTimer = npcTimer - timePerCheck;

            }
            if (checksPerformed == checksToPerform)
            {
                npcAnimator.SetBool("laundryDone", true);
            }
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

        if (other.tag == "NPC")
        {
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
        if (other.tag == "NPC")
        {
            npcIsHere = false;
            npcTimer = 0;
            checksPerformed = 0;
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
            smoke.SetActive(false);
        }
    }

    public void Break()
    {
        var randomNum = 0;
        var checks = 0;
        for (int i = 0; i < 4; i++)
        {
            randomNum = Random.Range(1, 4);
            if (randomNum == 2 || randomNum == 4)
            {
                checks++;
            }
        }

        if (checks >= 2)
        {
            isBroken = true;
            smoke.SetActive(true);
            Debug.Log("This Machine Broke! :C");
        }
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
            timer = 0;

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
