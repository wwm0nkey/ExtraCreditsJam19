using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartEventScriptPierre : MonoBehaviour
{
    public TMP_Text readyText;

    public GameObject progressbar;
    public bool isBroken = true;
    public GameManager gm;
    public double fixValue;
    public double arcadeCost;
    public float stressAmount;
    public float stressReliefAmount;
    [SerializeField] float timePerStressTick = 1f;
    private float timer = 0f;

    Collider thisTrigger;
    // Start is called before the first frame update
    void Start()
    {
        thisTrigger = GetComponent<BoxCollider>();
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
            readyText.text = "";
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
        else if (!isBroken)
        {
            if (gm.moneyAmount >= arcadeCost) { 
            gm.UpdateMoney(-arcadeCost);
            //TODO decrease stress by stressReliefAmount
            Debug.Log("reduced stress by " + stressReliefAmount);
            CheckIfFixed();
            }
        }
    }

    private void CheckIfFixed() { 
    if (!isBroken) {
            readyText.text = "";
            progressbar.SetActive(false);
        }
    }

    private void IncreaseStress()
    {
        if (isBroken)
        {
            timer += Time.deltaTime;

            if (timer > timePerStressTick)
            {
                //TODO increase stress amount by stressAmount
                Debug.Log("Stress just increased by " + stressAmount);
                timer = timer - timePerStressTick;
            }

        }
    }

}
