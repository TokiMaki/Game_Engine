using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_Control : MonoBehaviour
{
    public GameManager gManager;

    public Image MainImage;
    // Start is called before the first frame update
    void Start()
    {
        gManager = GameManager.GetInstance();
    }

    // Update is called once per frame
    void Update()
    {
        MainImage.fillAmount = gManager.playerstates.health *0.2f;
    }
}
