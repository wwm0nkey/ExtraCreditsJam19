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

    Collider thisTrigger;
    // Start is called before the first frame update
    void Start()
    {
        thisTrigger = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        //We can probably move this to a function after it's fixed so we don't call it every frame
        CheckIfFixed();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            string text = "Hold@E";
            readyText.text = text.Replace("@", System.Environment.NewLine);
            progressbar.SetActive(true);
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
    
    public void FixMachine()
    {
        isBroken = false;
        gm.UpdateMoney(fixValue);
    }

    private void CheckIfFixed() { 
    if (!isBroken) {
            thisTrigger.enabled = false;
            readyText.text = "";
            progressbar.SetActive(false);
        }
    }

}
