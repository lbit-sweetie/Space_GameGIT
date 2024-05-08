using UnityEngine;

public class DfDdfuyvdfyvydfyvdgfgvDDD : MonoBehaviour
{
    public float ksvdfvbdbhfv = 1;
    public float skhvbhkjdkvjbdfv = 1;
    private float ksjdvjhksdjvhsd = 1;


    void Start()
    {
        kdfbvkjhdfjkhbvjdfkbjhv();
        GetComponent<Rigidbody2D>().gravityScale = ksvdfvbdbhfv * 0.01f;
        GetComponent<Rigidbody2D>().velocity = -transform.up * ksvdfvbdbhfv / 2;
    }

    private void kdfbvkjhdfjkhbvjdfkbjhv()
    {
        if (PlayerPrefs.HasKey("multiplierSpeedObstacles"))
        {
            ksjdvjhksdjvhsd = PlayerPrefs.GetInt("multiplierSpeedObstacles") * 0.5f;
        }
        else
        {
            ksjdvjhksdjvhsd = 1;
        }
    }

    private void FixedUpdate()
    {
        transform.Rotate(0, 0, -skhvbhkjdkvjbdfv);
    }

    public void jkhsbvjkhdkhjvbdhkjfbv(float sbvbdbvdbfvjhfv)
    {
        ksvdfvbdbhfv = (ksvdfvbdbhfv + sbvbdbvdbfvjhfv) - ksjdvjhksdjvhsd;
        skhvbhkjdkvjbdfv += sbvbdbvdbfvjhfv / 2;
    }
}
