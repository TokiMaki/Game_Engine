using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class EventManager : MonoBehaviour
{
    public Image image;

    void Start()
    {
        image = GetComponent<Image>();

        //InvokeRepeating("Fade", 0f, 3f);       
    }

    void Fade()
    {
        Color color = image.color;
        color.a = 255;
        image.color = color;

    }
}