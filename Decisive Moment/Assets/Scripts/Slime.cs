using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    private int move_speed = 1;
    public Animator animator;

    private float timeValChangeDirection = 0;
    private int horizontal = -1;

    public int hitPoints;

    public Vector3 initialPosition;
    //Checks whether the monster is currently being attacked
    public bool recievingDamage;
    public bool dead = false;

    //
    PlayerMovement playerHealth = new PlayerMovement();

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        initialPosition = transform.position;
    }

    void Update()
    {
        //Sets the boolean condition 'isDamaged' within the monster's animator component 
        if (recievingDamage)
        {
            animator.SetBool("takeDamage", true);
        }
        else
        {
            animator.SetBool("takeDamage", false);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.tag);
        switch (collision.tag)
        {
            case "Wall":
                transform.eulerAngles = new Vector3(0, transform.position.y + 180, 0);
                break;
            case "Attack":
                if (hitPoints > 0)
                {
                    //Set this boolean variable to true to activate the damage animation in the next frame
                    recievingDamage = true;
                    //Decrease the amount of hitpoints remaining by 1
                    hitPoints--;
                }
                else
                {
                    animator.SetBool("dieFlag", true);
                    // Destroy(gameObject, 0.483f);
                    StartCoroutine("ExecuteAfterTime");
                    dead = true;
                    //TODO
                    playerHealth.HealDamage(30);
                    playerHealth.UpdateHealthBar();
                }
                recievingDamage = false;
                break;
            case "Skill":
                if (hitPoints > 0)
                {
                    //Set this boolean variable to true to activate the damage animation in the next frame
                    recievingDamage = true;
                    //Decrease the amount of hitpoints remaining by 1
                    hitPoints = hitPoints -3;
                }
                else
                {
                    animator.SetBool("dieFlag", true);
                    // Destroy(gameObject, 0.483f);
                    StartCoroutine("ExecuteAfterTime");
                    dead = true;
                    //TODO
                    playerHealth.HealDamage(30);
                    playerHealth.UpdateHealthBar();
                }
                recievingDamage = false;
                break;
            default:
                break;
        }
    }

    public void Move()
    {
        if (timeValChangeDirection >= 2)
        {
            horizontal = horizontal * -1;
            timeValChangeDirection = 0;
            if (horizontal == -1)
            {
                animator.SetBool("moveRight", false);
                animator.SetBool("moveLeft", true);
            }
            else
            {
                animator.SetBool("moveLeft", false);
                animator.SetBool("moveRight", true);
            }
        }
        else
        {
            timeValChangeDirection += Time.deltaTime;
        }
        transform.Translate(transform.right * move_speed * Time.fixedDeltaTime * horizontal, Space.World);

    }
    IEnumerator ExecuteAfterTime()
    {

        yield return new WaitForSeconds(1);

        // Code to execute after the delay

        gameObject.SetActive(false);
    }

}
