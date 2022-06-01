using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelectStartButton : MonoBehaviour
{
    public void OnCLick()
    {
        SoundManager.instance.PlayBtnClick();
        SceneManager.LoadScene("Game");
    }
}
