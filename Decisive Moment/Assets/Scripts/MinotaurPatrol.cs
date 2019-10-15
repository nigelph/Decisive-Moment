using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinotaurPatrol : MonoBehaviour
{
    //Dictates how fast the enemy moves
    public float speed;
    //Checks direction
    private bool movingRight = true;
    //Checks if the monster is currently attacking
    public static bool isAttacking = false;
    //Amount of health the monster has
    public int hitPoints;
    //Checks whether the monster is currently being attacked
    public bool recievingDamage;
    //Records position of player character
    private float playerPosition;
    //Records position of this monster
    private float xPosition;
    //Boolean variable recording whether the minotaur is in the process of dying. Important to avoid a glitch where the raycast frontInfo gets stuck in the ground as it dies
    private bool isDying = false;
    //This monster's animator component will be accessed throught this variable
    Animator anim;

    public Transform groundDetection;
    public Transform frontDetection;

    //The varable for unitTest
    //public bool flagDie = false;

    // Start is called before the first frame update
    void Start()
    {
        //Gets the monster's animator component
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Moves the monster by a set speed
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        //Sends a ray downward from the groundInfo object to check if there is ground underneath where the monster is heading
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 1f);
        //Sends a ray to the right of the frontInfo object slightly to check if there is an obstacle in the way
        RaycastHit2D frontInfo = Physics2D.Raycast(frontDetection.position, Vector2.right, 0.01f);
        //If there is no ground ahead
        if (groundInfo.collider == false)
        {
            //Change direction to face left
            if (movingRight)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            //Change direction to face right
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
        //If there is something in front of the minotaur and the minotaur is also not dying already 
        if (frontInfo.collider == true && !isDying)
        {
            //Checks that the object in front of the minotaur is a tile (the environment)
            if(frontInfo.collider.tag == "Tile")
            {
                //Change direction to face left
                if (movingRight)
                {
                    transform.eulerAngles = new Vector3(0, -180, 0);
                    movingRight = false;
                }
                //Change direction to face right
                else
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    movingRight = true;
                }

            }

        }
        //Sets the boolean condition 'isAttacking' within the monster's animator component
        if (isAttacking)
        {
            anim.SetBool("isAttacking", true);
        }
        else
        {
            anim.SetBool("isAttacking", false);
        }
        //Sets the boolean condition 'isDamaged' within the monster's animator component 
        if(recievingDamage)
        {
            anim.SetBool("isDamaged", true);
        }
        else
        {
            anim.SetBool("isDamaged", false);
        }
        
    }

    //Entered when an object enters the minotaur's box collider
    private void OnTriggerEnter2D(Collider2D col)
    {
        //Get positions of player character and monster
        playerPosition = GameObject.Find("Player").transform.position.x;
        xPosition = transform.position.x;

        //Obtain the tag of the collider making contact
        Debug.Log(col.tag);
        //Checks that the box collider entered is the player's attack
        if (col.tag == "Attack")
        {
            //Checks if the monster has sufficient hitpoints remaining to survive the attack
            if (hitPoints > 1)
            {
                //Set this boolean variable to true to activate the damage animation in the next frame
                recievingDamage = true;
                //Decrease the amount of hitpoints remaining by 1
                hitPoints--;

                //Checks which direction to knock the monster back when attacked based on its position and movement direction
                if (xPosition > playerPosition && !movingRight)
                {
                    transform.Translate(-0.5f, 0, 0);
                }
                else if (xPosition > playerPosition && movingRight)
                {
                    transform.Translate(0.5f, 0, 0);
                }
                else if (xPosition < playerPosition && !movingRight)
                {
                    transform.Translate(0.5f, 0, 0);
                }
                else if (xPosition < playerPosition && movingRight)
                {
                    transform.Translate(-0.5f, 0, 0);
                }             
            }
            else
            {
                //Reports that the minotaur is now dying
                isDying = true;
                //Moves the minotaur down to avoid the death animation causing the minotaur to float above the ground
                transform.Translate(0, -0.26f, 0);
                //Sets parameter within the minotaur's animator component to "true", triggering the death animation
                anim.SetBool("flagDie", true);
                //Destroys the minotaur object after 0.6 seconds (long enough for death animation to play)
                Destroy(this.gameObject, 0.6f);
            }
            
        }
        //Checks if the box collider entered is the player's skill
        if (col.tag == "Skill")
        {
            if (hitPoints > 1)
            {
                recievingDamage = true;
                hitPoints--;

                //Removed knockback from fireball attack as it is too glitchy
                /*
                if (xPosition > playerPosition && !movingRight)
                {
                    transform.Translate(-0.35f, 0, 0);
                }
                else if (xPosition > playerPosition && movingRight)
                {
                    //transform.Translate(0.35f, 0, 0);
                }
                else if (xPosition < playerPosition && !movingRight)
                {
                    //transform.Translate(0.35f, 0, 0);
                }
                else if (xPosition < playerPosition && movingRight)
                {
                    transform.Translate(-0.35f, 0, 0);
                }*/
               
            }
            else
            {
                isDying = true;
                transform.Translate(0, -0.26f, 0);
                anim.SetBool("flagDie", true);
                Destroy(this.gameObject, 0.6f);
            }   
        }
    }

    //public void OnTriggerEnter2D(string col)
    //{

    //    //Checks that the box collider entered is the player's attack
    //    if (col.Equals("Attack"))
    //    {
    //        //Sets parameter within the minotaur's animator component to "true", triggering the death animation
    //        flagDie = true;
    //    }
    //    //Checks if the box collider entered is the player's skill
    //    if (col.Equals("Skill"))
    //    {
    //        flagDie = true;
    //    }

    //}
}
