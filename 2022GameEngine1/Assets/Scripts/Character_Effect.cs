using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Effect : MonoBehaviour
{
    //public List<GameObject> effect_obj;
    public GameObject originobjs ;
    public GameObject RealObj;
    public List<ParticleSystem> particles = new List<ParticleSystem>();
    public ParticleSystem active_particle;
    public bool once;
    

    public GameManager gmanager;
    // Start is called before the first frame update
    void Start()
    {
        gmanager = GameManager.GetInstance();
        RealObj = Instantiate(originobjs);
        //RealObj.transform.SetParent(gameObject.transform);
        RealObj.transform.position = gameObject.transform.position;
        active_particle = RealObj.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gmanager.started == true && once == true)
        {
            active_particle.Play();
            once = false;
        }
        else
        {
            active_particle.Stop();
            once = true;
        }
        RealObj.transform.position = gameObject.transform.position;
        print(RealObj.transform.position);
    }
}
