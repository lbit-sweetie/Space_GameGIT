using UnityEngine;

public class sdvtiysdtviytsydviysdv : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D sugjhjqwvdjqvwjd)
    {
        if (sugjhjqwvdjqvwjd.CompareTag("Blade"))
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<UDGSIDVgsdgvisdgv>().svyuksduyvsudyvusydv(1);
            gameObject.tag = "Untagged";
            Destroy(gameObject);
        }
    }

    private void Awake()
    {
        Destroy(gameObject, 20f);
    }
}