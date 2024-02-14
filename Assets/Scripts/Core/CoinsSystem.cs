using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoinsSystem : MonoBehaviour
{
    public int coins;
    public int startCost;
    public int amoutToAddCoins;
    public TMP_Text coinsText;
    public GameObject canvasNotEnought;

    [Header("MaxMana")]
    public TMP_Text costTextMaxMana;
    public TMP_Text levelTextMaxMana;
    [Header("Recovery time")]
    public TMP_Text costTextRecoveryTime;
    public TMP_Text levelTextRecoveryTime;
    [Header("Recovery time")]
    public TMP_Text costTextDamage;
    public TMP_Text levelTextDamage;
    [Header("Recovery time")]
    public TMP_Text costTextSpeedObstacle;
    public TMP_Text levelTextSpeedObstacle;


    public int WinGame(int score)
    {
        int g = 0;
        int a = Convert.ToInt32((float)score / 100);

        if (PlayerPrefs.HasKey("coins"))
        {
            g = PlayerPrefs.GetInt("coins") + a;
            PlayerPrefs.SetInt("coins", g);
        }
        else
        {
            PlayerPrefs.SetInt("coins", a);
        }

        PlayerPrefs.Save();

        return a;
    }

    private void Update()
    {
        //Отладка
        if (Input.GetKeyDown(KeyCode.B))
        {
            Debug.Log("b");
            PlayerPrefs.DeleteAll();
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            Debug.Log("h");
            PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") + 100);
        }
    }

    public void BuyUpgradeMaxMana()
    {
        if (BuyNewUpgrade(100, "multiplierMaxMana", "costMaxMana",
            100, "levelMaxMana", costTextMaxMana, levelTextMaxMana) == 0)
        {
            gameObject.GetComponent<MenuScr>().OpenNotEnought();
        }
    }

    public void BuyUpgradeRecoveryTime()
    {
        if (BuyNewUpgrade(2, "multiplierRecoveryTime", "costRecoveryTime",
            150, "levelRecoveryTime", costTextRecoveryTime, levelTextRecoveryTime) == 0)
        {
            gameObject.GetComponent<MenuScr>().OpenNotEnought();
        }
    }

    public void BuyUpgradeDamageBoost()
    {
        if (BuyNewUpgrade(50, "multiplierDamage", "costDamage",
            200, "levelDamage", costTextDamage, levelTextDamage) == 0)
        {
            gameObject.GetComponent<MenuScr>().OpenNotEnought();
        }
    }

    public void BuyUpgradeSpeedObstacle()
    {
        if (BuyNewUpgrade(2, "multiplierSpeedObstacles", "costSpeedObstacles",
            150, "levelSpeedObstacles", costTextSpeedObstacle, levelTextSpeedObstacle) == 0)
        {
            gameObject.GetComponent<MenuScr>().OpenNotEnought();
        }
    }
    public int BuyNewUpgrade(int amountToAddMultiplier, string typeMultiplier, 
        string costUpgrade, int startPriceForUpgrade,
        string levelUpgrade, TMP_Text textMenuCost, TMP_Text textNameLevel)
    {
        if (PlayerPrefs.HasKey("coins"))
        {
            if (!PlayerPrefs.HasKey(costUpgrade))
            {
                PlayerPrefs.SetInt(costUpgrade, startPriceForUpgrade);
            }
            if (PlayerPrefs.GetInt("coins") >= PlayerPrefs.GetInt(costUpgrade))
            {
                if (PlayerPrefs.HasKey(typeMultiplier))
                {
                    PlayerPrefs.SetInt(typeMultiplier, PlayerPrefs.GetInt(typeMultiplier) + 
                        amountToAddMultiplier);
                    PlayerPrefs.SetInt(levelUpgrade, PlayerPrefs.GetInt(levelUpgrade) + 1);
                    PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") - PlayerPrefs.GetInt(costUpgrade));
                    PlayerPrefs.SetInt(costUpgrade, PlayerPrefs.GetInt(costUpgrade) * 2);

                    PlayerPrefs.Save();
                }
                else
                {
                    PlayerPrefs.SetInt(typeMultiplier, amountToAddMultiplier);
                    PlayerPrefs.SetInt(levelUpgrade, 1);
                    PlayerPrefs.SetInt(costUpgrade, startPriceForUpgrade * 2);
                    PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") - startPriceForUpgrade);
                    PlayerPrefs.Save();
                }
                UpdateCost(costUpgrade, startPriceForUpgrade, levelUpgrade, textMenuCost, textNameLevel);
                return 1;
            }
            else
            {
                return 0;
            }
        }
        else
        {
            return 0;
        }
    }

    public void UpdateCost(string costUpgrade, int startPriceForUpgrade,
        string levelUpgrade, TMP_Text textMenu, TMP_Text textNameLevel)
    {
        if (PlayerPrefs.HasKey(costUpgrade))
        {
            textMenu.text = "price: " + PlayerPrefs.GetInt(costUpgrade).ToString();
        }
        else
        {
            textMenu.text = "price: " + startPriceForUpgrade.ToString();
        }
        UpdateCoins();
        UpdateLevel(levelUpgrade, textNameLevel);
    }

    public void UpdateCostMenu()
    {
        UpdateCost("costMaxMana", 100, "levelMaxMana", costTextMaxMana, levelTextMaxMana);
        UpdateCost("costRecoveryTime", 150, "levelRecoveryTime", 
            costTextRecoveryTime, levelTextRecoveryTime);
        UpdateCost("costDamage", 200, "levelDamage", costTextDamage, levelTextDamage);
        UpdateCost("costSpeedObstacles", 150, "levelSpeedObstacles", 
            costTextSpeedObstacle, levelTextSpeedObstacle);
    }

    public void UpdateCoins()
    {
        if (PlayerPrefs.HasKey("coins"))
        {
            coinsText.text = PlayerPrefs.GetInt("coins").ToString();
        }
        else
        {
            coinsText.text = "0";
        }
    }

    private void UpdateLevel(string levelUpgrade, TMP_Text textName)
    {
        if (PlayerPrefs.HasKey(levelUpgrade))
        {
            textName.text = "level: " + PlayerPrefs.GetInt(levelUpgrade).ToString();
        }
        else
        {
            textName.text = "level: 0";
        }
    }
}