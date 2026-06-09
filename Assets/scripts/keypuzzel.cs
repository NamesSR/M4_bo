using UnityEngine;

public class keypuzzel : MonoBehaviour
{
    public SphereCollider sc1;
    public SphereCollider sc2;
    public SphereCollider sc3;
    public keyDIle2 kd1;
    public keyDIle2 kd2;
    public keyDIle2 kd3;
    public int currentdilel = 1;
    public static keypuzzel instance;
    public bool dile1 = false;
    public bool dile2 = false;
    public bool dile3 = false;
    public bool puzzlecomplyt = false;

    private void Awake()
    {
        instance = this;
        puzzlecomplyt = false;
        dile1 = false;
        dile2 = false;
        dile3 = false;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentdileUpdate();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            if (currentdilel < 3)
            {
                currentdilel++;
                currentdileUpdate();

            }
        }
        if (Input.GetKeyDown(KeyCode.H))
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
            GameManager.Instance.puzzlecompleted();
        }
    }
    void currentdileUpdate()
    {
        Debug.Log("currentdilel" + currentdilel);
        sc3.enabled = false;
        sc2.enabled = false;
        sc1.enabled = false;


        kd1.active = false;
        kd2.active = false;
        kd3.active = false;

        switch (currentdilel)
        {
            case 1:
                sc1.enabled = true;
                sc2.enabled = false;
                sc3.enabled = false;

                kd1.active = true;
                kd2.active = false;
                kd3.active = false;
                break;
            case 2:
                sc1.enabled = false;
                sc2.enabled = true;
                sc3.enabled = false;

                kd1.active = false;
                kd2.active = true;
                kd3.active = false;
                break;
            case 3:
                sc1.enabled = false;
                sc2.enabled = false;
                sc3.enabled = true;

                kd1.active = false;
                kd2.active = false;
                kd3.active = true;
                break;
        }
    }
}
