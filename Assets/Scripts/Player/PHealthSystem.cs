using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.XR;
using UnityEngine;

public class PHealthSystem : MonoBehaviour
{
    [Header("UI")]
    public GameObject deathCanvas;
    public TMP_Text scoreText;
    public TMP_Text timeText;
    public TMP_Text bestText;
    public TMP_Text coinsText;

    public float health;

    [SerializeField] public GameObject shiled1;
    [SerializeField] public GameObject shiled2;

    private AudioManager _audioM;

    private int currentScore;

    private void Start()
    {
        _audioM = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Death();
        }
    }

    private void Death()
    {

        if (shiled1.activeInHierarchy)
        {
            shiled1.SetActive(false);
            return;
        }
        if (shiled2.activeInHierarchy)
        {
            shiled2.SetActive(false);
            return;
        }

        SaveScore();
        Time.timeScale = 0;
        ChangeText();



        _audioM.StopMusic();
        _audioM.PlaySFX(_audioM.gameover);
        deathCanvas.SetActive(true);
    }

    private void ChangeText()
    {
        currentScore = gameObject.GetComponent<PScoreSystem>().GetScore();
        scoreText.text = "score: " + currentScore.ToString();
        int[] a = GameObject.FindGameObjectWithTag("Timer").GetComponent<TimerGame>().GetTime();
        timeText.text = a[0].ToString("D2") + ":" + a[1].ToString("D2");
        ShowScore();

        int coins = gameObject.GetComponent<CoinsSystem>().WinGame(currentScore);
        coinsText.text = "+" + coins.ToString() + " coins";

    }

    private void ShowScore()
    {
        if (PlayerPrefs.HasKey("score"))
        {
            bestText.text = "best:" + PlayerPrefs.GetInt("score").ToString();
        }
        else
        {
            bestText.text = "best: 0";
        }
    }

    private void SaveScore()
    {
        int score = GetComponent<PScoreSystem>().GetScore();
        if (PlayerPrefs.HasKey("score"))
        {
            int oldScore = PlayerPrefs.GetInt("score");
            if (oldScore < score)
            {
                PlayerPrefs.SetInt("score", score);
            }
        }
        else
        {
            PlayerPrefs.SetInt("score", score);
        }
    }
}
