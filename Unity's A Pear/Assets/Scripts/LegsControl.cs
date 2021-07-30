using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegsControl : MonoBehaviour{

    public GameObject head;
    public HeadControl headScript;
    public MoveCharacter myMovement;
    public bool attached;
    public bool controllingLegs;
    public bool selfEnabled;
    public bool readyToChange;
    public bool readyToAttachFromLegs;
    public float distToAttach;
    // Start is called before the first frame update

    void Start(){
        attached = true;
        selfEnabled = true;
        readyToChange = false;
        readyToAttachFromLegs = false;
    }

    // Update is called once per frame
    void Update(){
        myMovement.enabled = selfEnabled || attached;
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
