using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultTitleButton : MonoBehaviour
{
    public void OnCLick()
    {
        Destroy(GameObject.Find("StageInfo"));
        Destroy(GameObject.Find("GameManager"));
        SoundManager.instance.PlayBtnClick();
        SoundManager.instance.PlayBGM("title");
        SceneManager.LoadScene("title");
    }
}
