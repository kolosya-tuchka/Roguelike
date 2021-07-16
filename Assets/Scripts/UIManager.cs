using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public PlayerControls player;
    public Text hpText, killsText, totalScore;
    public GameObject game, pause, gameOver, record;
    bool isPause;

    private void Start()
    {
        OpenGame();
    }

    void Update()
    {
        hpText.text = player.hp.ToString();
        killsText.text = player.kills.ToString();
        if (player.hp <= 0)
        {
            Invoke("GameOver", 2);
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPause) OpenGame();
            else OpenPause();
        }
    }

    void OpenGame()
    {
        isPause = false;
        game.SetActive(true);
        pause.SetActive(false);
        gameOver.SetActive(false);
        Time.timeScale = 1;
    }

    void OpenPause()
    {
        isPause = true;
        game.SetActive(false);
        pause.SetActive(true);
        gameOver.SetActive(false);
        Time.timeScale = 0;
    }

    void GameOver()
    {
        isPause = false;
        game.SetActive(false);
        pause.SetActive(false);
        gameOver.SetActive(true);
        Time.timeScale = 0;
        totalScore.text = "Your score: " + player.kills.ToString();

        int score = PlayerPrefs.GetInt("BestScore");
        if (player.kills > score)
        {
            PlayerPrefs.SetInt("BestScore", player.kills);
            record.SetActive(true);
        }
        else record.SetActive(false);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }
}
