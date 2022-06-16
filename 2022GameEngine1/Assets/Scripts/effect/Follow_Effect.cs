using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Follow_Effect : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Player;
    public GameManager gmanager;
    public VisualEffect vfxs;
    void Start()
    {
        gmanager = GameManager.GetInstance();
        vfxs = gameObject.GetComponent<VisualEffect>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gmanager.started == true)
        {
            vfxs.Play();
        }
        else
        {
            vfxs.Stop();
        }

        gameObject.transform.position = new Vector3(0, 0, Player.transform.position.z);
        //print(Player.transform.position.z);
    }
}
