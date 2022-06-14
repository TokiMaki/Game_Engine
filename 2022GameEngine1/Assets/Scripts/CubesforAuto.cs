using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubesforAuto : MonoBehaviour
{
    public List<int> cubes = new List<int>();
    
    public static CubesforAuto instance;
    
    private void Awake()
    {
        if (CubesforAuto.instance == null)
        {
            DontDestroyOnLoad(this);
            CubesforAuto.instance = this;
        }
        else
        {
            if(instance!=this)
                Destroy(this.gameObject);
        }
    }

    public void AddCubeOnList(int val)
    {
        cubes.Add(val);
    }
}
