using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpawnPlat : MonoBehaviour
{
    [Header("WaveLogic")]
    [SerializeField] private GameObject waveCanvas;
    [SerializeField] private TMP_Text waveText;
    [SerializeField] private float stepForAlpha;
    [SerializeField] private float timeForUpdateAlpha;

    [Header("Stats")]
    [SerializeField] private GameObject platMas;
    [SerializeField] private GameObject[] _platforms;
    [SerializeField] private GameObject[] placesForSpawn;
    [SerializeField] private GameObject[] placesForFriends;
    [SerializeField] private float delayForSpawn;
    [SerializeField] private float delayBetweenWaves;

    private WaitForSeconds waitForSeconds;
    [Header("LogicForSpawn")]
    public int wave;
    public int countOfPlatforms;
    public int alreadySpawned;
    public int amoutAddCountPlat;
    public float amoutRemoveDelay;

    public GameObject asterLogic;
    public GameObject friend;

    private float currentSpeed;
    private float addedHealth = 0;

    private void Start()
    {
        waitForSeconds = new WaitForSeconds(delayForSpawn);
        StartCoroutine(Animation("1"));
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            if (!asterLogic.GetComponent<SpawnAsteroids>().isNeed)
            {
                if (countOfPlatforms >= alreadySpawned)
                {
                    if (platMas.transform.childCount <= 0)
                    {
                        if (delayForSpawn > 0.2f)
                        {
                            delayForSpawn -= amoutRemoveDelay;
                            waitForSeconds = new WaitForSeconds(delayForSpawn);
                        }
                        wave++;
                        countOfPlatforms = 0;
                        alreadySpawned += amoutAddCountPlat;

                        Harder();
                        asterLogic.GetComponent<SpawnAsteroids>().StartSpawn();
                        StartCoroutine(Animation("Asteroids"));
                        yield return null;

                    }
                    else
                    {
                        yield return null;
                    }
                    yield return new WaitForSeconds(delayBetweenWaves);
                }
                else
                {
                    if (UnityEngine.Random.Range(0, 15) == 6)
                    {
                        GameObject fr = Instantiate(friend,
                            placesForFriends[UnityEngine.Random.Range(0, 
                            placesForFriends.Length)].transform.position,
                            new Quaternion(0, 0, 180, 0));
                        fr.transform.SetParent(platMas.transform);
                        yield return waitForSeconds;
                    }

                    var a = Instantiate(_platforms[UnityEngine.Random.Range(0, _platforms.Length)],
                    placesForSpawn[UnityEngine.Random.Range(0, placesForSpawn.Length)].transform.position,
                    Quaternion.identity);
                    a.transform.SetParent(platMas.transform);
                    a.GetComponent<PlatMovement>().AddSpeed(currentSpeed);
                    a.GetComponent<PlatHealth>().AddHealth(addedHealth);

                    countOfPlatforms++;
                    yield return waitForSeconds;
                }
            }
            else
            {
                yield return null;
            }
        }
    }

    private void Harder()
    {
        if(addedHealth <= 1000f)
        {
            addedHealth += 50f;
        }
        if(currentSpeed <= 8f)
        {
            currentSpeed += 0.2f;
        }
    }

    public void StartAnim(string text)
    {
        StartCoroutine(Animation(text));
    }
    public IEnumerator Animation(string textForAnim)
    {
        waveText.text = textForAnim;
        waveText.color = new Color(waveText.color.r, waveText.color.g, waveText.color.b, 1f);
        waveCanvas.SetActive(true);
        float alpha = 1f;
        while (waveText.color.a >= 0)
        {
            alpha -= stepForAlpha;
            waveText.color = new Color(waveText.color.r, waveText.color.g, waveText.color.b, alpha);

            if (waveText.color.a <= 0)
            {
                waveCanvas.SetActive(false);
                StopCoroutine(Animation(textForAnim));
            }

            yield return new WaitForSeconds(timeForUpdateAlpha);
        }
        yield return null;
    }
}