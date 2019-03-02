using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartEventScriptPierre : MonoBehaviour
{
    public TMP_Text readyText;

    public GameObject progressbar;
    public bool isBroken = true;

    Collider thisTrigger;
    // Start is called before the first frame update
    void Start()
    {
        thisTrigger = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
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
    }

    private void CheckIfFixed() { 
    if (!isBroken) {
            thisTrigger.enabled = false;
            readyText.text = "";
            progressbar.SetActive(false);
        }
    }

}
