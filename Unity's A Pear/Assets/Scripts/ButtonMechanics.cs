using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMechanics : MonoBehaviour
{
    public bool isPressed;
    public Animator buttonPress;

    void Start()
    {
        isPressed = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Man")
        {
            isPressed = true;
            buttonPress.SetTrigger("ButtonPressed");
            Debug.Log("ButtonPressed");
        }
    }
}