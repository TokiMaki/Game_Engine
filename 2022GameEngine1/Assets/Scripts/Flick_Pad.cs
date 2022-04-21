using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flick_Pad : MonoBehaviour
{
    // Start is called before the first frame update
    public Material Pad_Mat;
    void Start()
    {
        Pad_Mat = gameObject.GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            print("check");
            Pad_Mat.SetFloat("_change_Alpha",1);
        }
        else
        {
            print("no");
            Pad_Mat.SetFloat("_change_Alpha",0);
        }
    }
}
