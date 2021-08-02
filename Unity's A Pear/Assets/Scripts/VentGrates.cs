using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class VentGrates : MonoBehaviour
{
    public GameObject VentLight;

    void Start()
    {
        VentLight.GetComponent<Light2D>().enabled = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.gameObject.tag == "Man")
            {
                VentLight.GetComponent<Light2D>().enabled = true;
            }
        }

    void OnCollisionExit2D(Collision2D collision)
        {
            if(collision.gameObject.tag == "Man")
            {
                VentLight.GetComponent<Light2D>().enabled = false;
            }
        }
}
