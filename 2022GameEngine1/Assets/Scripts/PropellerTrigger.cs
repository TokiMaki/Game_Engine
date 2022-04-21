using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PropellerTrigger : MonoBehaviour
{
    private BoxCollider _boxCollider;

    private float _Force = 2000;
    // Start is called before the first frame update
    void Start()
    {
        _boxCollider = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
             Vector3 closestPointOnBounds = other.ClosestPointOnBounds(transform.position);
             Vector3 closestPointOnBoundsdir = other.transform.position - closestPointOnBounds;
             closestPointOnBoundsdir = closestPointOnBoundsdir.normalized;
             // other.attachedRigidbody.velocity = -other.attachedRigidbody.velocity;
             other.attachedRigidbody.AddForce(closestPointOnBoundsdir * _Force);
             // other.attachedRigidbody.AddForce(-transform.forward * _Force);
        }
            
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Player")
        {
            Vector3 closestPointOnBounds = other.contacts[0].point;
            Vector3 closestPointOnBoundsdir = other.transform.position - closestPointOnBounds;
            closestPointOnBoundsdir = closestPointOnBoundsdir.normalized;
            // other.attachedRigidbody.velocity = -other.attachedRigidbody.velocity;
            other.rigidbody.AddForce(closestPointOnBoundsdir * _Force);
            // other.attachedRigidbody.AddForce(-transform.forward * _Force);
        }
            
    }
}
