using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleExitButton : MonoBehaviour
{
    public void OnCLick()
    {
        SoundManager.instance.PlayBtnClick();
        Application.Quit();
    }
}
