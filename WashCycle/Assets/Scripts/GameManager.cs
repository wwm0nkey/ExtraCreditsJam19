using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TMP_Text moneyText;
    public TMP_Text stressText;
    public double moneyAmount;
    public float stressAmount;
    
    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    public void UpdateMoney(double moneyAmt)
    {
        moneyAmount += moneyAmt;
        moneyText.text = moneyAmount.ToString();
    }

    public void UpdateStress(float stressAmt)
    {
        stressAmount += stressAmt;
        stressText.text = stressAmount.ToString();
    }
    public void ReduceStress(float stressAmt)
    {
        stressAmount -= stressAmt;
        if (stressAmount <= 0)
        {
            stressAmount = 0;
        }
        stressText.text = stressAmount.ToString();
    }
}
