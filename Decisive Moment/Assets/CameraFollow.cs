using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform m_playerTransform;

    //set the distance which the charactor can most seen
    public float Ahead = 0;

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
        targetPos = new Vector3(m_playerTransform.position.x + Ahead, m_playerTransform.position.y, gameObject.transform.position.z);
        //targetPos = new Vector3(m_playerTransform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);

        //if (m_playerTransform.position.x > 0f || m_playerTransform.position.y > 0f)
        //{
        //    targetPos = new Vector3(m_playerTransform.position.x + Ahead, gameObject.transform.position.y, gameObject.transform.position.z);
        //}
        //else
        //{
        //    targetPos = new Vector3(m_playerTransform.position.x - Ahead, gameObject.transform.position.y, gameObject.transform.position.z);
        //}

        transform.position = Vector3.Lerp(transform.position, targetPos, smooth * Time.deltaTime);

    }
}


