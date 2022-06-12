using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelect : MonoBehaviour
{
    [Serializable]
    public struct Stage
    {
        public string name;
        public string soundName;
        public int level;
        public int totalMeasure;
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

    public void ArrayIndexPlus()
    {
        arrayIndex++;
        if (arrayIndex > Stages.Length - 1) arrayIndex = 0;
    }
    public void ArrayIndexMinus()
    {
        arrayIndex--;
        if (arrayIndex < 0) arrayIndex = Stages.Length - 1;
    }
    
    public Stage GetStageInfo()
    {
        return Stages[arrayIndex];
    }
}
