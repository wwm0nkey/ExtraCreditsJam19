using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomizer : MonoBehaviour
{
    public List<GameObject> npcList;

    public List<GameObject> inPlay;

    private Animator npcAnimator;

    public int minWaitTime;
    public int maxWaitTime;

    public float nextSpawnTime;
    public float timer;

    public int randomTimer;
    public int randomNumber;
    // Start is called before the first frame update
    void Start()
    {
        SetTimer();
        randomTimer = Random.Range(minWaitTime, maxWaitTime);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > randomTimer)
        {
            RemoveNPC();
            timer = 0;
            randomTimer = Random.Range(minWaitTime, maxWaitTime);
        }
        //if (Input.GetKeyDown(KeyCode.F))
        //{
        //    RemoveNPC();
        //}
    }

    public void RemoveNPC()
    {
        randomNumber = Random.Range(0, npcList.Count);
        inPlay.Add(npcList[randomNumber]);
        
        npcList[randomNumber].SetActive(true);
        npcList.RemoveAt(randomNumber);

    }

    public void AddNPC(GameObject npc)
    {
        npcAnimator = npc.GetComponent<Animator>();
        npcAnimator.SetBool("isActive", false);
        npc.SetActive(false);
        inPlay.Remove(npc);
        npcList.Add(npc);
    }

    private void SetTimer()
    {
        this.nextSpawnTime = Random.Range(this.minWaitTime, this.maxWaitTime);
    }

//    public void CheckTimer()
//    {
//        this.nextSpawnTime -= Time.deltaTime;
//        if(this.nextSpawnTime <= 0)
//        {
//            RemoveNPC();
//            this.SetTimer();
//        }    
//    }
}
