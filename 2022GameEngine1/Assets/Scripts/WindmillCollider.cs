using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindmillCollider : MonoBehaviour
{
    private BoxCollider _boxCollider;
    private float _Force = 500.0f;
    void Start()
    {
        _boxCollider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Rigidbody otherRigidbody = other.GetComponent<Rigidbody>();
            otherRigidbody.AddForce(transform.root.forward * Time.deltaTime * _Force);
        }
    }
}
