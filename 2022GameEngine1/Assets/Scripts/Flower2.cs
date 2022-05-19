using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower2 : MonoBehaviour
{
    public GameObject face;
    public GameObject petal;

    public bool rotateFace = true;
    public float rotateFaceSpeed = 30f;
    public bool rotatePetal = true;
    public float rotatePetalSpeed = 30f;

    private void FixedUpdate()
    {
        if (rotateFace) RotateFace(rotateFaceSpeed);
        if (rotatePetal) RotatePetal(rotatePetalSpeed);
    }

    private void RotateFace(float speed)
    {
        face.transform.Rotate(Vector3.forward, speed);
    }
    
    private void RotatePetal(float speed)
    {
        petal.transform.Rotate(Vector3.up, speed);
    }
}
