using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject diePrefab; 

    public float moveSpeed = 5f;
    private float time_val;

    public Rigidbody2D rb;
    public Animator animator;

    //Jumping Variables
    private bool grounded = false;
    private float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float jumpForce = 5f;
    void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (grounded && Input.GetAxis("Jump")>0)
        {
            grounded = false;
            animator.SetBool("isGrounded", grounded);
            rb.AddForce(new Vector2(0, jumpForce));
        }
    }

    void FixedUpdate()
    {
        //Retrieve keyboard input and calculate run speed
        float moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        //Running animation toggle check
        if (moveInput == 0)
        {
            animator.SetBool("isRunning", false);
        }
        else
        {
            animator.SetBool("isRunning", true);
        }

        //Flip character based on position
        if (moveInput < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if (moveInput > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

        //Check if grounded
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        animator.SetBool("isGrounded", grounded);
        animator.SetFloat("verticalSpeed", rb.velocity.y);

        if (time_val >= 0.4f)
        {
            Attack(moveInput);
        }
        else
        {
            time_val += Time.deltaTime;
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Hero":
                break;
            case "Wall":
                break;
            case "Monster":
                break;
            case "Cliff":
                Die();
                break;
            default:
                break;
        }
    }

    private void Attack(float moveInput)
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            //Flip
            if (moveInput < 0)
            {

            }
            else
            {

            }
            time_val = 0;
        }
    }

    private void Die()
    {
        diePrefab.SetActive(true);
        Instantiate(diePrefab,transform.position,transform.rotation);
        Destroy(gameObject);
    }
}
