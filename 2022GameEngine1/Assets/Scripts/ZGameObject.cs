using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ZGameObject : MonoBehaviour
{
    private Transform _LookAt;
    // Update is called once per frame
    private void Start()
    {
        _LookAt = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        transform.position = new Vector3(0, 0, _LookAt.position.z);
    }
}
