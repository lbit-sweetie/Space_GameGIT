using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwardsSystem : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] private GameObject shield1Award;
    [SerializeField] private GameObject shield2Award;

    [SerializeField] private GameObject shield1;
    [SerializeField] private GameObject shield2;


    public string GetAward(Vector2 platPos)
    {
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
            return null;
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

    public void GetTypeAward(string name)
    {
        switch (name.ToLower())
        {
            case "shield1_award(clone)":
                shield1.SetActive(true);
                break;
            case "shield2_award(clone)":
                shield2.SetActive(true);
                break;
        }
    }
}
