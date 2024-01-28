using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerGame : MonoBehaviour
{
    [SerializeField] private GameObject deathCanvas;
    public int sec = 0;
    public int min = 0;
    [SerializeField] TMP_Text _timerText;
    [SerializeField] int delta = 0;
    void Start()
    {
        StartCoroutine(TimerOfGame());
    }

    IEnumerator TimerOfGame()
    {
        while (true)
        {
            if (sec == 59)
            {
                min++;
                sec = -1;
            }
            sec += delta;

            _timerText.text = min.ToString("D2") + ":" + sec.ToString("D2");

            yield return new WaitForSeconds(1);
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MenuS");
    }

    public void PlayAgain()
    {
        deathCanvas.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("GameS");
    }

    public int[] GetTime()
    {
        StopCoroutine(TimerOfGame());
        return new int[] { min, sec };
    }
}
