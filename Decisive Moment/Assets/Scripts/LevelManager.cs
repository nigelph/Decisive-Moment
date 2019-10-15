using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    //number of seconds after player death before respawn
    public float respawnDelay;
    //create instance of the player's main method
    public PlayerMovement gamePlayer;

    // Start is called before the first frame update
    void Start()
    {
        //instantiate object
        gamePlayer = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    //Called by player movement when player dies with lives remaining and begins coroutine
    //coroutine allows process to occur without disturbing the rest of the games events
    public void Respawn()
    {
        StartCoroutine("RespawnCoroutine");

    }
    //called by Respawn() class
    public IEnumerator RespawnCoroutine()
    {
        //set player object inncactive
        gamePlayer.gameObject.SetActive(false);
        //Causes the game to wait for a set period of time as in-game events continue (a respawn delay)
        yield return new WaitForSeconds(respawnDelay);
        //Places the player at the most recently set respawn point
        gamePlayer.transform.position = gamePlayer.respawnPoint;
        //sets the player active again
        gamePlayer.gameObject.SetActive(true);

    }
}
