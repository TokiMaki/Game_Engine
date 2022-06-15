using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StageSelect : MonoBehaviour
{
    [Serializable]
    public struct Stage
    {
        public string name;
        public string soundName;
        public int level;
        public MeasureInfo[] timings;
    }

    [Serializable]
    public struct MeasureInfo
    {
        public float bpm;
        public int beat;
        public bool empty;
    }

    public static StageSelect instance;
    public Stage[] Stages;
    public int arrayIndex = 0;
    public GameObject songImage;
    public GameObject songName;
    public GameObject songLevel;

    public bool autoPlay;
    
    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(this);
            instance = this;
        }
        else
        {
            if(instance!=this)
                Destroy(gameObject);
        }
    }

    private void Start()
    {
        SetSongUI(arrayIndex);
    }

    public void ArrayIndexPlus()
    {
        arrayIndex++;
        if (arrayIndex > Stages.Length - 1) arrayIndex = 0;
        SetSongUI(arrayIndex);
    }
    public void ArrayIndexMinus()
    {
        arrayIndex--;
        if (arrayIndex < 0) arrayIndex = Stages.Length - 1;
        SetSongUI(arrayIndex);
    }

    private void SetSongUI(int index)
    {
        songImage.GetComponent<SongImage>().ChangeImage(index);
        songName.GetComponent<TMP_Text>().text = Stages[index].name;
        switch (Stages[index].level)
        {
            case 0:
                songLevel.GetComponent<TMP_Text>().text = "EASY";
                songLevel.GetComponent<TMP_Text>().color = Color.green;
                songLevel.GetComponent<TMP_Text>().fontStyle = FontStyles.Normal;
                break;
            case 1:
                songLevel.GetComponent<TMP_Text>().text = "NORMAL";
                songLevel.GetComponent<TMP_Text>().color = new Color(1, 0.5f, 0);
                songLevel.GetComponent<TMP_Text>().fontStyle = FontStyles.Normal;
                break;
            case 2:
                songLevel.GetComponent<TMP_Text>().text = "HARD";
                songLevel.GetComponent<TMP_Text>().color = Color.red;
                songLevel.GetComponent<TMP_Text>().fontStyle = FontStyles.Bold;
                break;
            case 3:
                songLevel.GetComponent<TMP_Text>().text = "DANGER";
                songLevel.GetComponent<TMP_Text>().color = Color.black;
                songLevel.GetComponent<TMP_Text>().fontStyle = FontStyles.Bold | FontStyles.Italic;
                break;
        }
    }

    public void ToggleAutoPlay(Toggle val)
    {
        autoPlay = val.isOn;
    }
    
    public Stage GetStageInfo()
    {
        return Stages[arrayIndex];
    }
}
