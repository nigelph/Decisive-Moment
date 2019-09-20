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

    Animator anim;

    public Transform groundDetection;
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
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 2f);

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
        //Sets the boolean condition 'isAttacking' within the monster's animator component
        if (isAttacking)
        {
            anim.SetBool("isAttacking", true);
        }
        else
        {
            anim.SetBool("isAttacking", false);
        }

    }
    //Entered when an object enters the minotaur's box collider
    private void OnTriggerEnter2D(Collider2D col)
    {
        //Obtain the tag of the collider making contact
        Debug.Log(col.tag);
        //Checks that the box collider entered is the player's attack
        if (col.tag == "Attack")
        {
            //Moves the minotaur down to avoid the death animation causing the minotaur to float above the ground
            transform.Translate(0, -0.26f, 0);
            //Sets parameter within the minotaur's animator component to "true", triggering the death animation
            anim.SetBool("flagDie", true);
            //Destroys the minotaur object after 0.6 seconds (long enough for death animation to play)
            Destroy(this.gameObject, 0.6f);
        }
        //Checks if the box collider entered is the player's skill
        if (col.tag == "Skill")
        {
            transform.Translate(0, -0.26f, 0);
            anim.SetBool("flagDie", true);
            Destroy(this.gameObject, 0.6f);
        }

    }
}
