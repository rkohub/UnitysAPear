using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadControl : MonoBehaviour{

    //error when head  tries to reattach. changes values in legs. Then works after 2.

    public GameObject legs;
    public LegsControl legScript;
    public MoveCharacter myMovement;
    public Interactable myInteract;
    public bool attached;
    public bool controllingLegs;
    public bool selfEnabled;
    public bool readyToChange;
    public bool readyToAttachFromHead;
    private Rigidbody2D body;
    public Collider2D coll;
    public float distToAttach;
    private bool inControl;
    // Start is called before the first frame update

    void Start(){
        attached = true;
        selfEnabled = false;
        readyToChange = false;
        readyToAttachFromHead = false;
        body = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update(){
        inControl = !attached && selfEnabled;
        myMovement.enabled = inControl;
        if(!inControl){
            myInteract.interactHitbox.enabled = false;
        }
        myInteract.enabled = inControl;
        coll.enabled = !attached;
        if(attached){
            body.velocity = new Vector2 (0,0);
            this.gameObject.transform.localPosition = new Vector2(0,1.5f);
        }
        if(selfEnabled){
            // Debug.Log("H ENAB");
            if(readyToChange){
                updateControl();
            }
            if(readyToAttachFromHead){
                updateAttach();
            }
            if (Input.GetKeyDown("j")){
                if(Vector2.Distance(this.gameObject.transform.position,legs.transform.position) < distToAttach){
                    readyToAttachFromHead = true;
                }else{
                    Debug.Log("NotINRangeH");
                }
                // Debug.Log("LINK");
            }
            if (Input.GetKeyDown("k")){
                readyToChange = true;
            }
        }
    }

    public void updateAttach(){
        attached = !attached;
        legScript.attached = attached; 
        // Debug.Log("H ATT");
        // Debug.Log(attached);
        // selfEnabled = false;
        readyToAttachFromHead = false;
        legScript.readyToAttachFromLegs = false;
    }

    public void updateControl(){
        //Enable Legs Disable Self
        legScript.selfEnabled = true;
        // Debug.Log("H K");
        selfEnabled = false;  
        readyToChange = false; 
    }
}
