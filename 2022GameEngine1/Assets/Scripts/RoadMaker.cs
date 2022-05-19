using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadMaker : MonoBehaviour
{
    public float _MinRoadlength = 20;
    public float _MaxRoadlength = 30;
    public int _MinObstacleInterval = 3;
    public int _MaxObstacleInterval = 6;
    public List<Road> _Roads;

    public List<GameObject> ObstaclePrefs;
    public GameObject RoadPref;
    
    // Start is called before the first frame update
    void Awake()
    {
        init(100);
        Install();
        print("이상무");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void init(int num)
    {
        for (int i = 0; i < num; ++i)
        {
            Road road = new Road();
            float length = Random.Range(_MinRoadlength, _MaxRoadlength);
            road.init(i, length, _MinObstacleInterval, _MaxObstacleInterval);
            _Roads.Add(road);
        }
    }
    
    public void Install()
    {
        Road road = _Roads[0];
        
        GameObject roadObject = Instantiate(RoadPref);
        roadObject.transform.localScale = new Vector3(roadObject.transform.localScale.x, roadObject.transform.localScale.y, road._Roadlength);
        
        foreach (var obstacle in road._Obstacles)
        {
            GameObject ObstacleObject = Instantiate(ObstaclePrefs[(int) obstacle._ObstacleKind]);
            Vector3 Prefsposition = ObstaclePrefs[(int) obstacle._ObstacleKind].transform.position;
            Prefsposition.z = obstacle._Depth;
            ObstacleObject.transform.position = Prefsposition;
            ObstacleObject.transform.SetParent(roadObject.transform);
        }
    }
    
}
