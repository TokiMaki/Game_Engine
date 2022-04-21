using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannonball : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Explosion()
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, 15.0f);
        foreach(Collider col in cols)
        {
            if(col.GetComponent<Rigidbody>() != null)
            {
                col.GetComponent<Rigidbody>().AddExplosionForce(250.0f, transform.position, 15.0f, 250.0f);
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == 3 || other.gameObject.tag == "Player")
        {
            Explosion();
            Destroy(transform.root.gameObject);
        }
    }
}
