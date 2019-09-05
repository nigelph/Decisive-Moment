using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform m_playerTransform;

    //set the distance which the charactor can most seen
    public float Ahead = 0;
    public float differnce_x = 23.9f;
    public float differnce_y = 0f;

    //Set the target position of camera
    public Vector3 targetPos;

    //set smooth move adaptor
    public float smooth = 1000;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (m_playerTransform != null)
        {
            targetPos = new Vector3(m_playerTransform.position.x + Ahead + differnce_x, m_playerTransform.position.y + differnce_y, gameObject.transform.position.z);

            transform.position = Vector3.Lerp(transform.position, targetPos, smooth * Time.deltaTime);
        }

    }
}


