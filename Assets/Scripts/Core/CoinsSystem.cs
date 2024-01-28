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

    public TMP_Text costText;
    public TMP_Text coinsText;
    public TMP_Text levelText;

    public GameObject canvasNotEnought;

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
        if (Input.GetKeyDown(KeyCode.B))
        {
            //PlayerPrefs.SetInt("coins", 200);
            PlayerPrefs.DeleteAll();
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") + 50);
            //PlayerPrefs.DeleteAll();
        }
    }

    public void BuyUpgrade()
    {
        if(Things() == 0)
        {
            canvasNotEnought.SetActive(true);
        }
    }

    public int Things()
    {
        if (PlayerPrefs.HasKey("coins"))
        {
            if (!PlayerPrefs.HasKey("cost"))
            {
                PlayerPrefs.SetInt("cost", 100);
            }
            if (PlayerPrefs.GetInt("coins") >= PlayerPrefs.GetInt("cost"))
            {
                if (PlayerPrefs.HasKey("multiplier"))
                {
                    PlayerPrefs.SetInt("multiplier", PlayerPrefs.GetInt("multiplier") + 1);
                    PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("level") + 1);
                    PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") - PlayerPrefs.GetInt("cost"));
                    PlayerPrefs.SetInt("cost", PlayerPrefs.GetInt("cost") * 2);


                    PlayerPrefs.Save();
                }
                else
                {
                    PlayerPrefs.SetInt("multiplier", 2);
                    PlayerPrefs.SetInt("level", 1);
                    PlayerPrefs.SetInt("cost", 200);
                    PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") - 100);
                    PlayerPrefs.Save();
                }
                UpdateCost();
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

    public void UpdateCost()
    {
        if (PlayerPrefs.HasKey("cost"))
        {
            costText.text = "price: " + PlayerPrefs.GetInt("cost").ToString();
        }
        else
        {
            costText.text = "price: 100";
        }
        UpdateCoins();
        UpdateLevel();
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

    private void UpdateLevel()
    {
        if (PlayerPrefs.HasKey("level"))
        {
            levelText.text = "level: " + PlayerPrefs.GetInt("level").ToString();
        }
        else
        {
            levelText.text = "level: 0";
        }
    }
}

