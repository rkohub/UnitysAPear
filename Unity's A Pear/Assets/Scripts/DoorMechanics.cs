using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMechanics : MonoBehaviour
{
    public bool isLocked;
    public Animator doorUnlocked;
    public KeyMechanics keyScript;
    public ButtonMechanics buttonScript;
    // public GameObject key;

    void Start()
    {
        // keyScript = key.GetComponent<key>();
        if(isLocked)
        {
            GetComponent<BoxCollider2D> ().enabled = true;
        }else{
            GetComponent<BoxCollider2D> ().enabled = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Man")
        {
            if(keyScript.hasKey || buttonScript.isPressed)
            {
                GetComponent<BoxCollider2D> ().enabled = false;
                isLocked = false;
                doorUnlocked.SetTrigger("DoorUnlocked");
                Debug.Log("unlocked");
            }
        }
    }
}
