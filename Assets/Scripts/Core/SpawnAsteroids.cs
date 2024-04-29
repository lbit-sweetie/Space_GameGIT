using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnAsteroids : MonoBehaviour
{
    public bool isNeed = false;

    [Header("Asteroids")]
    [SerializeField] private GameObject asterMas;
    [SerializeField] private GameObject[] _asteroids;
    [SerializeField] private GameObject[] placesForSpawnAster;
    [SerializeField] private float delayForSpawnAster;

    [Header("LogicForSpawn")]
    public int countOfPlatforms;
    public int alreadySpawned;
    public int amoutAddCountPlat;
    public float amoutRemoveDelay;

    public GameObject platSpawnLogic;
    private float addedSpeed = 0;

    private void Start()
    {
        waitForSeconds = new WaitForSeconds(delayForSpawnAster);
    }

    private WaitForSeconds waitForSeconds;

    public void StartSpawn()
    {
        isNeed = true;
        StartCoroutine(SpawnAsteroidss());
    }

    private IEnumerator SpawnAsteroidss()
    {
        while (true)
        {
            if (countOfPlatforms >= alreadySpawned)
            {
                if (asterMas.transform.childCount <= 0)
                {
                    countOfPlatforms = 0;
                    alreadySpawned += amoutAddCountPlat;
                    isNeed = false;
                    platSpawnLogic.GetComponent<SpawnPlat>().StartAnim(""
                        + (platSpawnLogic.GetComponent<SpawnPlat>().wave + 1).ToString());
                    
                    Harder();

                    StopAllCoroutines();
                }
                else
                {
                    yield return null;
                }
                yield return new WaitForSeconds(1);
            }
            else
            {
                var a = Instantiate(_asteroids[0],
                    placesForSpawnAster[
                        UnityEngine.Random.Range(0, placesForSpawnAster.Length)].transform.position,
                    Quaternion.identity);
                a.transform.SetParent(asterMas.transform);
                a.GetComponent<AsterMove>().AddSpeed(addedSpeed);
                countOfPlatforms++;
                yield return waitForSeconds;
            }
        }
    }

    private void Harder()
    {
        if (delayForSpawnAster > 0.1f)
        {
            delayForSpawnAster -= amoutRemoveDelay;
            waitForSeconds = new WaitForSeconds(delayForSpawnAster);
        }

        if(addedSpeed <= 10f)
        {
            addedSpeed += 0.4f;
        }
    }
}