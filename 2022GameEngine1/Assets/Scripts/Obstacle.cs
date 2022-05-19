using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public enum ObstacleKind
    {
        Left,
        Right,
        Jump,
        Down,
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
