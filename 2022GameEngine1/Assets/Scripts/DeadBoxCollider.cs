using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadBoxCollider : MonoBehaviour
{
    private BoxCollider _boxCollider;
    // Start is called before the first frame update
    void Start()
    {
        _boxCollider = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            var otherPlayerState = other.GetComponent<PlayerState>();
            otherPlayerState.Die();
        }
    }
}
