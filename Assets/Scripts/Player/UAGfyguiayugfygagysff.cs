using UnityEngine;

public class UAGfyguiayugfygagysff : MonoBehaviour
{
    public float sdivtsuyidvtiysdtivsdv;

    private void Start()
    {
        IRVIUdsviusdiuviusdv();
    }

    private void IRVIUdsviusdiuviusdv()
    {
        if (PlayerPrefs.HasKey("multiplierDamage"))
        {
            sdivtsuyidvtiysdtivsdv += PlayerPrefs.GetInt("multiplierDamage");
        }
    }

    private void OnTriggerEnter2D(Collider2D sudyvtsuidviusduvsdv)
    {
        switch (sudyvtsuidviusduvsdv.tag)
        {
            case "Asteroid":
                suiyvyuisdvyuistdyutviusdv(sudyvtsuidviusduvsdv);
                break;
            case "Award":
                Destroy(sudyvtsuidviusduvsdv.gameObject);
                break;
        }
    }

    private void suiyvyuisdvyuistdyutviusdv(Collider2D siodiousdioufoisdif)
    {
        siodiousdioufoisdif.GetComponent<AsterHealth>().TakeDamage();
    }
}