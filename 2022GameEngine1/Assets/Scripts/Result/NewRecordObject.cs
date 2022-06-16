using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NewRecordObject : MonoBehaviour
{
    public GameObject scoreText;

    public void SetText(int score)
    {
        string[] number = new string[4];

        number[3] = ConvertToText(score % 10);
        if (score >= 10) number[2] = ConvertToText(score / 10 % 10);
        if (score >= 100) number[1] = ConvertToText(score / 100 % 10);
        if (score >= 1000) number[0] = ConvertToText(score / 1000);

        var output = "";
        for (int i = 0; i < number.Length; ++i)
        {
            output += number[i];
        }
        scoreText.GetComponent<TMP_Text>().text = output;
    }

    private string ConvertToText(int num)
    {
        return "<sprite=" + num + ">";
    }
}
