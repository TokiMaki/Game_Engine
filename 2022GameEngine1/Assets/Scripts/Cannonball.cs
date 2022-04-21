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
        Collider[] cols = Physics.OverlapSphere(transform.position, 10.0f);
        foreach(Collider col in cols)
        {
            if(col.GetComponent<Rigidbody>() != null)
            {
                col.GetComponent<Rigidbody>().AddExplosionForce(100.0f, transform.position, 10.0f);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 3 || other.tag == "Player")
        {
            Explosion();
            Destroy(this);
        }
    }
}
