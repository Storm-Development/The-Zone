using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    // Start is called before the first frame update
    float maxLeft = -3.5f;
    float maxRight = 3.5f;
    float currentz = 0;
    float startTime;
    float jumpTime = 0.0f;
    
    [SerializeField] float jumpHeight = 5f;
    [SerializeField] float hangTime = 1.0f;
    [SerializeField] Camera cam;
    bool isJumping = false;
    float currentSpeed = 10.0f;
    float timeForSpeed = 0.0f;
    float timeCheck = 0.0f;
    void Start()
    {
        startTime = Time.time;
        timeForSpeed = Time.time;
        timeCheck = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        
        currentz = transform.position.z;
        float horizontal = transform.position.x;

        Debug.Log(Time.time);
        if (Time.time - timeForSpeed > 5)
        {
            if(cam.fieldOfView == 60)
            {
                cam.fieldOfView = 90;
            }
            cam.fieldOfView = cam.fieldOfView - 1;
            timeForSpeed = Time.time;
            currentSpeed = currentSpeed * 1.05f;
        }

        if (Input.GetKey("a"))
        {
            horizontal = maxLeft;
        }
        else if (Input.GetKey("d"))
        {
            horizontal = maxRight;

        }

        if(Time.time < jumpTime)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, jumpHeight, currentz + currentSpeed), Time.deltaTime);
        } else
        {
            if (Input.GetKeyDown("w"))
            {
                jumpTime = Time.time + hangTime;
            }
            transform.position = Vector3.Lerp(transform.position, new Vector3(horizontal, 0.0f, currentz + currentSpeed), Time.deltaTime);
        }
       
        timeCheck = Time.time;

    }
}
