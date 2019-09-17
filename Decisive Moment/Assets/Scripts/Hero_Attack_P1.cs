using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero_Attack_P1 : MonoBehaviour
{
    //public GameObject playerPrefab;
    // Start is called before the first frame update
    void Start()
    {
        //Invoke("InitialHero",0.333f);
        Destroy(gameObject, 0.333f);
    }

    // Update is called once per frame
    void Update()
    {

    }
    //void InitialHero()
    //{
    //  Instantiate(playerPrefab, transform.position, transform.rotation);
    //  playerPrefab.SetActive(true);
    //}
}
