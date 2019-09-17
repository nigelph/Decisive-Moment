using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    private int move_speed = 1;
    public Animator animator;

    private float timeValChangeDirection = 0;
    private int horizontal = -1;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {

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
                animator.SetBool("dieFlag", true);
                Destroy(gameObject, 0.483f);
                break;
            case "Skill":
                animator.SetBool("dieFlag", true);
                Destroy(gameObject, 0.483f);
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
}
