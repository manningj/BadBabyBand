using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baby2Runtime : MonoBehaviour
{
    float value = 0;
    FMODUnity.StudioEventEmitter emitter;
    void OnEnable()
    {
        var target = GameObject.Find("Baby2");
        emitter = target.GetComponent<FMODUnity.StudioEventEmitter>();
    }
    void Update()
    {
        emitter.SetParameter("Status", value);
        if (Input.GetKeyUp(KeyCode.W))
        {
            value += 1;
            Debug.Log(value);
        }
    }
}