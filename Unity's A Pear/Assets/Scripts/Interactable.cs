using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour{

    public float interactRange;
    public Collider2D[] colls;
    public bool pressedButton;
    public Collider2D interactHitbox;
    public float hitboxUpTime;
    public float elapsedUpTime;

    // Start is called before the first frame update
    void Start(){
        colls = new Collider2D[10];
        pressedButton = false;
    }

    // Update is called once per frame
    void Update(){
        elapsedUpTime += Time.deltaTime;
        if(interactHitbox != null && elapsedUpTime > hitboxUpTime){
            interactHitbox.enabled = false;
        }

        if (Input.GetKeyDown("l")){
            //Debug.Log(Physics2D.OverlapCircle(this.gameObject.transform.position,interactRange,null,colls));
            colls = Physics2D.OverlapCircleAll(this.gameObject.transform.position, interactRange);
            for (int i = 0; i < colls.Length; i++){
                if(colls[i].gameObject.tag == "Button"){
                    pressedButton = true;
                    colls[i].gameObject.GetComponent<ButtonControl>().buttonPressed();
                }
            }

            if(!pressedButton && interactHitbox != null){
                interactHitbox.enabled = true;
                elapsedUpTime = 0;
            }
        }




        pressedButton = false;
    }
}
    