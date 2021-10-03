using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowHand : MonoBehaviour
{
    private Rigidbody rb;
    private GameObject parent;
    private bool held;
    private bool dragging;

    private Vector3 f;
    private Vector3 roi = new Vector3(0f, 0.1f, 0f);
    private Vector3 dragOrigin;
    private Vector3 dragRelease;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        parent = GameObject.Find("PlayerHand");
        held = true;
        dragging = false;
        f = new Vector3(0,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(transform.position);

        if(held){
            transform.position = new Vector3(
                parent.transform.position.x, parent.transform.position.y, parent.transform.position.z);
            if(Input.GetMouseButtonDown(0)){
               dragOrigin = parent.transform.position;
               dragging = true;
            }else if(Input.GetMouseButtonUp(0)){
                dragRelease = parent.transform.position;
                dragging = false;
                held = false;
                rb.AddForce(0f, 50f, 50f);
                Throw();
            }
        }
        // if(Input.GetMouseButton(0) && dragging){
        // }
    }
    void Throw(){   
     //  velocity = new Vector3(dragRelease.x - dragOrigin.x,dragRelease.y - dragOrigin.y, dragRelease.z- dragOrigin.z );
        rb.AddForce(0f, 10f, 10f, ForceMode.Impulse);

        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX02 - Yeet");
        Debug.Log("Thrown");
    }

}
