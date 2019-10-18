using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Initial_Option : MonoBehaviour
{
    private int selection = 1;
    public Transform PosOne;
    public Transform PosTwo;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            selection = 1;
            transform.position = PosOne.position;
        }else if (Input.GetKeyDown(KeyCode.S))
        {
            selection = 2;
            transform.position = PosTwo.position;
        }
        if (selection==1 && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(1);
        }
        if (selection == 2 && Input.GetKeyDown(KeyCode.Space))
        {
            Application.Quit();
        }
    }
}
