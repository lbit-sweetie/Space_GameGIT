using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PAttack : MonoBehaviour
{
    #region Stats
    [Header("Pref")]
    [SerializeField] private GameObject _bulletLaser;
    [SerializeField] private GameObject _bulletRocket;
    [SerializeField] private GameObject _firePoint1;
    [SerializeField] private GameObject _firePoint2;

    [Header("Stats")]
    private WaitForSeconds waitForSeconds;
    [SerializeField] private float delayForShoot;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float _damageGun;

    [Header("StatsWeapon")]
    [SerializeField] private int damageZubr;
    [SerializeField] private float delayForZubr;
    [SerializeField] private int damageRocket;
    [SerializeField] private float delayForRocket;
    #endregion

    private GameObject currentBullet;
    private string currentWeaponName;

    private AudioManager _audioManager;

    private void Awake()
    {
        _audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    void Start()
    {
        currentBullet = _bulletLaser; 
        waitForSeconds = new WaitForSeconds(delayForShoot);
        currentWeaponName = "zubr";


        StartCoroutine(AtackCoroutine());
    }

    private IEnumerator AtackCoroutine()
    {
        while (true)
        {
            Shoot(_firePoint1);
            Shoot(_firePoint2);
            yield return waitForSeconds;
        }
    }

    private void Shoot(GameObject firePoint)
    {
        GameObject bullet = Instantiate(currentBullet, firePoint.transform.position, firePoint.transform.rotation);
        bullet.GetComponent<BulletScr>()._damage = _damageGun;
        bullet.GetComponent<Rigidbody2D>().velocity = firePoint.transform.up * bulletSpeed;
    }

    public void ChangeDamage(float amout)
    {
        _damageGun += amout;
    }

    public void ChangeWeapon(string typeWeapon)
    {
        switch (typeWeapon.ToLower())
        {
            case "zubr":
                currentBullet = _bulletLaser;
                currentWeaponName = "zubr";
                _damageGun = damageZubr;
                delayForShoot = delayForZubr;
                waitForSeconds = new WaitForSeconds(delayForShoot);

                break;
            case "rocket":
                currentBullet = _bulletRocket;
                currentWeaponName = "rocket";
                _damageGun = damageRocket;
                delayForShoot = delayForRocket;
                waitForSeconds = new WaitForSeconds(delayForShoot);

                break;
        }
    }

    public string GetWeaponName()
    {
        return currentWeaponName;
    }
}