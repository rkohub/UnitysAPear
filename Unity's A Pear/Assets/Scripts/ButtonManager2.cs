using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager2 : MonoBehaviour{
    
    public GameObject[] buttons;
    public ButtonMechanics[] buttonScripts;
    public GameObject[] pressers;
    public bool[] buttonsDown;
    private float dist;
    public float distToDown;

    public GameObject door1;
    public GameObject block;

    // Start is called before the first frame update
    void Start(){
        for(int i = 0; i < buttons.Length; i++){
            buttonScripts[i] = buttons[i].GetComponent<ButtonMechanics>();
            buttonsDown[i] = false;
        }

    }

    // Update is called once per frame
    void Update(){
        for(int j = 0; j < buttons.Length; j++){
            buttonsDown[j] = false;
            for(int i = 0; i < pressers.Length; i++){
                //print(pressers[i].name);
                dist = Vector2.Distance(pressers[i].transform.position, buttons[j].transform.position);
                //print(dist);
                buttonsDown[j] |= dist < distToDown && pressers[i].transform.position.y > buttons[j].transform.position.y;
            }
        }

         door1.GetComponent<BoxCollider2D>().enabled = buttonsDown[3];
        
        if(buttonsDown[2]){
            block.SetActive(true);
        }
    }
}
