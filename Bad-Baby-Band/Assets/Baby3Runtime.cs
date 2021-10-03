using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baby3Runtime : MonoBehaviour
{
    float value = 0;
    FMODUnity.StudioEventEmitter emitter;
    void OnEnable()
    {
        var target = GameObject.Find("Baby3");
        emitter = target.GetComponent<FMODUnity.StudioEventEmitter>();
    }
    void Update()
    {
        emitter.SetParameter("Status", value);
        if (Input.GetKeyUp(KeyCode.E))
        {
            value += 1;
            Debug.Log(value);
        }
    }
}