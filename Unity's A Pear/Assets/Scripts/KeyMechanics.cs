using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

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
            GameObject.Find("KeyLight2D").GetComponent<Light2D>().enabled = false;
            Debug.Log("hasKey");
        }
    }
}
