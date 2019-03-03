using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class InputManager : MonoBehaviour
{
    [Serializable]
    public class FloatEvent : UnityEvent<float> { }

    public float timeToComplete = 2;
    [SerializeField] UnityEvent onInput;
    [SerializeField] UnityEvent onInputCancel;
    [SerializeField] AnimationCurve timerUpdateCurve;
    [SerializeField] FloatEvent onInputTimerUpdate;
    [SerializeField] UnityEvent onInputTimerEnd;

    float timer;
    private bool isEnded = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            timer = 0;
            onInput.Invoke();
        }else if (Input.GetKeyUp(KeyCode.E))
        {
            onInputCancel.Invoke();
            isEnded = false;
        }
        else if (Input.GetKey(KeyCode.E) && isEnded == false)
        {
            timer += Time.deltaTime;
            onInputTimerUpdate.Invoke(timerUpdateCurve.Evaluate(Mathf.InverseLerp(0, timeToComplete, timer)));
            if (timer > timeToComplete)
            {
                isEnded = true;
                onInputTimerEnd.Invoke();
                
            }
        }

    }
}
