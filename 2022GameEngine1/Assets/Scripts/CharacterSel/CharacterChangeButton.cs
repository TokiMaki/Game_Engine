using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterChangeButton : MonoBehaviour
{
    // true is left button
    // else right button
    public void OnClick(bool isLeft)
    {
        SoundManager.instance.PlayBtnClick();
    }
}
