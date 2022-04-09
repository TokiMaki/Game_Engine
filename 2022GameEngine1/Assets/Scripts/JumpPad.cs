using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    public float force;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //other.attachedRigidbody.velocity = Vector3.zero;
        other.attachedRigidbody.AddForce(Vector3.up * force, ForceMode.VelocityChange);
    }
}
