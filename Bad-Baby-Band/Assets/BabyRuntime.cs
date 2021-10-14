using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyRuntime : MonoBehaviour
{
    public float statusLevel;
    int requestLevel;
    int timeToCompleteRequest;
    int TICK_CHANCE = 50; 
    int REQUEST_MAX = 10;
    FMODUnity.StudioEventEmitter emitter;
    public GameObject baby;
    public GameObject babyModel;
    bool requestActive;
    public Sprite[] toySprites;
    public SpriteRenderer spriteRenderer;
    private string[] toyList = {"SM_Rattle","SM_Ball","SM_Blanket","SM_Soother","SM_Cubes"};
    private string toyLabel;
    float requestTimer;
    float Timer;
    int OneSecond = 1;
    void Start()
    {
        requestLevel = 0; // how long until next request
        statusLevel = 0; // angry level of baby
        requestActive = false; // if a request is currently active
        toyLabel = ""; //label of desired toy
        Timer = 0f; // counts time till next req
        requestTimer = 0f; // counts time for active requests
        timeToCompleteRequest = 0;
        emitter = baby.GetComponent<FMODUnity.StudioEventEmitter>();
    }
    void Update()
    {
        UpdateRequestStatus();
         if (Input.GetKeyUp(KeyCode.W))
        {
            GenerateRequest();
        }
       // print(requestLevel);
    }
    void UpdateStatus(){
        statusLevel += 1;
        emitter.SetParameter("Status", statusLevel);
        Debug.Log("Status Level increased. Now at:" + statusLevel);
    }
    void IncreaseRequestLevel(){
        float chance = Random.value * 100;
        Timer += Time.deltaTime;

        if (Timer >= OneSecond){
                if(chance <= TICK_CHANCE && !requestActive ){
                    requestLevel++;
                }
               Timer = 0f; 
            }
    }
    void GenerateRequest(){
        int i = Random.Range(0,toyList.Length);
        toyLabel = toyList[i]; 
        Sprite toySprite = toySprites[i];
        spriteRenderer.sprite = toySprite;
        requestActive = true;
        requestLevel = 0;

    }
    void UpdateRequestStatus(){
            IncreaseRequestLevel();
        if (requestLevel >= REQUEST_MAX){
            GenerateRequest();
        }
        if(requestActive){
            requestTimer += Time.deltaTime;

            if (requestTimer >= OneSecond){
                requestTimer = 0f;
                timeToCompleteRequest++;
            }
            if(timeToCompleteRequest >= 10){
                FailRequest();
            }
        }
    }
    private void OnCollisionEnter(Collision other) {
        //Detect collisions between the GameObjects with Colliders attached
        Debug.Log("Collided with:" + other.gameObject.tag);
        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (other.gameObject.tag == toyLabel)
        {
            //If the GameObject has the same tag as specified, output this message in the console
            CloseRequest();
        }
    }
    void CloseRequest(){
        requestActive = false;
        requestTimer = 0;
        timeToCompleteRequest = 0;
        requestLevel = 0;
        spriteRenderer.sprite = null;
        toyLabel = "";
    }
    void FailRequest(){
       
        CloseRequest();
        UpdateStatus();
    }
}