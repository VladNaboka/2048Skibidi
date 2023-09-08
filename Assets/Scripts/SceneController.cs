using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void StartGame()
    {
        SoundManager.instance.Play("Click");
        PlayerPrefs.SetInt("scoreReward", 0);
        SceneManager.LoadScene("2048");
    }
}
