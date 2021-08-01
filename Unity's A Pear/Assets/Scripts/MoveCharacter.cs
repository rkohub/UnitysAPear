using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharacter : MonoBehaviour{
    // Start is called before the first frame update

    //Todo
    //Fix Error where reset jumps on hit bottom of platforms

    public float baseJumpMagnitude;
    public float jumpMagnitude;
    private Rigidbody2D body;
    public float baseAccel;
    public float accelerationMagnitude;
    public bool coll;
    public int baseMaxJumps;
    public int maxJumps;
    public int jumpsUsed;
    public float baseMaxVelocity;
    public float maxVelocity;
    private Vector2 force;
    public float airScalar;
    public bool isGround;

    private ContactPoint2D[] contacts = new ContactPoint2D[10];

    void Start(){
        body = this.gameObject.GetComponent<Rigidbody2D>();
        // airScalar = 0.75f;
        jumpsUsed = maxJumps;
    }

    // Update is called once per frame
    void Update(){
        if(coll){
            accelerationMagnitude = baseAccel;
            maxVelocity = baseMaxVelocity;
        }else{
            accelerationMagnitude = baseAccel * airScalar;
            maxVelocity = baseMaxVelocity * airScalar;
        }

        if(Mathf.Abs(body.velocity[0]) > maxVelocity){
            body.velocity = new Vector2 (Mathf.Sign(body.velocity[0]) * maxVelocity,body.velocity[1]);
        }
        
        if (Input.GetKey("d"))
        {
            body.AddForce(Vector2.right * accelerationMagnitude);
        }
        if (Input.GetKey("a")){
            body.AddForce(Vector2.left * accelerationMagnitude);
        }
        if (!Input.GetKey("a") && !Input.GetKey("d"))
        {
            // Add in some sort of drag. If the player is holding no keys, they should slow down significantly,
            // both in the air and on the ground. Cover w/ Ryan during meeting on Sunday
        }

        if ((Input.GetKeyDown("space") || Input.GetKeyDown("w")) && jumpsUsed < maxJumps){
            jump();
        }

         // print(body.velocity);
    }

    public void jump(){
       body.velocity = new Vector2 (body.velocity[0],0);
       body.AddForce(Vector2.up * jumpMagnitude);
       jumpsUsed += 1;
    }

    void OnCollisionEnter2D(Collision2D collision){
        //Maybe Just ON Collision??? So it can reset on a tilting block


        Debug.Log("COLL");
        //Debug.Log(collision.gameObject.name); //This is the incomming collider or the one you are landing on.
        //Debug.Log(collision.otherCollider.gameObject.name); //yourself. Other thing is yourself. Because usually the primary collider you are worried about in a collision is what you hit so the other less important thing would be yourself
        //Collision. collider is the collider of the thing you oare landing on.
        collision.collider.GetContacts(contacts);
        // Debug.Log(contacts.Length);
        for(int i = 0; i < contacts.Length; i++){
            //If there is another collider. aka just not using up the empty space in the array
            if(contacts[i].otherCollider != null){
                //Debug.Log(contacts[i]);
                //Debug.Log(contacts[i].collider.gameObject.name); //The thing that hit the thing you landed on. aka you
                //Debug.Log(contacts[i].otherCollider.gameObject.name); //yourself (aka the thing that is getting collided with) (see above)
                if(contacts[i].collider.gameObject.tag == "Man"){
                    isGround = Mathf.Abs(contacts[i].normal.x) < 0.01 && contacts[i].point.y > collision.gameObject.transform.position.y;
                }
            }
        }
        //Debug.Log(contacts[0].normal.x);
        //Debug.Log(Mathf.Abs(contacts[0].normal.x) < 0.01);
        // Debug.Log(contacts[0].point.y);
        // Debug.Log(collision.gameObject.name);
        // Debug.Log(collision.gameObject.transform.position.y);

        //bool isGround = Mathf.Abs(contacts[0].normal.x) < 0.01 && contacts[0].point.y > collision.gameObject.transform.position.y;
        Debug.Log(isGround);

        if(isGround){//&& collision.gameObject.tag == "Stage" && ){
            coll = true;
            jumpsUsed = 0;
        }
    }

    void OnCollisionExit2D(Collision2D collision){
        if(collision.gameObject.tag == "Stage"){
            coll = false;
        }
    }
}
