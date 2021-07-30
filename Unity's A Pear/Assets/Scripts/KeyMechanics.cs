using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyMechanics : MonoBehaviour
{
    public bool hasKey;

    void Start()
    {
        hasKey = false;
        GetComponent<Renderer> ().enabled = true;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Man")
        {
            hasKey = true;
            GetComponent<Renderer> ().enabled = false;
            Debug.Log("hasKey");
        }
    }
}
