using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    private int move_speed = 8;
    // Start is called before the first frame update
    void Start()
    {
        
        Destroy(gameObject, 0.583f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.right * move_speed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Hero":
                break;
            case "Wall":
                Destroy(gameObject,0.15f);
                break;
            case "Monster":
                Destroy(gameObject,0.15f);
                break;
            case "Cliff":
                break;
            default:
                break;
        }
    }
}
