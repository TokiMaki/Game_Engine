using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadBoxCollider : MonoBehaviour
{
    private BoxCollider _boxCollider;

    public PlayerState _PlayerState;

    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        _boxCollider = GetComponent<BoxCollider>();
    }

    private void Update()
    {
        transform.position = Player.transform.position;
        transform.position -= new Vector3(0, 0, 1);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            _PlayerState.getDamage();
        }
    }
}
