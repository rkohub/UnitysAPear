using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMechanics : MonoBehaviour
{
    public bool isLocked;
    public Animator keyUsed;
    public KeyMechanics keyScript;
    // public GameObject key;

    // Start is called before the first frame update
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
        if(collision.gameObject.tag == "Man" && keyScript.hasKey)
        {
            GetComponent<BoxCollider2D> ().enabled = false;
            isLocked = false;
            keyUsed.SetTrigger("KeyUsed");
            Debug.Log("unlocked");
        }
    }
}
