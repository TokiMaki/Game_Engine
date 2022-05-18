using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    void Update()
    {
       transform.Rotate(Vector3.forward*10*Time.deltaTime);
    }
}
