using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointControl : MonoBehaviour
{
    public Sprite redFlag;
    public Sprite greenFlag;
    public SpriteRenderer checkpointRenderer;
    public bool reachedCheckpoint;
    // Start is called before the first frame update
    void Start()
    {
        checkpointRenderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.name.Equals("Player"))
        {
            checkpointRenderer.sprite = greenFlag;
            reachedCheckpoint = true;
        }
    }

    public void changeColor(bool reset)
    {
        Debug.Log("Enters");
        if (reset)
        {
            checkpointRenderer.sprite = redFlag;
            reachedCheckpoint = false;
        }
        else
        {
            checkpointRenderer.sprite = greenFlag;
            reachedCheckpoint = true;
        }
    }

    //Unit Test for changeColor
    //public bool changeColor(bool reset)
    //{
    //    Debug.Log("Enters");
    //    if (reset)
    //    {
    //        checkpointRenderer.sprite = redFlag;
    //        reachedCheckpoint = false;
    //        return false;
    //    }
    //    else
    //    {
    //        checkpointRenderer.sprite = greenFlag;
    //        reachedCheckpoint = true;
    //        return true;
    //    }

    //}

}
