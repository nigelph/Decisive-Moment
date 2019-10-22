using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime_Die : MonoBehaviour
{
    //
    PlayerMovement playerHealth = new PlayerMovement();

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 0.333f);
        //
        playerHealth.HealDamage(30);
        playerHealth.UpdateHealthBar();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
