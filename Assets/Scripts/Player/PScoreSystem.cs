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
    [SerializeField] private int amoutForAsteroid;
    [SerializeField] private float textSpeed = 50;


    public void AddScore(string type)
    {
        switch (type.ToLower())
        {
            case "usual":
                _score += amoutForUsual;
                AddedScoreText(amoutForUsual);
                break;
            case "normal":
                _score += amoutForNormal;
                AddedScoreText(amoutForNormal);
                break;
            case "hard":
                _score += amoutForHrad;
                AddedScoreText(amoutForHrad);
                break;
            case "asteroid":
                _score += amoutForAsteroid;
                AddedScoreText(amoutForAsteroid);
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
        StartCoroutine(FadeOutAnim(textPref));
        Destroy(textPref, 1f);
    }

    private IEnumerator FadeOutAnim(GameObject text)
    {
        while (true)
        {
            try
            {
                text.GetComponent<TextMeshProUGUI>().color -= new Color(0f, 0f, 0f, 0.1f);
                if (text.GetComponent<TextMeshProUGUI>().color.a <= 0)
                {
                    StopCoroutine(FadeOutAnim(text));
                    Destroy(text);
                }
            }
            catch (MissingReferenceException)
            {
                StopCoroutine(FadeOutAnim(text));
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    public int GetScore()
    {
        return _score;
    }
}