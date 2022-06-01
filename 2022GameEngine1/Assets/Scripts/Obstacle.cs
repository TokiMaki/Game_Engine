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
    
    public Obstacle(int depth)
    {
        init(depth);
    }

    public ObstacleKind _ObstacleKind;
    public int _Depth;
    
    public void init(int depth)
    {
        _ObstacleKind = (ObstacleKind) Random.Range(0, (int) ObstacleKind.Count);
        _Depth = depth;
    }
}
