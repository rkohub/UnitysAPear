using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegsControl : MonoBehaviour{

    public GameObject head;
    public HeadControl headScript;
    public MoveCharacter myMovement;
    public Interactable myInteract;
    public Collider2D legBox;
    public Collider2D attachedBox;
    public bool attached;
    public bool controllingLegs;
    public bool selfEnabled;
    public bool readyToChange;
    public bool readyToAttachFromLegs;
    public float distToAttach;

    public float attJumpMagnitude;
    public float attAccelerationMagnitude;
    public float attMaxVelocity;
    public int attMaxJumps;
    private bool inControl ;
    // Start is called before the first frame update

    void Start(){
        attached = true;
        selfEnabled = true;
        readyToChange = false;
        readyToAttachFromLegs = false;
    }

    // Update is called once per frame
    void Update(){

        legBox.enabled = !attached;
        attachedBox.enabled = attached;
        // if(attached){
        //     // Debug.Log("ATT");
        //     myMovement.jumpMagnitude         = attJumpMagnitude;
        //     myMovement.accelerationMagnitude = attAccelerationMagnitude;
        //     myMovement.maxVelocity           = attMaxVelocity;
        //     myMovement.maxJumps              = attMaxJumps;
        // }else{
        //     // Debug.Log("SEP");
        //     myMovement.jumpMagnitude         = myMovement.baseJumpMagnitude;
        //     myMovement.accelerationMagnitude = myMovement.baseAccel;
        //     myMovement.maxVelocity           = myMovement.baseMaxVelocity;
        //     myMovement.maxJumps              = myMovement.baseMaxJumps;
        // }

        inControl  = selfEnabled || attached;
        myMovement.enabled = inControl;
        if(!inControl){
            myInteract.interactHitbox.enabled = false;
        }
        myInteract.enabled = inControl;

        if(selfEnabled || attached){
            // Debug.Log("L ENAB");
            if(readyToChange){
                updateControl();
            }
            if(readyToAttachFromLegs){
                updateAttach();
            }
            if (Input.GetKeyDown("j")){
                if(Vector2.Distance(this.gameObject.transform.position,head.transform.position) < distToAttach){
                    readyToAttachFromLegs = true;
                }else{
                    Debug.Log("NotINRange");
                }
            }
            if (Input.GetKeyDown("k")){
                readyToChange = true;
            }
        }
    }

    public void updateAttach(){
        attached = !attached;
        headScript.attached = attached; 
        // Debug.Log("@@@");
        readyToAttachFromLegs = false;
        headScript.readyToAttachFromHead = false;
    }

    public void updateControl(){
        //Enable Legs Disable Self
        headScript.selfEnabled = true;  
        // Debug.Log("L K"); 
        selfEnabled = false;   
        readyToChange = false;
    }
}
