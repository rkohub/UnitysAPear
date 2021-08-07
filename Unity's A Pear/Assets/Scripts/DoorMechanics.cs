using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMechanics : MonoBehaviour
{
    public bool isLocked;
    public bool doesKeyExist;
    public Animator doorUnlocked;
    public KeyMechanics keyScript;
    public LevelLoader levelLoader;
    // public ButtonMechanics buttonScript;
    // public GameObject key;
    public HeadControl headControl;

    void Start()
    {
        if(isLocked)
        {
            doesKeyExist = true;
        }else{
            doesKeyExist = false;
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Man" || collision.gameObject.tag == "Player")
        {
            if(headControl.attached)
            {
                if(!doesKeyExist || keyScript.hasKey)
                {
                    GetComponent<BoxCollider2D> ().enabled = false;
                    isLocked = false;
                    doorUnlocked.SetTrigger("DoorUnlocked");
                    Debug.Log("unlocked");
                    levelLoader.Switch();
                }
            }
        }
    }
}
