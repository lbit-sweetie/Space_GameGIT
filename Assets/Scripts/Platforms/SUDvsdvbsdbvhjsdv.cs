using UnityEngine;

public class SUDvsdvbsdbvhjsdv : MonoBehaviour
{
    public float jkhdfvkjhdfkjbvdbkjfhv;
    private float kdvdfkvdfvdfv = 0;
    private bool kjhdfbvkjhdfjhvbjdhbfkv = false;

    void Start()
    {
        dkjfhvbkhdfkvbdfbkhvd();

        GetComponent<Rigidbody2D>().gravityScale = jkhdfvkjhdfkjbvdbkjfhv * 0.01f;
        GetComponent<Rigidbody2D>().velocity = -transform.up * jkhdfvkjhdfkjbvdbkjfhv / 2;
    }

    private void dkjfhvbkhdfkvbdfbkhvd()
    {
        kjhdfbvkjhdfjhvbjdhbfkv = true;
        if (PlayerPrefs.HasKey("multiplierSpeedObstacles"))
        {
            kdvdfkvdfvdfv = PlayerPrefs.GetInt("multiplierSpeedObstacles") * 0.1f;
        }
        else
        {
            kdvdfkvdfvdfv = 1;
        }
    }

    public void sjvhdjfvdfjhvdfv(float kdfvbkjhdfvkjbdjfkhbv)
    {
        if (!kjhdfbvkjhdfjhvbjdhbfkv)
        {
            dkjfhvbkhdfkvbdfbkhvd();
        }
        jkhdfvkjhdfkjbvdbkjfhv = (jkhdfvkjhdfkjbvdbkjfhv + kdfvbkjhdfvkjbdjfkhbv) - kdvdfkvdfvdfv;
    }
}