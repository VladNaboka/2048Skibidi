using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class YandexAdGame : MonoBehaviour
{
    public int scoreManager;

    private void OnEnable() => YandexGame.RewardVideoEvent += Rewarded;

    private void OnDisable() => YandexGame.RewardVideoEvent -= Rewarded;

    void Rewarded(int id)
    {
        // Если ID = 1, то выдаём "+100 монет"
        if (id == 1)
            RestartOnReward(scoreManager);

        //// Если ID = 2, то выдаём "+оружие".
        //else if (id == 2)
        //    AddWeapon();
    }

    public void ExampleOpenRewardAd(int id)
    {
        YandexGame.RewVideoShow(id);
    }


    private void RestartOnReward(int Score)
    {
        PlayerPrefs.SetInt("scoreReward", Score);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
