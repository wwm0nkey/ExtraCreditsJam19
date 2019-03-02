using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TMP_Text moneyText;
    public double moneyAmount;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateMoney(double moneyAmt)
    {
        moneyAmount += moneyAmt;
        moneyText.text = moneyAmount.ToString();
    }
}
