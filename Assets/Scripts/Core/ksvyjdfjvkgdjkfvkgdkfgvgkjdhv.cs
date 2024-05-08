using UnityEngine;

public class ksvyjdfjvkgdjkfvkgdkfgvgkjdhv : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D jsdvjdvhjdhkjgfvkjhdfv)
    {
        if(jsdvjdvhjdhkjgfvkjhdfv != null)
        {
            if(jsdvjdvhjdhkjgfvkjhdfv.CompareTag("Asteroid") || jsdvjdvhjdhkjgfvkjhdfv.CompareTag("Platform") || 
                jsdvjdvhjdhkjgfvkjhdfv.CompareTag("Friend"))
            {
                Destroy(jsdvjdvhjdhkjgfvkjhdfv.gameObject);
            }
        }
    }
}