using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMechanics : MonoBehaviour
{
    public bool staysPressed;
    public bool isPressed;
    public Animator buttonPress;
    public Animator buttonEffect;
    //public Animator grateOpen;

    private bool ryanPressed;

    void Start()
    {
        isPressed = false;
        // ryanPressed = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("crash");   
        ButtonDown();
        //grateOpen.SetTrigger("ButtonPressed");
        //ryanPressed = true;
        //Debug.Log("ButtonPressed");
        //Debug.Log(ryanPressed);
        
        // Wait();

        // if(!staysPressed)
        // {
        //     OnCollisionExit2D();
        // }
    }

    public void ButtonDown()
    {
        Debug.Log("method run");
        isPressed = true;
        buttonPress.SetTrigger("ButtonPressed");
        buttonEffect.SetTrigger("ButtonEffect");
        Debug.Log("animation played");
    }

    // void Update(){
    //     if(this.gameObject.name == "Button"){
    //         print(ryanPressed);
    //     }
    // }

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

    // void OnCollisionExit2D(Collision2D collision){
    //     // Debug.Log(collision.gameObject.tag);
    //     if(collision.gameObject.tag == "Man"){
    //         Debug.Log("not being pressed anymore");
    //         ryanPressed = false;
    //     }
    // }

    // void OnCollisionStay2D(Collision2D collision){
    //     if(collision.gameObject.tag == "Man"){
    //         Debug.Log("holding");
    //         ryanPressed = true;
    //     }
    // }
}