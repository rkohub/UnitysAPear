using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManCollider : MonoBehaviour
{
    public LevelLoader loader;

        void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "man")
        {
            Debug.Log("collision");
            loader.Switch();
            Debug.Log("switched");
        }
    }
}
