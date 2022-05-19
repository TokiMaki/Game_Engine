using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadMaker : MonoBehaviour
{
    public int _MinRoadlength = 20;
    public int _MaxRoadlength = 30;
    public int _MinObstacleInterval = 5;
    public int _MaxObstacleInterval = 10;
    public List<Road> _Roads = new List<Road>();

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
            int length = Random.Range(_MinRoadlength, _MaxRoadlength);
            Road road = new Road(i, length, _MinObstacleInterval, _MaxObstacleInterval);
            _Roads.Add(road);
        }
    }
    
    public void Install()
    {
        Road road = _Roads[0];

        for (int i = 0; i < road._Roadlength; ++i)
        {
            GameObject roadObject = Instantiate(RoadPref);
            roadObject.transform.position =
                new Vector3(roadObject.transform.position.x, roadObject.transform.position.y, i * 10);
        }


        foreach (var obstacle in road._Obstacles)
        {
            GameObject ObstacleObject = Instantiate(ObstaclePrefs[(int) obstacle._ObstacleKind]);
            Vector3 Prefsposition = ObstaclePrefs[(int) obstacle._ObstacleKind].transform.position;
            Prefsposition.z = obstacle._Depth;
            ObstacleObject.transform.position = Prefsposition;
        }
    }
    
}
