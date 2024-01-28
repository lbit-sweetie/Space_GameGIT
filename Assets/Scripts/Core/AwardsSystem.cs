using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwardsSystem : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] private GameObject shield1Award;
    [SerializeField] private GameObject shield2Award;
    [SerializeField] private GameObject electroZubrAward;
    [SerializeField] private GameObject rocketLauncherAward;

    [SerializeField] private GameObject shield1;
    [SerializeField] private GameObject shield2;
    [SerializeField] private GameObject electroZubr;
    [SerializeField] private GameObject rocketLauncher;


    public string GetAward(Vector2 platPos, bool isdeath)
    {
        if (isdeath)
            return "";
        var a = Random.Range(1, 80);
        if (a < 30)
            return null;
        else if (a >= 30 && a <= 45)
        {
            if (Random.Range(0, 2) == 0)
            {
                Instantiate(shield1Award, platPos, Quaternion.identity);
                return "shield1";
            }
            else
            {
                Instantiate(shield2Award, platPos, Quaternion.identity);
                return "shield2";
            }
        }
        else
        {
            if(a > 45 && a < 70)
                return "";
            if (gameObject.GetComponent<PAttack>().GetWeaponName() == "zubr")
            {
                Instantiate(rocketLauncherAward, platPos, Quaternion.identity);
                return "rocketLauncher";
            }
            else
            {
                Instantiate(electroZubrAward, platPos, Quaternion.identity);
                return "electroZubr";
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Award"))
        {
            GetTypeAward(collision.gameObject.name);
            Destroy(collision.gameObject);
        }
    }

    private void GetTypeAward(string name)
    {
        switch (name.ToLower())
        {
            case "shield1_award(clone)":
                shield1.SetActive(true);
                break;
            case "shield2_award(clone)":
                shield2.SetActive(true);
                break;
            case "zubr_award(clone)":
                rocketLauncher.SetActive(false);
                electroZubr.SetActive(true);
                break;
            case "rocketlauncher_award(clone)":
                electroZubr.SetActive(false);
                rocketLauncher.SetActive(true);
                break;

            //case "shield1_award":
            //    shield1.SetActive(true);
            //    break;
            //case "shield2_award":
            //    shield2.SetActive(true);
            //    break;
            //case "zubr_award":
            //    rocketLauncher.SetActive(false);
            //    electroZubr.SetActive(true);
            //    break;
            //case "rocketlauncher_award":
            //    electroZubr.SetActive(false);
            //    rocketLauncher.SetActive(true);
            //    break;
        }
    }
}
