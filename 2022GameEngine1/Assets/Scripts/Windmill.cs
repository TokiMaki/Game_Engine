using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Windmill : MonoBehaviour
{
    public GameObject wing;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        wing.transform.Rotate(new Vector3(0, 0, 1), 360 * Time.deltaTime);
    }
}
