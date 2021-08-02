using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    private int legsPos;
    private int headPos;
    private Vector2 spawn = new Vector2(-3.621089f, -2.942531f);
    private Vector2 deadPos;
    private Vector2 movedDistance;

    void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.gameObject.tag == "Man")
            {
                deadPos = GameObject.Find("Legs").transform.position;
                movedDistance = spawn - deadPos;
                GameObject.Find("Head").transform.Translate(-movedDistance);
                GameObject.Find("Legs").transform.position = new Vector2(-3.621089f, -2.942531f);
                Debug.Log("ButtonPressed");
            }
        }
}
