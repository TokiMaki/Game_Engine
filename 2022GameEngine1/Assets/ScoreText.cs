using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreText : MonoBehaviour
{
    public TextMeshProUGUI _Scoretext;

    private void Start()
    {
        _Scoretext = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        _Scoretext.text = "" + GameManager.GetInstance().Score;
    }
}
