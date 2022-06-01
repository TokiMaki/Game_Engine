using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle
{
    public enum ObstacleKind
    {
        Cube1,
        Cube2,
        Cube3,
        Cube4,
        Count
    }
    
    public Obstacle(float t)
    {
        init(t);
    }

    public ObstacleKind _ObstacleKind;
    public int _Depth;
    public float time;
    
    private void init(float t)
    {
        _ObstacleKind = (ObstacleKind) Random.Range(0, (int) ObstacleKind.Count);
        time= t;
    }
}
