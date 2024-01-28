using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScr : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider volumeSlider;
    public void PlayGame()
    {
        SceneManager.LoadScene("GameS");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void SetMusicVolume()
    {
        float volume = volumeSlider.value;
        audioMixer.SetFloat("volume", Mathf.Log10(volume) * 20);
    }
}
