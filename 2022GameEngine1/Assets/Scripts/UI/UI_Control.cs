using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UI_Control : MonoBehaviour
{
    public GameManager gManager;

    public Image MainImage;

    public Image Item_gauge;

    public Color gauageColor;
    public TMP_Text guard_count;
    
    // Start is called before the first frame update
    void Start()
    {
        gManager = GameManager.GetInstance();
        Item_gauge.fillAmount = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        MainImage.fillAmount = gManager.playerstates.health *0.2f;
        guard_count.text =gManager.playerstates.Guard.ToString();
        gauageColor = Color.white;
        Item_Gauge_fill();
    }

    public void Item_Gauge_fill() // 아이템 게이지 차오르는 시스템
    {
        if (gManager.Item_Event) //이벤트가 발동되는 동안 색이 랜덤으로 변하면서 줄어듦 -> 해당 기간동안만 아이템 발동 
        {
            gauageColor = new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f));
            
            Item_gauge.fillAmount -= Time.deltaTime * gManager.Item_time;
            if (Item_gauge.fillAmount <= 0)
            {
                gManager.Item_Event = false;
                gauageColor = Color.white;
            }
        }
        else // 그외의 시간에는 계속 참
        {
            Item_gauge.fillAmount += Time.deltaTime * 0.1f;
            
        }
        
        if (Item_gauge.fillAmount >= 1) // 가득 찼을 때 아이템활성화를 시키기 위한 코드
        {
            gManager.Item_Event = true;
        }
        Item_gauge.color = gauageColor;
    }
}
