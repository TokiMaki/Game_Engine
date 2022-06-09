using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Road
{
    public int _Num;            // 몇번째 길인지
    public Quaternion Rotation; // 돌아갔는지
    public int _Roadlength;
    public GameObject Pref;
    public List<Obstacle> _Obstacles = new List<Obstacle>();

    public Road(int num, bool obstacleOn ,int length, int minInterval, int maxInterval, int beat)     // 길 길이, 최소 간격, 최대 간격
    {
        _Num = num;
        _Roadlength = length;
        int depth = 0;
        if (num == 0)
        {
            depth += 5;
        }

        if (obstacleOn)
        {
            switch (beat)
            {
                case 4:
                {
                    Obstacle obstacle = new Obstacle(1000 * num);
                    _Obstacles.Add(obstacle);
                    break;
                }
                case 8:
                {
                    Obstacle obstacle = new Obstacle(1000 * num);
                    _Obstacles.Add(obstacle);
                    obstacle = new Obstacle(1000 * num+500);
                    _Obstacles.Add(obstacle);
                    break;
                }
            }
        }
    }
}
