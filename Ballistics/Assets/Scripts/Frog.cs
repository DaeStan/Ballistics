using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour
{
    public float myTimeScale = 1.0f;
    public GameObject target;
    public float launchForce = 10f;
    Rigidbody rb;
    Vector3 startPos;

    FiringSolutuion fs = new FiringSolutuion();

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        Time.timeScale = myTimeScale; // allow for slowing time to see what's happening
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.E)) 
        {
            if (fs.swimToggle == false)
            {
                fs.swimToggle = true;
            }
            else
            {
                fs.swimToggle = false;
            }
            Debug.Log(fs.swimToggle);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Nullable<Vector3> aimVector = fs.Calculate(transform.position, target.transform.position, launchForce, Physics.gravity);
            if (aimVector.HasValue)
            {
                rb.AddForce(aimVector.Value.normalized * launchForce, ForceMode.VelocityChange);
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            // reset
            rb.isKinematic = true;
            transform.position = startPos;
            rb.isKinematic = false;
        }
    }
}
