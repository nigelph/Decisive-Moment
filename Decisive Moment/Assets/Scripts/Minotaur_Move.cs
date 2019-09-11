using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minotaur_Move : MonoBehaviour
{
    float xDirection;

    [SerializeField]
    float speed = 3f;

    Rigidbody2D rb;

    bool facingRight = false;

    Vector3 localScale;

    // Start is called before the first frame update
    void Start()
    {
        localScale = transform.localScale;
        rb = GetComponent<Rigidbody2D>();
        xDirection = -1f;   
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < -9f)
        {
            xDirection = 1f;
        }
        else if(transform.position.x > 9f)
        {
            xDirection = -1f;
        }
        
    }
    void FixedUpdate()
    {
        rb.velocity = new Vector2(xDirection * speed, 0);
    }
    void LateUpdate()
    {
        FaceDirection();
    }
    void FaceDirection()
    {
        if(xDirection > 0)
        {
            facingRight = true;
        }
        else if(xDirection < 0)
        {
            facingRight = false;
        }

        if(((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
        {
            localScale.x *= 1;
        }

        transform.localScale = localScale;
    }
}
