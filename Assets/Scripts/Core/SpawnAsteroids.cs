using System.Collections;
using System.Collections.Generic;
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
                    platSpawnLogic.GetComponent<SpawnPlat>().StartAnim("Wave "
                        + (platSpawnLogic.GetComponent<SpawnPlat>().wave + 1).ToString());
                    
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
                var a = Instantiate(_asteroids[UnityEngine.Random.Range(0, _asteroids.Length)],
                    placesForSpawnAster[
                        UnityEngine.Random.Range(0, placesForSpawnAster.Length)].transform.position,
                    Quaternion.identity);
                a.transform.SetParent(asterMas.transform);
                countOfPlatforms++;
                yield return waitForSeconds;
            }
        }
    }
}