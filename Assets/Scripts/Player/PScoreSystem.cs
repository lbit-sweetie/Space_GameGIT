using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PScoreSystem : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] private GameObject parent;
    [SerializeField] private GameObject addScoreText;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private GameObject placeForSpawnText;

    [Header("Stats")]
    [SerializeField] private int _score = 0;
    [SerializeField] private int amoutForUsual;
    [SerializeField] private int amoutForNormal;
    [SerializeField] private int amoutForHrad;
    [SerializeField] private int amoutForShildBrake;
    private float textSpeed = 50;

    private int multiplier = 1;

    private void Start()
    {
        if (PlayerPrefs.HasKey("multiplier"))
        {
            multiplier = PlayerPrefs.GetInt("multiplier");
        }
        else
        {
            multiplier = 1;
        }
        //Debug.Log(multiplier);
    }

    public void AddScore(string type)
    {
        switch (type.ToLower())
        {
            case "usual":
                _score += amoutForUsual * multiplier;
                AddedScoreText(amoutForUsual * multiplier);
                break;
            case "normal":
                _score += amoutForNormal * multiplier;
                AddedScoreText(amoutForNormal * multiplier);
                break;
            case "hard":
                _score += amoutForHrad * multiplier;
                AddedScoreText(amoutForHrad * multiplier);
                break;
            default:
                _score += 10;
                break;
        }
        scoreText.text = _score.ToString();
    }

    private void AddedScoreText(int amount)
    {
        GameObject textPref = Instantiate(addScoreText, placeForSpawnText.transform.position, Quaternion.identity);
        textPref.transform.SetParent(parent.transform);
        textPref.GetComponent<TextMeshProUGUI>().text = "+" + amount.ToString();
        textPref.GetComponent<Rigidbody2D>().velocity = placeForSpawnText.transform.up * textSpeed;
        Destroy(textPref, 1f);
    }

    public int GetScore()
    {
        return _score;
    }
}