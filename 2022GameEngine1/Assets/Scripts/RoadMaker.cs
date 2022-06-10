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
    
    private StageSelect _stageInfo = StageSelect.instance;

    private int _beat;
    private int _noteNum;
    private int _startNoteNum;
    
    // Start is called before the first frame update
    void Awake()
    {
        _beat = _stageInfo.Stages[_stageInfo.arrayIndex].beat;
        _noteNum= _stageInfo.Stages[_stageInfo.arrayIndex].noteNum;
        _startNoteNum= _stageInfo.Stages[_stageInfo.arrayIndex].startNoteNum;
        
        init(_noteNum+_startNoteNum);
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
            Road road;

            if (_startNoteNum > i)
                road = new Road(i, false, length, _MinObstacleInterval, _MaxObstacleInterval, _beat);
            else
                road = new Road(i, true, length, _MinObstacleInterval, _MaxObstacleInterval, _beat);
            _Roads.Add(road);
        }
    }
    
    public void Install()
    {
        for (int i = 0; i < _Roads.Count; ++i)
        {
            GameObject roadObject = Instantiate(RoadPref);
            roadObject.transform.position =
                new Vector3(roadObject.transform.position.x, roadObject.transform.position.y, i * 10);

            foreach (var obstacle in _Roads[i]._Obstacles)
            {
                GameObject ObstacleObject = Instantiate(ObstaclePrefs[(int) obstacle._ObstacleKind]);
                Vector3 Prefsposition = ObstaclePrefs[(int) obstacle._ObstacleKind].transform.position;
                Prefsposition.z = obstacle.time / 100;
                ObstacleObject.transform.position = Prefsposition;
            }
        }
        /*
        int totalRoadLength = 0;
        foreach (var road in _Roads)
        {
            for (int i = totalRoadLength; i < totalRoadLength + road._Roadlength; ++i)
            {
                GameObject roadObject = Instantiate(RoadPref);
                roadObject.transform.position =
                    new Vector3(roadObject.transform.position.x, roadObject.transform.position.y, i * 10);
            }


            foreach (var obstacle in road._Obstacles)
            {
                GameObject ObstacleObject = Instantiate(ObstaclePrefs[(int) obstacle._ObstacleKind]);
                Vector3 Prefsposition = ObstaclePrefs[(int) obstacle._ObstacleKind].transform.position;
                Prefsposition.z = totalRoadLength * 10f + obstacle._Depth;
                ObstacleObject.transform.position = Prefsposition;
            }
            totalRoadLength += road._Roadlength;
        }
        */
    }
    
}
