using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SongImage : MonoBehaviour
{
    public Sprite[] Sprites;
    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    public void ChangeImage(int index)
    {
        _image.sprite = Sprites[index];
    }
}
