using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowHand : MonoBehaviour
{
    private Rigidbody rb;
    private GameObject parent;
    private bool held;

    private Vector3 dragOrigin;
    private Vector3 dragRelease;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        parent = GameObject.Find("PlayerHand");
        held = true;
        rb.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(transform.position);

        if(held){
            transform.position = new Vector3(
                parent.transform.position.x, parent.transform.position.y, parent.transform.position.z);
            if(Input.GetMouseButtonDown(0)){
               dragOrigin = parent.transform.position;

            }else if(Input.GetMouseButtonUp(0)){
                dragRelease = parent.transform.position;
                held = false;
                Throw();
            }
        }
    }
    void Throw(){   
        float thrust = 0.05f;
        Vector3 throwVector = dragRelease - dragOrigin;
        throwVector.z = throwVector.y;

        float speed = throwVector.magnitude / Time.deltaTime;
        //Debug.Log("speed: " + speed);
        Vector3 throwVelocity = speed * throwVector.normalized;
        

        rb.useGravity = true;
        rb.velocity = throwVelocity;
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX02 - Yeet");
        Debug.Log("Thrown");
    }

}
