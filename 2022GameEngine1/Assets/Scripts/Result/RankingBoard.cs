using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Unity.VisualScripting;

public class RankingBoard : MonoBehaviour
{
    private int _record = 0;
    private static string _dataPath;

    public GameObject scoreText;
    public GameObject newRecordImage;

    // 점수 불러오기
    private void LoadRecord(string path)
    {
        FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read);
        StreamReader sr = new StreamReader(fs);
        try
        {
            _record = int.Parse(sr.ReadLine());
        }
        catch
        {
            
        }

        sr.Close();
        scoreText.GetComponent<ScoreObject>().SetText(_record);
    }

    // 점수 파일에 기록
    private void WriteRecord(string path, int score)
    {
        FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
        StreamWriter sw = new StreamWriter(fs);
        sw.Write(score);
        sw.Close();
    }

    private void Start()
    {
        _dataPath = Application.persistentDataPath + "/" + StageSelect.instance.GetStageInfo().soundName;
        LoadRecord(_dataPath);
        CompareScore(GameManager.GetInstance().Score);
    }

    // 불러온 점수 불러오기
    public int GetScore()
    {
        return _record;
    }

    public void CompareScore(int newScore)
    {
        scoreText.GetComponent<ScoreObject>().SetText(newScore);
        if (newScore > _record)
        {
            newRecordImage.GetComponent<NewRecordObject>().SetText(newScore - _record);
            newRecordImage.SetActive(true);
            _record = newScore;
            WriteRecord(_dataPath, newScore);
        }
    }
}
