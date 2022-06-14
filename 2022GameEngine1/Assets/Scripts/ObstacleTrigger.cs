using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleTrigger : MonoBehaviour
{
    public GameObject effect_con;
    public GameObject effect_obj;
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            effect_obj = Instantiate(effect_con);
            effect_obj.transform.SetParent(gameObject.transform);
            effect_obj.transform.position = gameObject.transform.position;
            effect_obj.transform.parent = null;
            GameManager.GetInstance().PlusNowCube();
            CubesforAuto.instance.cubes.RemoveAt(0);
            SoundManager.instance.PlayClap();
            Destroy(gameObject);
        }
    }
}
