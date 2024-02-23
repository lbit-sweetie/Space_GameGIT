using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PBlade : MonoBehaviour
{
    private Camera _mainCamera;
    private CircleCollider2D bladeColider;
    private TrailRenderer bladeTrail;
    private bool isSlising;

    public Vector3 direction { get; private set; }
    public float minSliceVel = 0.01f;

    public float maxMana;
    public float _mana;
    public float delayForMana;
    public float diferenceTimeMana;
    public ParticleSystem notEnought;

    private WaitForSeconds waitForSeconds;
    private WaitForSeconds waitForSecondsRevive;
    private Material materialBlade;

    private void Awake()
    {
        _mainCamera = Camera.main;
        bladeColider = GetComponent<CircleCollider2D>();
        bladeTrail = GetComponentInChildren<TrailRenderer>();
        waitForSeconds = new WaitForSeconds(delayForMana);
        waitForSecondsRevive = new WaitForSeconds(delayForMana * 1.5f);

        GetUpgrades();
    }

    private void GetUpgrades()
    {
        if (PlayerPrefs.HasKey("multiplierMaxMana"))
        {
            maxMana = PlayerPrefs.GetInt("multiplierMaxMana") + maxMana;
            _mana = maxMana;
        }
        else
        {
            _mana = maxMana;
        }

        if (PlayerPrefs.HasKey("multiplierRecoveryTime"))
        {
            float a = (float)(PlayerPrefs.GetInt("multiplierRecoveryTime")) / 1000f;
            delayForMana = delayForMana - a;
            waitForSecondsRevive = new WaitForSeconds(delayForMana * 1.5f);
        }
    }

    private void Start()
    {
        materialBlade = GetComponentInChildren<TrailRenderer>().material;
        materialBlade.EnableKeyword("_EMISSION");
        StartCoroutine(CountingMana());
    }

    private void OnEnable()
    {
        StopSlicing();
    }

    private void OnDisable()
    {
        StopSlicing();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartSlicing();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StopSlicing();
        }
        else if (isSlising)
        {
            ContinueSlicing();
        }
    }
    private void StopSlicing()
    {
        isSlising = false;
        bladeColider.enabled = false;
        bladeTrail.enabled = false;
    }

    private void StartSlicing()
    {
        Vector3 newPosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z = 0f;
        transform.position = newPosition;

        isSlising = true;
        bladeColider.enabled = true;
        bladeTrail.enabled = true;
        bladeTrail.Clear();
    }
    private void ContinueSlicing()
    {
        Vector3 newPosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z = 0f;

        direction = newPosition - transform.position;
        float velocity = direction.magnitude / Time.deltaTime;

        bladeColider.enabled = velocity >= minSliceVel;
        transform.position = newPosition;
    }

    private IEnumerator CountingMana()
    {
        while (true)
        {
            if (isSlising)
            {
                if (_mana > 0)
                {
                    _mana -= diferenceTimeMana;

                    float a = (_mana / maxMana);
                    materialBlade.SetColor("_EmissionColor", 
                        new Color(materialBlade.GetColor("_EmissionColor").r, 
                        a,
                        materialBlade.GetColor("_EmissionColor").b));
                    
                    
                    yield return waitForSeconds;
                }
                else
                {
                    StopSlicing();
                    notEnought.Play();
                    yield return new WaitForSeconds(0.5f);
                }
            }
            else
            {
                if (_mana < maxMana)
                {
                    _mana += diferenceTimeMana;
                    if(_mana > maxMana)
                        _mana = maxMana;
                    yield return waitForSecondsRevive;
                }
                yield return null;
            }
            yield return null;
        }
    }
}