using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartEventScript : MonoBehaviour
{
    public TMP_Text readyText;

    public GameObject progressbar;
    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        readyText.text = "E";
        progressbar.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        readyText.text = "";
        progressbar.SetActive(false);
    }
    
    
}
