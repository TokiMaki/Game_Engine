using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Road : MonoBehaviour
{
    public int _Num;            // 몇번째 길인지
    public Quaternion Rotation; // 돌아갔는지
    public float _Roadlength;
    public GameObject Pref;
    public List<Obstacle> _Obstacles;

    public void init(int num, float length, int minInterval, int maxInterval)     // 길 길이, 최소 간격, 최대 간격
    {
        _Num = num;
        _Roadlength = length;
        int depth = 0;
        while (depth < length)
        {
            Obstacle obstacle = new Obstacle(depth);
            _Obstacles.Add(obstacle);
            depth += Random.Range(minInterval, maxInterval);
        }
    }
}
