using System.Collections;
using UnityEngine;

public class sdkvbskdbvkskbvksdv : MonoBehaviour
{
    private Camera sjdhkjhdsvbjhsdv;
    private CircleCollider2D hsdvjhsdjvhkjdsv;
    private TrailRenderer usdygyusdviysdiyv;
    private bool isgvisdgivgsidgiv;

    public Vector3 sdigiwydsvdsv { get; private set; }
    public float sudyvfuiysdivuyfsdv = 0.01f;

    public float sdiovoisdvobsdv;
    public float sdvklhbsdkhvkhsdv;
    public float sduyvsdiuyvfisdyvsdv;
    public float wdacjsdkbjsv;
    public ParticleSystem jcjwjcvjewkjhvcwec;

    private WaitForSeconds ucwuecuweucwc;
    private WaitForSeconds eiytsiuyvuysdivys;
    private Material iusdgvyiasdiyvyisadgvi;

    private void Awake()
    {
        sjdhkjhdsvbjhsdv = Camera.main;
        hsdvjhsdjvhkjdsv = GetComponent<CircleCollider2D>();
        usdygyusdviysdiyv = GetComponentInChildren<TrailRenderer>();
        ucwuecuweucwc = new WaitForSeconds(sduyvsdiuyvfisdyvsdv);
        eiytsiuyvuysdivys = new WaitForSeconds(sduyvsdiuyvfisdyvsdv * 1.5f);

        vsdjvgjsdvhsdjhvkjhsdv();
    }

    private void vsdjvgjsdvhsdjhvkjhsdv()
    {
        if (PlayerPrefs.HasKey("multiplierMaxMana"))
        {
            sdiovoisdvobsdv = PlayerPrefs.GetInt("multiplierMaxMana") + sdiovoisdvobsdv;
            sdvklhbsdkhvkhsdv = sdiovoisdvobsdv;
        }
        else
        {
            sdvklhbsdkhvkhsdv = sdiovoisdvobsdv;
        }

        if (PlayerPrefs.HasKey("multiplierRecoveryTime"))
        {
            float sdvrsudrvutsrdvutsdv = (float)(PlayerPrefs.GetInt("multiplierRecoveryTime")) / 1000f;
            sduyvsdiuyvfisdyvsdv = sduyvsdiuyvfisdyvsdv - sdvrsudrvutsrdvutsdv;
            eiytsiuyvuysdivys = new WaitForSeconds(sduyvsdiuyvfisdyvsdv * 1.5f);
        }
    }

    private void Start()
    {
        iusdgvyiasdiyvyisadgvi = GetComponentInChildren<TrailRenderer>().material;
        iusdgvyiasdiyvyisadgvi.EnableKeyword("_EMISSION");
        StartCoroutine(sdyvsduviusduvsdv());
    }

    private void OnEnable()
    {
        SUYGIUYAsyugagsyf();
    }

    private void OnDisable()
    {
        SUYGIUYAsyugagsyf();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            suviysiuvsudviyusyudviuyUIYIU();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            SUYGIUYAsyugagsyf();
        }
        else if (isgvisdgivgsidgiv)
        {
            ContinueSlicing();
        }
    }
    private void SUYGIUYAsyugagsyf()
    {
        isgvisdgivgsidgiv = false;
        hsdvjhsdjvhkjdsv.enabled = false;
        usdygyusdviysdiyv.enabled = false;
    }

    private void suviysiuvsudviyusyudviuyUIYIU()
    {
        Vector3 sidyvtusydviyusitdvu = sjdhkjhdsvbjhsdv.ScreenToWorldPoint(Input.mousePosition);
        sidyvtusydviyusitdvu.z = 0f;
        transform.position = sidyvtusydviyusitdvu;

        isgvisdgivgsidgiv = true;
        hsdvjhsdjvhkjdsv.enabled = true;
        usdygyusdviysdiyv.enabled = true;
        usdygyusdviysdiyv.Clear();
    }
    private void ContinueSlicing()
    {
        Vector3 sytvruyvrusudytv = sjdhkjhdsvbjhsdv.ScreenToWorldPoint(Input.mousePosition);
        sytvruyvrusudytv.z = 0f;

        sdigiwydsvdsv = sytvruyvrusudytv - transform.position;
        float sdyutvrustydvrusduytv = sdigiwydsvdsv.magnitude / Time.deltaTime;

        hsdvjhsdjvhkjdsv.enabled = sdyutvrustydvrusduytv >= sudyvfuiysdivuyfsdv;
        transform.position = sytvruyvrusudytv;
    }

    private IEnumerator sdyvsduviusduvsdv()
    {
        while (true)
        {
            if (isgvisdgivgsidgiv)
            {
                if (sdvklhbsdkhvkhsdv > 0)
                {
                    sdvklhbsdkhvkhsdv -= wdacjsdkbjsv;

                    float suivuisdviusirudv = (sdvklhbsdkhvkhsdv / sdiovoisdvobsdv);
                    iusdgvyiasdiyvyisadgvi.SetColor("_EmissionColor", 
                        new Color(iusdgvyiasdiyvyisadgvi.GetColor("_EmissionColor").r, 
                        suivuisdviusirudv,
                        iusdgvyiasdiyvyisadgvi.GetColor("_EmissionColor").b));
                    
                    
                    yield return ucwuecuweucwc;
                }
                else
                {
                    SUYGIUYAsyugagsyf();
                    jcjwjcvjewkjhvcwec.Play();
                    yield return new WaitForSeconds(0.5f);
                }
            }
            else
            {
                if (sdvklhbsdkhvkhsdv < sdiovoisdvobsdv)
                {
                    sdvklhbsdkhvkhsdv += wdacjsdkbjsv;
                    if(sdvklhbsdkhvkhsdv > sdiovoisdvobsdv)
                        sdvklhbsdkhvkhsdv = sdiovoisdvobsdv;
                    yield return eiytsiuyvuysdivys;
                }
                yield return null;
            }
            yield return null;
        }
    }
}