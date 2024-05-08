using UnityEngine;

public class AsterHealth : MonoBehaviour
{
    public GameObject sdkvhbskhdvkhbsv;
    public bool kjskbvjkjdvkjhdfv;

    private void Awake()
    {
        Destroy(gameObject, 12f);
    }


    private void OnTriggerEnter2D(Collider2D jhdfvjjdhfvhjdfv)
    {
        if (jhdfvjjdhfvhjdfv.CompareTag("Player"))
        {
            kjskbvjkjdvkjhdfv = true;
            jhdfvjjdhfvhjdfv.gameObject.GetComponent<UDGSIDVgsdgvisdgv>().svyuksduyvsudyvusydv(1);
            gameObject.tag = "Untagged";
            Destroy(gameObject);
        }
    }
    public void TakeDamage()
    {
        Instantiate(sdkvhbskhdvkhbsv, transform.position, Quaternion.identity);

        var kjhfdvjhkdfvbdfhbkjv = GameObject.FindGameObjectWithTag("Player");
        kjhfdvjhkdfvbdfhbkjv.GetComponent<suoitsdiygdhjbwehjvwejf>().uvityitiuvtdufytvyuidf("asteroid");

        Destroy(gameObject);
    }
}