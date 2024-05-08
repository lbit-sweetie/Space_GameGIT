using TMPro;
using UnityEngine;
using System;

public class vjfkjvkjdfkjv : MonoBehaviour
{
    public int sdvsdjv;
    public int dfkskdf;
    public int skfuvkdfuvuywe;
    public TMP_Text vkuvywuev;
    public GameObject wvybwfeyvbwre;

    public TMP_Text ormbopirmoibmrtb;
    public TMP_Text jvnekjvnekjrnvre;
    public TMP_Text vejnjkvnkjdfbv;
    public TMP_Text vkjdfbvkjdfbv;
    public TMP_Text skhbvskdhvbhsv;
    public TMP_Text vksbvkwblvw;
    public TMP_Text vkwvwve;
    public TMP_Text viyieyrbvierviherv;


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

    public void BuyUpgradeMaxMana()
    {
        if (vuviuysvisovsyv(100, "multiplierMaxMana", "costMaxMana",
            100, "levelMaxMana", ormbopirmoibmrtb, jvnekjvnekjrnvre) == 0)
        {
            gameObject.GetComponent<MenuScr>().sdkvjsklvkjbsblkv();
        }
    }

    public void BuyUpgradeRecoveryTime()
    {
        if (vuviuysvisovsyv(2, "multiplierRecoveryTime", "costRecoveryTime",
            150, "levelRecoveryTime", vejnjkvnkjdfbv, vkjdfbvkjdfbv) == 0)
        {
            gameObject.GetComponent<MenuScr>().sdkvjsklvkjbsblkv();
        }
    }

    public void BuyUpgradeSpeedObstacle()
    {
        if (vuviuysvisovsyv(2, "multiplierSpeedObstacles", "costSpeedObstacles",
            150, "levelSpeedObstacles", vkwvwve, viyieyrbvierviherv) == 0)
        {
            gameObject.GetComponent<MenuScr>().sdkvjsklvkjbsblkv();
        }
    }
    public void BuyUpgradeDamageBoost()
    {
        if (vuviuysvisovsyv(50, "multiplierDamage", "costDamage",
            200, "levelDamage", skhbvskdhvbhsv, vksbvkwblvw) == 0)
        {
            gameObject.GetComponent<MenuScr>().sdkvjsklvkjbsblkv();
        }
    }

    public int vuviuysvisovsyv(int amountToAddMultiplier, string typeMultiplier, 
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
                vjdfvjgdjgvjgdjgv(costUpgrade, startPriceForUpgrade, levelUpgrade, textMenuCost, textNameLevel);
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

    public void vdfjvjdfjkvdjkfvkj()
    {
        vjdfvjgdjgvjgdjgv("costMaxMana", 100, "levelMaxMana", ormbopirmoibmrtb, jvnekjvnekjrnvre);
        vjdfvjgdjgvjgdjgv("costRecoveryTime", 150, "levelRecoveryTime", 
            vejnjkvnkjdfbv, vkjdfbvkjdfbv);
        vjdfvjgdjgvjgdjgv("costDamage", 200, "levelDamage", skhbvskdhvbhsv, vksbvkwblvw);
        vjdfvjgdjgvjgdjgv("costSpeedObstacles", 150, "levelSpeedObstacles", 
            vkwvwve, viyieyrbvierviherv);
    }
    public void vjdfvjgdjgvjgdjgv(string costUpgrade, int startPriceForUpgrade,
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
        vjkhbvjrverv();
        vkfvbkdfbjhvdbkjhfv(levelUpgrade, textNameLevel);
    }


    private void vkfvbkdfbjhvdbkjhfv(string levelUpgrade, TMP_Text textName)
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
    public void vjkhbvjrverv()
    {
        if (PlayerPrefs.HasKey("coins"))
        {
            vkuvywuev.text = PlayerPrefs.GetInt("coins").ToString();
        }
        else
        {
            vkuvywuev.text = "0";
        }
    }

}