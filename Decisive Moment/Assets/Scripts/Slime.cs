using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    private int move_speed = 1;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-transform.right*move_speed*Time.deltaTime,Space.World);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Hero":
                break;
            case "Wall":
                transform.eulerAngles = new Vector3(0, transform.position.y+180, 0);
                break;
            case "Monster":
                break;
            case "Cliff":
                break;
            default:
                break;
        }
    }
}
