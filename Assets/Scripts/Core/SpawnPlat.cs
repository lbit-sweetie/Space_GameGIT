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



    private void Start()
    {
        waitForSeconds = new WaitForSeconds(delayForSpawn);
        StartCoroutine(Animation("Wave 1"));
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
                        if (delayForSpawn > 1f)
                        {
                            delayForSpawn -= amoutRemoveDelay;
                            waitForSeconds = new WaitForSeconds(delayForSpawn);
                        }
                        wave++;
                        countOfPlatforms = 0;
                        alreadySpawned += amoutAddCountPlat;

                        asterLogic.GetComponent<SpawnAsteroids>().StartSpawn();
                        StartCoroutine(Animation("Asteroids!"));
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
                    var a = Instantiate(_platforms[UnityEngine.Random.Range(0, _platforms.Length)],
                        placesForSpawn[UnityEngine.Random.Range(0, placesForSpawn.Length)].transform.position,
                        Quaternion.identity);
                    a.transform.SetParent(platMas.transform);
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