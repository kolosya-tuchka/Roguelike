﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Text BestScore;

    private void Start()
    {
        int score = PlayerPrefs.GetInt("BestScore");
        BestScore.text = "Best score: " + score.ToString(); 
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
