using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
public class EffectControl : MonoBehaviour
{
    public List<ParticleSystem> particles;

    public List<VisualEffect> vfxs;
    // Start is called before the first frame update
    void Start()
    {
        play_effects();
    }

    // Update is called once per frame
    void Update()
    {
        if (particles[0].isPlaying == false)
        {
            Destroy(gameObject);
        }
    }

    public void play_effects()
    {
        if (particles.Count > 0)
        {
            for (int i = 0; i < particles.Count; ++i)
            {
                particles[i].Play();
            }
        }
        
        if (vfxs.Count > 0)
        {
            for (int i = 0; i < vfxs.Count; ++i)
            {
                vfxs[i].Play();
            }
        }
    }

    public void stop_effects()
    {
        if (particles.Count > 0)
        {
            for (int i = 0; i < particles.Count; ++i)
            {
                particles[i].Stop();
            }
        }
        
        if (vfxs.Count > 0)
        {
            for (int i = 0; i < vfxs.Count; ++i)
            {
                vfxs[i].Stop();
            }
        }
    }
}
