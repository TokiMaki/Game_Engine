using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RecordtoTitle : MonoBehaviour
{
    public void OnClick()
    {
        SoundManager.instance.PlayBtnClick();
        SceneManager.LoadScene("Title");
    }
}
