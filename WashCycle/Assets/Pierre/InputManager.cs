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
    [SerializeField] private UnityEvent onInput;
    [SerializeField] private UnityEvent onInputCancel;
    [SerializeField] private AnimationCurve timerUpdateCurve;
    [SerializeField] private FloatEvent onInputTimerUpdate;
    [SerializeField] private UnityEvent onInputTimerEnd;

    private float _timer;
    private bool _isEnded = false;

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            _timer = 0;
            onInput.Invoke();
        }else if (Input.GetKeyUp(KeyCode.E))
        {
            onInputCancel.Invoke();
            _isEnded = false;
        }
        else if (Input.GetKey(KeyCode.E) && _isEnded == false)
        {
            _timer += Time.deltaTime;
            onInputTimerUpdate.Invoke(timerUpdateCurve.Evaluate(Mathf.InverseLerp(0, timeToComplete, _timer)));
            if (!(_timer > timeToComplete)) return;
            _isEnded = true;
            onInputTimerEnd.Invoke();
        }

    }
}
