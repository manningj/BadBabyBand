 using UnityEngine;
 using UnityEngine.UI;
 using System.Collections;
 using System.Collections.Generic;
 
 // rename this class to suit your needs
 public class InstantiateItem : MonoBehaviour
 {
    public GameObject newGameObject;
    public GameObject spawnParent;
     // list that holds all created objects - delete all instances if desired
    public List<GameObject> createdObjects = new List<GameObject>();
    public Vector3 pos;
    private float minX, maxX, minY, maxY;
 
     void Start()
     {
         // get the screen bounds
         float camDistance = Vector3.Distance(transform.position, Camera.main.transform.position);
         Vector2 bottomCorner = Camera.main.ViewportToWorldPoint(new Vector3(0,0, camDistance));
         Vector2 topCorner = Camera.main.ViewportToWorldPoint(new Vector3(1,1, camDistance));
 
         minX = bottomCorner.x;
         maxX = topCorner.x;
         minY = bottomCorner.y;
         maxY = topCorner.y;
     }
 
     public void CreateObject()
     {
         // a prefab is need to perform the instantiation
         if (newGameObject != null && spawnParent != null)
         {
           
             pos = new Vector3(spawnParent.transform.position.x, spawnParent.transform.position.y, spawnParent.transform.position.z);
             // get a random postion to instantiate the prefab - you can change this to be created at a fied point if desired
             Vector3 position = new Vector3(pos.x, pos.y, pos.z);
             // instantiate the object
             GameObject gameObject = (GameObject)Instantiate(newGameObject, position, Quaternion.identity);
             gameObject.AddComponent<Rigidbody>();
             gameObject.GetComponent<Rigidbody>().useGravity = false;
             gameObject.GetComponent<Rigidbody>().isKinematic = false;
             gameObject.GetComponent<Rigidbody>().detectCollisions = true;

             gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
             gameObject.AddComponent<FollowHand>();
             gameObject.tag = newGameObject.gameObject.name;
             gameObject.AddComponent<BoxCollider>();
             createdObjects.Add(gameObject);
         }
     }    
 }