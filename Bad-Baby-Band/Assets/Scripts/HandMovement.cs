using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMovement : MonoBehaviour
{
    // Start is called before the first frame update

    Vector3 mousePosition;
    public float offset= 0.017f;
    // Update is called once per frame
    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,
         Camera.main.nearClipPlane + offset));
        transform.position = new Vector3(mousePosition.x, mousePosition.y, mousePosition.z);
    } 
}
