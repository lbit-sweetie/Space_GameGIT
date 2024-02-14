using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnForTutorial : MonoBehaviour
{
    [Header("Stats")]
    public GameObject prefAster;
    public Transform placesForSpawnAster;
    public GameObject asterAllMas;
    public GameObject prefPlat;
    public GameObject prefFriend;

    [Header("Panels")]
    public GameObject bladePlatform;
    public GameObject platPlatform;
    public GameObject asterPlatform;
    public GameObject friendPlatform;
    public GameObject fadeInPanel;

    public GameObject goGamePlatfrom;


    private WaitForSeconds wait;
    private bool asterBool = false;
    private bool platBool = false;
    private bool friendBool = false;
    private bool bladeBool = true;

    private void Start()
    {
        wait = new WaitForSeconds(5);
        PlayerPrefs.SetInt("tutorial", 1);

        StartCoroutine(Tutorial());

        fadeInPanel.GetComponent<Animator>().SetTrigger("In");
        Time.timeScale = 0f;
    }

    private IEnumerator Tutorial()
    {
        while (true)
        {
            if (bladeBool)
            {
                platBool = true;
                bladeBool = false;
                yield return wait;
            }

            if (platBool)
            {
                SpawnPlat();
                asterBool = true;
                platBool = false;
                yield return wait;
            }

            if (asterBool)
            {
                SpawnAster();
                friendBool = true;
                asterBool= false;
                yield return wait;
            }

            if (friendBool)
            {
                SpawnFriend();
                friendBool = false;
                bladeBool = false;
                yield return wait;
            }

            if(!friendBool && !platBool && !asterBool && !friendBool)
            {
                goGamePlatfrom.SetActive(true);
            }

            yield return null;
        }
    }

    private void SpawnAster()
    {
        var a = Instantiate(prefAster,
                    placesForSpawnAster.transform.position,
                    Quaternion.identity);
        a.transform.SetParent(asterAllMas.transform);
        friendBool = true;
        asterPlatform.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("GameS");
    }

    private void SpawnPlat()
    {
        var a = Instantiate(prefPlat,
                    placesForSpawnAster.transform.position,
                    Quaternion.identity);
        a.transform.SetParent(asterAllMas.transform);
        asterBool = true;
        platPlatform.SetActive(true);
        Time.timeScale = 0f;
    }

    private void SpawnFriend()
    {
        var a = Instantiate(prefFriend,
                    placesForSpawnAster.transform.position,
                    new Quaternion(0, 0, 180, 0));
        a.transform.SetParent(asterAllMas.transform);
        friendBool = true;
        friendPlatform.SetActive(true);
        Time.timeScale = 0f;
    }
}