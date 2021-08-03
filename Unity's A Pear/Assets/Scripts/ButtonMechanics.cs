using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMechanics : MonoBehaviour
{
    public bool staysPressed;
    public bool isPressed;
    public Animator buttonPress;
    public Animator buttonEffect;

    void Start()
    {
        isPressed = false;
        // staysPressed = true;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
            isPressed = true;
            buttonPress.SetTrigger("ButtonPressed");
            buttonEffect.SetTrigger("ButtonEffect");
            Debug.Log("ButtonPressed");
            // Wait();

        // if(!staysPressed)
        // {
        //     OnCollisionExit2D();
        // }
    }

    // IEnumerator DoAnimation()
    // {
    //     Debug.Log("waiting");
    //     buttonPress.SetTrigger("ButtonPressed");
    //     buttonEffect.SetTrigger("ButtonEffect");
    //     yield return new WaitForSeconds(3f);
    // }
        // IEnumerator Wait(){
        //     yield return new WaitForSeconds(3);
        // }

    // void OnCollisionExit2D(Collision2D collision)
    // {
    //     if(collision.gameObject.tag != "Man")
    //     {
    //         buttonPress.SetTrigger("ButtonRelease");
    //         isPressed = false;
    //     }
    //     Debug.Log("not being pressed");
    // } 
}