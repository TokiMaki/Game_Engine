using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class RankingBoard : MonoBehaviour
{
    [Serializable]
    private struct Record
    {
        private string _name;
        private float _time;

        public Record(string name, float time)
        {
            _name = name;
            _time = time;
        }

        public string GetName()
        {
            return _name;
        }
        
        public float GetTime()
        {
            return _time;
        }
    }

    private Record[] _sample = new Record[3];
    private List<Record> _list;
    private static string _dataPath;

    private void ImportRecord(string path)
    {
        _list.Clear();
        BinaryReader binaryReader = new BinaryReader(File.Open(path, FileMode.Open));
        while (true)
        {
            try
            {
                var temp = new Record(binaryReader.ReadString(), binaryReader.ReadSingle());
                _list.Add(temp);
            }
            catch (EndOfStreamException e)
            {
                binaryReader.Close();
                break;
            }
        }
    }

    private void WriteRecord(string path, Record data)
    {
        BinaryWriter binaryWriter = new BinaryWriter(File.Open(path, FileMode.Append));
        binaryWriter.Write(data.GetName());
        binaryWriter.Write(data.GetTime());
        binaryWriter.Close();
    }

    private void Start()
    {
        _list = new List<Record>();
        _dataPath = Application.persistentDataPath + "/RANK";

        ImportRecord(_dataPath);
    }
}
