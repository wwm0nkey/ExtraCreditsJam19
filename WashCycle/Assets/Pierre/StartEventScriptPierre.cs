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
    [SerializeField] private float timePerStressTick = 1f;
    private float _timer = 0f;

    private Collider _thisTrigger;
    // Start is called before the first frame update
    private void Start()
    {
        _thisTrigger = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    private void Update()
    {
        IncreaseStress();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        if (isBroken == true)
        {
            const string text = "Hold@E@To Fix";
            readyText.text = text.Replace("@", System.Environment.NewLine);
            progressbar.SetActive(true);
        }
        if (!isBroken && gm.moneyAmount >= arcadeCost)
        {
            const string text = "Hold@E@To Play";
            readyText.text = text.Replace("@", System.Environment.NewLine);
            progressbar.SetActive(true);
        }

        if (isBroken || !(gm.moneyAmount < arcadeCost)) return;
        {
            const string text = "Too Broke@For Fun";
            readyText.text = text.Replace("@", System.Environment.NewLine);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        readyText.text = "";
        progressbar.SetActive(false);
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
            if (!(gm.moneyAmount >= arcadeCost)) return;
            gm.UpdateMoney(-arcadeCost);
            gm.ReduceStress(stressReliefAmount);
            checkMoney();
        }
    }

    private void CheckIfFixed() { 
    if (!isBroken && gm.moneyAmount >= arcadeCost)
    {
        const string text = "Hold@E@To Play";
        readyText.text = text.Replace("@", System.Environment.NewLine);
    }
    else if (!isBroken && gm.moneyAmount < arcadeCost)
    {
        const string text = "Too Broke@For Fun";
        readyText.text = text.Replace("@", System.Environment.NewLine);
    }
    }

    private void checkMoney()
    {
        //Debug.Log("check money");
        if (!(gm.moneyAmount < arcadeCost)) return;
        const string text = "Too Broke@For Fun";
        readyText.text = text.Replace("@", System.Environment.NewLine);
    }

    private void IncreaseStress()
    {
        if (!isBroken) return;
        //TurnOnSmokeAndMakeMachineRedFunction();
        _timer += Time.deltaTime;

        if (!(_timer > timePerStressTick)) return;
        _timer = _timer - timePerStressTick;
        gm.UpdateStress(stressAmount);
    }

}
