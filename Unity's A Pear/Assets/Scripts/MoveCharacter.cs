using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharacter : MonoBehaviour{
    // Start is called before the first frame update

    //Todo
    //Fix Error where reset jumps on hit bottom of platforms

    
    private float jumpMagnitude;
    private Rigidbody2D body;
    private float accelerationMagnitude;
    public bool coll;
    public float baseJumpMagnitude;
    public float baseAccel;
    public float baseMaxVelocity;
    public int baseMaxJumps;
    private int maxJumps;
    private int jumpsUsed;
    private float maxVelocity;
    private Vector2 force;
    public float airScalar;
    public bool isGround;
    public LegsControl legScript;
    private float moveScalar;
    public bool isFacingRight;
    public float scaleConst;
    public Collider2D interactHitbox;

    private ContactPoint2D[] contacts = new ContactPoint2D[10];

    void Start(){
        body = this.gameObject.GetComponent<Rigidbody2D>();
        jumpsUsed = maxJumps;
        isFacingRight = true;
    }

    // Update is called once per frame
    void Update(){
        if(coll){
            moveScalar = 1;
        }else{
            moveScalar = airScalar;
        }
        if(this.gameObject.name == "Legs" && legScript.attached){
            jumpMagnitude         = legScript.attJumpMagnitude;
            accelerationMagnitude = legScript.attAccelerationMagnitude * moveScalar;
            maxVelocity           = legScript.attMaxVelocity;
            maxJumps              = legScript.attMaxJumps;
        }else{
            jumpMagnitude         = baseJumpMagnitude;
            accelerationMagnitude = baseAccel * moveScalar;
            maxVelocity           = baseMaxVelocity;
            maxJumps              = baseMaxJumps;
        }

        if(Mathf.Abs(body.velocity[0]) > maxVelocity){
            //Debug.Log("CAPING SPEED");
            body.velocity = new Vector2 (Mathf.Sign(body.velocity[0]) * maxVelocity,body.velocity[1]);
        }
        
        
        if (Input.GetKey("a")){
            //Debug.Log("AAA");
            body.AddForce(Vector2.left * accelerationMagnitude);
            isFacingRight = false;
        }
        if (Input.GetKey("d")){
            //Debug.Log("DDDD");
            body.AddForce(Vector2.right * accelerationMagnitude);
            isFacingRight = true;
        }

        //scaleConst = this.gameObject.name == "Head" ? 1.0f : 0.5f; // Head is scaled diffeerntly from legs
                                                    //I have been forced to repent for my sins
                                            //Flips Model to face forward depending on move diretion
        //this.gameObject.transform.localScale = new Vector3 (scaleConst * (isFacingRight ? 1:-1), this.gameObject.transform.localScale[1], this.gameObject.transform.localScale[2]);                               //sowwy uwu
        interactHitbox.offset = new Vector2 ((isFacingRight ? 1:-1), 0);

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
        checkGrounded(collision);
    }

    // void OnCollisionStay2D(Collision2D collision){
        // checkGrounded(collision);
    // }

    public void checkGrounded(Collision2D collision){
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
                    // Debug.Log(contacts[i].normal.x);
                    // Debug.Log(Mathf.Abs(contacts[i].normal.x) < 0.01);
                    // Debug.Log(contacts[i].point.x);
                    // Debug.Log(contacts[i].point.y);
                    // Debug.Log(collision.gameObject.transform.position.y);
                    // Debug.Log(contacts[i].point.y > collision.gameObject.transform.position.y);
                    isGround = Mathf.Abs(contacts[i].normal.x) < 0.01 && contacts[i].point.y > collision.gameObject.transform.position.y;
                    // Debug.Log(isGround);
                    if(isGround){
                        break;
                    }
                }
            }
        }

        Debug.Log("ENDED");
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
