using UnityEngine;

public class keypuzzel : MonoBehaviour
{
    public SphereCollider sc1;
    public SphereCollider sc2;
    public SphereCollider sc3;
    public int currentdilel = 1;
    public static keypuzzel instance;
    public bool dile1 = false;
    public bool dile2 = false;
    public bool dile3 = false;
    public bool puzzlecomplyt = false;

    private void Awake()
    {
        instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentdileUpdate();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (currentdilel < 3)
            {
                currentdilel++;
                currentdileUpdate();

            }
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (currentdilel > 1)
            {
                currentdilel--;
                currentdileUpdate();
            }
            
        }
        if (dile1 && dile2 && dile3)
        {

            puzzlecomplyt = true;
            gameObject.SetActive(false);
        }
    }
    void currentdileUpdate()
    {
        Debug.Log("currentdilel" + currentdilel);
        sc3.enabled = false;
        sc2.enabled = false;
        sc1.enabled = false;

        switch (currentdilel)
        {
            case 1:
                sc1.enabled = true;
                sc2.enabled = false;
                sc3.enabled = false;

                //evc1.enabled = true;
                //evc2.enabled = false;
                //evc3.enabled = false;
                break;
            case 2:
                sc1.enabled = false;
                sc2.enabled = true;
                sc3.enabled = false;

                //evc1.enabled = false;
                //evc2.enabled = true;
                //evc3.enabled = false;
                break;
            case 3:
                sc1.enabled = false;
                sc2.enabled = false;
                sc3.enabled = true;

                //evc1.enabled = false;
                //evc2.enabled = false;
                //evc3.enabled = true;
                break;
        }
    }
}
