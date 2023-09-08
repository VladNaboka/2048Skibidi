using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoresController : MonoBehaviour
{
    public Text textHiscore;

    private int nullText = 0;
    private void Start()
    {
        textHiscore.text = PlayerPrefs.GetInt("hiscore").ToString();
        if (PlayerPrefs.GetInt("hiscore") == 0)
            textHiscore.text = nullText.ToString();
    }
}
