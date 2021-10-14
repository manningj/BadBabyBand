using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baby4Runtime : MonoBehaviour
{
    float value = 0;
    FMODUnity.StudioEventEmitter emitter;
    void OnEnable()
    {
        var target = GameObject.Find("Baby4");
        emitter = target.GetComponent<FMODUnity.StudioEventEmitter>();
    }
    void Update()
    {
        emitter.SetParameter("Status", value);
        if (Input.GetKeyUp(KeyCode.R))
        {
            value += 1;
            Debug.Log(value);
        }
    }
}