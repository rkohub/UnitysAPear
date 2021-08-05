using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour{
    
    public GameObject[] buttons;
    public ButtonMechanics[] buttonScripts;
    public GameObject[] pressers;
    public bool[] buttonsDown;
    private float dist;
    public float distToDown;
    public GameObject key1;
    public KeyMechanics key2;
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

        if(buttonsDown[0] && buttonsDown[1]){
            key1.SetActive(true);
        }

        key2.hasKey = buttonsDown[2];

        if(buttonsDown[3]){
            block.SetActive(true);
        }
    }
}
