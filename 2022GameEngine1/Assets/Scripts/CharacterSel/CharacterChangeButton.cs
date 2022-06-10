using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterChangeButton : MonoBehaviour
{
    public GameObject StageInfo;
    
    // true is left button
    // else right button
    public void OnClick(bool isLeft)
    {
        if(isLeft) StageInfo.GetComponent<StageSelect>().ArrayIndexMinus();
        else StageInfo.GetComponent<StageSelect>().ArrayIndexPlus();
        SoundManager.instance.PlayBtnClick();
    }
}
