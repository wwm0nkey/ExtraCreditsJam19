using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SomethingSuperDumb : MonoBehaviour
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

    // Start is called before the first frame update
    void Start()
    {
        thisTrigger = GetComponent<BoxCollider>();
        thisTrigger.enabled = false;
        isBroken = false;
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
            if (isBroken == true)
            {
                string text = "Hold@E@To Fix";
                readyText.text = text.Replace("@", System.Environment.NewLine);
                progressbar.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            readyText.text = "";
            progressbar.SetActive(false);
        }
    }

    public void interactMachine()
    {
        if (isBroken)
        {
            isBroken = false;
            gm.UpdateMoney(fixValue);
            CheckIfFixed();
        }
    }

    private void CheckIfFixed()
    {
        if (!isBroken)
        {
            readyText.text = "";
            progressbar.SetActive(false);
            thisTrigger.enabled = false;
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
