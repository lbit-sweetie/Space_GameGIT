using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialCheck : MonoBehaviour
{
    public void StartGame()
    {
        if (PlayerPrefs.HasKey("tutorial"))
        {
            SceneManager.LoadScene("GameS");
        }
        else
        {
            SceneManager.LoadScene("tutorial");
        }
    }
}