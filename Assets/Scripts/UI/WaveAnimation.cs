using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaveAnimation : MonoBehaviour
{
    [SerializeField] private GameObject waveCanvas;
    [SerializeField] private TMP_Text waveText;
    private float stepForAlpha;
    private float timeForUpdateAlpha;

    public IEnumerator Animation()
    {
        waveText.color = new Color(waveText.color.r, waveText.color.g, waveText.color.b, 1f);
        waveCanvas.SetActive(true);
        float alpha = 1f;
        while (waveText.color.a >= 0)
        {
            alpha -= stepForAlpha;
            waveText.color = new Color(waveText.color.r, waveText.color.g, waveText.color.b, alpha);

            if(waveText.color.a <= 0)
            {
                waveCanvas.SetActive(false);
            }

            yield return new WaitForSeconds(timeForUpdateAlpha);
        }
        yield return null;
    }
}
