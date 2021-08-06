using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketDie : MonoBehaviour
{
    public GameObject basket;

    public void KillBasket()
    {
        Debug.Log("time is short");
        Destroy(basket);
        Debug.Log("stolen");
    }
}
