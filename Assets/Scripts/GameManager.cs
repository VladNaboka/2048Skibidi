using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using YG;

public class GameManager : MonoBehaviour
{
    public TileBoard board;
    public CanvasGroup gameOver;
    public Text scoreText;
    public Text hiscoreText;

    public YandexAdGame yandexGame;

    private int score;

    private void Start()
    {
        NewGame();
    }

    public void RestartSound()
    {
        SoundManager.instance.Play("Click");
        SetScore(PlayerPrefs.GetInt("scoreReward"));
    }
    public void AdsButton()
    {
        //adLose.ShowAd();
        yandexGame.scoreManager = score;
        yandexGame.ExampleOpenRewardAd(1);
        SetScore(PlayerPrefs.GetInt("scoreReward"));
    }
    public void NewGame()
    {
        // reset score
        if (PlayerPrefs.GetInt("scoreReward") == 0)
            SetScore(0);
        else if (PlayerPrefs.GetInt("scoreReward") > 0)
            SetScore(PlayerPrefs.GetInt("scoreReward"));

        hiscoreText.text = LoadHiscore().ToString();

        // hide game over screen
        gameOver.alpha = 0f;
        gameOver.interactable = false;

        // update board state
        board.ClearBoard();
        board.CreateTile();
        board.CreateTile();
        board.enabled = true;
    }

    public void GameOver()
    {
        SoundManager.instance.Play("Lose");
        board.enabled = false;
        gameOver.interactable = true;
        StartCoroutine(Fade(gameOver, 1f, 1f));
        YandexGame.FullscreenShow();
    }
    public void Menu()
    {
        SoundManager.instance.Play("Click");
        board.enabled = false;
        gameOver.interactable = true;

        StartCoroutine(Fade(gameOver, 1f, 1f));
        SetScore(0);
        SceneManager.LoadScene("Menu");
    }
    private IEnumerator Fade(CanvasGroup canvasGroup, float to, float delay = 0f)
    {
        yield return new WaitForSeconds(delay);

        float elapsed = 0f;
        float duration = 0.5f;
        float from = canvasGroup.alpha;

        while (elapsed < duration)
        {
            canvasGroup.alpha = Mathf.Lerp(from, to, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        canvasGroup.alpha = to;
    }

    public void IncreaseScore(int points)
    {
        //SoundManager.instance.Play("Merge");
        SetScore(score + points);
    }

    private void SetScore(int score)
    {
        this.score = score;
        scoreText.text = score.ToString();

        SaveHiscore();
    }

    private void SaveHiscore()
    {
        int hiscore = LoadHiscore();

        if (score > hiscore) {
            PlayerPrefs.SetInt("hiscore", score);
        }
    }

    private int LoadHiscore()
    {
        return PlayerPrefs.GetInt("hiscore", 0);
    }

}
