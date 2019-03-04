using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ArcadeEvent: MonoBehaviour
{
    public TMP_Text readyText;

    public GameObject smoke;
    public GameObject progressbar;
    public bool isBroken = true;
    public GameManager gm;
    public double fixValue;
    public double arcadeCost;
    public float stressAmount;
    public float stressReliefAmount;
    [SerializeField] float timePerStressTick = 1f;
    private float timer = 0f;

    InputManager inputManager;

    Collider thisTrigger;
    // Start is called before the first frame update
    void Start()
    {
        thisTrigger = GetComponent<BoxCollider>();

        inputManager = GetComponent<InputManager>();
        inputManager.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        IncreaseStress();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            inputManager.enabled = true;
            if (isBroken == true)
            {
                string text = "Hold@E@To Fix";
                readyText.text = text.Replace("@", System.Environment.NewLine);
                progressbar.SetActive(true);
            }
            if (!isBroken && gm.moneyAmount >= arcadeCost)
            {
                string text = "Hold@E@To Play";
                readyText.text = text.Replace("@", System.Environment.NewLine);
                progressbar.SetActive(true);
            }
            if (!isBroken && gm.moneyAmount < arcadeCost)
            {
                string text = "Too Broke@For Fun";
                readyText.text = text.Replace("@", System.Environment.NewLine);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            inputManager.enabled = false;
            readyText.text = "";
            progressbar.SetActive(false);
        }
    }
    
    public void interactMachine()
    {
        if (isBroken) { 
            isBroken = false;
            gm.UpdateMoney(fixValue);
            smoke.SetActive(false);
            CheckIfFixed();
        }
        else if (!isBroken)
        {
            if (gm.moneyAmount >= arcadeCost) { 
                gm.UpdateMoney(-arcadeCost);
                gm.ReduceStress(stressReliefAmount);
                checkMoney();
            }
        }
    }

    private void CheckIfFixed() { 
    if (!isBroken && gm.moneyAmount >= arcadeCost) {
            string text = "Hold@E@To Play";
            readyText.text = text.Replace("@", System.Environment.NewLine);
        }
    if (!isBroken && gm.moneyAmount < arcadeCost)
        {
            string text = "Too Broke@For Fun";
            readyText.text = text.Replace("@", System.Environment.NewLine);
        }
    }

    private void checkMoney()
    {
        Debug.Log("check money");
        if (gm.moneyAmount < arcadeCost)
        {
            string text = "Too Broke@For Fun";
            readyText.text = text.Replace("@", System.Environment.NewLine);
        }
    }

    private void IncreaseStress()
    {
        if (isBroken)
        {
            smoke.SetActive(true);
            timer += Time.deltaTime;

            if (timer > timePerStressTick)
            {
                timer = timer - timePerStressTick;
                gm.UpdateStress(stressAmount);
            }

        }
    }

}
