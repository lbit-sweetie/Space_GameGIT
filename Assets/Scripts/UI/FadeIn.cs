using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeIn : MonoBehaviour
{
    public void PlayGame(string sceneName)
    {
        Time.timeScale = 1f;

        if (PlayerPrefs.HasKey("tutorial"))
        {
            SceneManager.LoadScene("GameS");
        }
        else
        {
            SceneManager.LoadScene("Tutorial");
        }
    }

    private void Start()
    {
        if (gameObject.tag == "FadeInGame")
        {
            gameObject.GetComponent<Animator>().SetTrigger("Out");
        }
    }

    public void BackToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuS");
    }
}