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

    public ObstacleKind _ObstacleKind;
    public float _Depth;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    void init(float depth)
    {
        _ObstacleKind = (ObstacleKind) Random.Range(0, (int) ObstacleKind.Count);
        _Depth = depth;
    }
}
