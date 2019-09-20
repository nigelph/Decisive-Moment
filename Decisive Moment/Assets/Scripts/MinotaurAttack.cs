using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinotaurAttack : MonoBehaviour
{
    //Code is entered upon the object entering the player character's box collider
    void OnTriggerEnter2D(Collider2D col)
    {
        //Checks that the box collider entered is the player's
        if (col.gameObject.name.Equals("Player"))
        {
            //Sets 'isAttacking' boolean variable within 'MinotaurPatrol' script to true, starting the attack animation
            MinotaurPatrol.isAttacking = true;
        }
    }

    //for unit test AI attack
    //public void OnTriggerEnter2D(string col)
    //{
    //    //Checks that the box collider entered is the player's
    //    if (col.Equals("Player"))
    //    {
    //        //Sets 'isAttacking' boolean variable within 'MinotaurPatrol' script to true, starting the attack animation
    //        MinotaurPatrol.isAttacking = true;
    //    }
    //}
    //Code is entered when the attack check object exits a collider
    void OnTriggerExit2D(Collider2D col)
    {
        //Checks that the box collider exited is the player's
        if (col.gameObject.name.Equals("Player"))
        {
            //Sets 'isAttacking' boolean variable within 'MinotaurPatrol' script to false, stopping the attack animation
            MinotaurPatrol.isAttacking = false;
        }
    }
}
