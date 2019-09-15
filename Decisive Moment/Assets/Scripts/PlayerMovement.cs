using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public GameObject diePrefab;
    public GameObject attackPrefab;
    public GameObject slimeDiePrefab;
    public GameObject skillPrefab;


    private AnimatorStateInfo mStateInfo;
    private bool rightFlg = true;

    public float moveSpeed = 5f;
    private float time_val = 0.4f;

    public Rigidbody2D rb;
    public Animator animator;

    //Jumping Variables
    private bool grounded = false;
    private float groundCheckRadius = 0.4f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float jumpForce = 8f;

    //HealthBar Variables
    public Image currentHealthBar;
    public Image currentManaBar;

    private float hitpoint = 100;
    private float maxhitpoint = 100;

    private void Start()
    {
        UpdateHealthBar();
    }

    void Awake()
    {
        animator = GetComponent<Animator>();
        mStateInfo = animator.GetCurrentAnimatorStateInfo(0);
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (grounded && Input.GetAxis("Jump") > 0)
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
            rightFlg = false;
        }
        else if (moveInput > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            rightFlg = true;
        }

        //Check if grounded
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        animator.SetBool("isGrounded", grounded);
        animator.SetFloat("verticalSpeed", rb.velocity.y);

        if (time_val >= 0.4f)
        {
            Attack();
            Casting();
        }
        else
        {
            animator.SetBool("isAttack", false);
            animator.SetBool("isCast", false);
            time_val += Time.deltaTime;
        }

    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.tag);
        switch (collision.tag)
        {
            case "Axe":
                TakeDamage(20);
                break;
            case "Monster":
                TakeDamage(5);
                break;
            case "Hero":
                break;
            case "Wall":
                break;
            case "Cliff":
                Die();
                break;
            default:
                break;
        }
    }

    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            animator.SetBool("isAttack", true);
            time_val = 0;
            Vector2 newPosition;
            if (rightFlg)
            {
                newPosition = new Vector2(transform.position.x + 1, transform.position.y);
            }
            else
            {
                newPosition = new Vector2(transform.position.x - 1, transform.position.y);
            }

            int layerMask = LayerMask.GetMask("Monster");
            RaycastHit2D hit = Physics2D.Raycast(newPosition, rightFlg ? Vector2.right : Vector2.left, 1f, layerMask);
            if (hit)
            {
                Destroy(hit.collider.gameObject);
                slimeDiePrefab.SetActive(true);
                Instantiate(slimeDiePrefab, hit.collider.gameObject.transform.position, hit.collider.gameObject.transform.rotation);
            }

        }
    }

    private void Casting()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            animator.SetBool("isCast", true);
            skillPrefab.SetActive(true);
            Instantiate(skillPrefab, transform.position, transform.rotation);//Quaternion.Euler(transform.eulerAngles)
            time_val = 0;
        }
    }

    private void Die()
    {
        diePrefab.SetActive(true);
        Instantiate(diePrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    //Health Bar Functions

    private void UpdateHealthBar()
    {
        float ratio = hitpoint / maxhitpoint;
        currentHealthBar.rectTransform.localScale = new Vector3(ratio, 1, 1);

    }

    private void TakeDamage(float dmg)
    {
        hitpoint -= dmg;
        if(hitpoint<0)
        {
            hitpoint = 0;
            Die();
        }
        UpdateHealthBar();

    }

    private void HealDamage(float heal)
    {
        hitpoint += heal;
        if (hitpoint > maxhitpoint)
        {
            hitpoint = maxhitpoint;
        }
        UpdateHealthBar();
    }


}
