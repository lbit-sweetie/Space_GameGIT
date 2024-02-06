using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScr : MonoBehaviour
{
    public GameObject fadeIn;
    public GameObject notEnoughtAnim;
    public AudioMixer audioMixer;
    public Slider volumeSlider;
    public void PlayGame(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
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

    public void OpenNotEnought()
    {
        notEnoughtAnim.GetComponent<Animator>().SetTrigger("Open");
    }

    public void CloseNotEnought()
    {
        notEnoughtAnim.GetComponent<Animator>().SetTrigger("Close");
    }
}
