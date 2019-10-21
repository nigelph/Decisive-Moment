using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnLogic : MonoBehaviour
{
    public PlayerMovement gamePlayer;
    public GameObject checkPoint1;
    public GameObject checkPoint2;
    
    public IList<GameObject> slimes = new List<GameObject>();
    public IList<GameObject> minotaurs = new List<GameObject>();
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        //instantiate object
        gamePlayer = FindObjectOfType<PlayerMovement>();
        checkPoint1 = GameObject.Find("Checkpoint (1)");
        checkPoint2 = GameObject.Find("Checkpoint");

        for (int i = 0;i<13;i++)
        {
            slimes.Add(GameObject.Find("Slime (" + (i + 1) + ")"));
        }

        for (int i=0;i<8;i++)
        {
            minotaurs.Add(GameObject.Find("Minotaur (" + (i + 1) + ")"));
        }
    }
    public void respawn()
    {
        StartCoroutine("RespawnPlayer");
    }
    public IEnumerator RespawnPlayer()
    {
        gamePlayer.gameObject.SetActive(false);
        //Causes the game to wait for a set period of time as in-game events continue (a respawn delay)
        yield return new WaitForSeconds(2);
        //Places the player at the most recently set respawn point
        gamePlayer.transform.position = gamePlayer.startPoint;
        //sets the player active again
        gamePlayer.gameObject.SetActive(true);
        Debug.Log(slimes.Count);
        for(int i = 0; i<13; i++)
        {
            if (slimes[i].GetComponent<Slime>().dead)
            {
                slimes[i] = (GameObject)Instantiate(slimes[i], slimes[i].GetComponent<Slime>().initialPosition, Quaternion.identity);
                slimes[i].gameObject.SetActive(true);
                slimes[i].GetComponent<Slime>().dead = false;
            }
        }

        for (int i=0; i<8;i++)
        {
            if (minotaurs[i].GetComponent<MinotaurPatrol>().dead)
            {
               

                minotaurs[i] = (GameObject)Instantiate(minotaurs[i], minotaurs[i].GetComponent<MinotaurPatrol>().initialPosition, Quaternion.identity);
                minotaurs[i].GetComponent<MinotaurPatrol>().speed = 3.0f;
                minotaurs[i].gameObject.SetActive(true);
                minotaurs[i].GetComponent<MinotaurPatrol>().isDying = false;
                minotaurs[i].GetComponent<MinotaurPatrol>().dead = false;
                minotaurs[i].GetComponent<MinotaurPatrol>().hitPoints = 2;
             
                


            }
        }
        checkPoint1.GetComponent<CheckpointControl>().changeColor(true);
        checkPoint2.GetComponent<CheckpointControl>().changeColor(true);



    }
}
