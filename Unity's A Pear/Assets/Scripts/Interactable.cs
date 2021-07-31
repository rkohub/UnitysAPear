using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour{

    public float interactRange;
    public Collider2D[] colls;

    // Start is called before the first frame update
    void Start(){
        colls = new Collider2D[10];
    }

    // Update is called once per frame
    void Update(){
        if (Input.GetKeyDown("l")){
            //Debug.Log(Physics2D.OverlapCircle(this.gameObject.transform.position,interactRange,null,colls));
            colls = Physics2D.OverlapCircleAll(this.gameObject.transform.position, interactRange);
            for (int i = 0; i < colls.Length; i++){
                if(colls[i].gameObject.tag == "Button"){
                   colls[i].gameObject.GetComponent<ButtonControl>().buttonPressed();
                }
            }
        }
    }
}
    