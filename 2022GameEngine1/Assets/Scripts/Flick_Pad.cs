using System;
using System.Collections;
using System.Collections.Generic;
//using UnityEditor.ShaderGraph.Serialization;
using UnityEngine;

public class Flick_Pad : MonoBehaviour
{
    // Start is called before the first frame update
    public Material Pad_Mat;
    public bool check_Player;
    void Start()
    {
        Pad_Mat = gameObject.GetComponent<Renderer>().material;
        check_Player = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (check_Player)
        {
            Pad_Mat.SetFloat("_changeAlpha",1f);
        }
        else
        {
            Pad_Mat.SetFloat("_changeAlpha",0f);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            print("check");
            check_Player = true;

        }
        else
        {
            print("no");
            check_Player = false;

        }
    }
}
