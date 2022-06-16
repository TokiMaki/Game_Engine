using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow_Dust_P : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Player;
    public GameManager gmanager;
    public ParticleSystem partics;
    private bool once;
    void Start()
    {
        gmanager = GameManager.GetInstance();
        partics = gameObject.GetComponent<ParticleSystem>();
        partics.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (gmanager.started == true && once == true)
        {
            partics.Play();
            once = false;
        }
        else
        {
            partics.Stop();
            once = true;
        }
        gameObject.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y-0.5f, Player.transform.position.z);
    }
}
