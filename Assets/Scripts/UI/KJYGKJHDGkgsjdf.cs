using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KJYGKJHDGkgsjdf : MonoBehaviour
{
    public GameObject sodvosdvohsdv;
    public int skdvs = 0;
    public int hsdvsdv = 0;
    public int kjsdbvkjhsdjsd = 0;
    void Start()
    {
        StartCoroutine(isdgvysgdyvsydgvysdv());
    }

    IEnumerator isdgvysgdyvsydgvysdv()
    {
        while (true)
        {
            if (skdvs == 59)
            {
                hsdvsdv++;
                skdvs = -1;
            }
            skdvs += kjsdbvkjhsdjsd;


            yield return new WaitForSeconds(1);
        }
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuS");
    }

    public void PlayAgain()
    {
        sodvosdvohsdv.GetComponent<Animator>().SetTrigger("Normal");
        Time.timeScale = 1f;
        SceneManager.LoadScene("GameS");
    }

    public int[] GetTime()
    {
        StopCoroutine(isdgvysgdyvsydgvysdv());
        return new int[] { hsdvsdv, skdvs };
    }
}
