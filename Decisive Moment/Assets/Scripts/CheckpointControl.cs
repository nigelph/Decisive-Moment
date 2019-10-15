using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointControl : MonoBehaviour
{
    public Sprite redFlag;
    public Sprite greenFlag;
    private SpriteRenderer checkpointRenderer;
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
}
