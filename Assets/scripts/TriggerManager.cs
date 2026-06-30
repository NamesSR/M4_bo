using Unity.VisualScripting;
using UnityEngine;

public class TriggerManager : MonoBehaviour
{
    public static TriggerManager instance;
    public TrigerSettings[] settings = new TrigerSettings[] { };
    public player sd;
    public Transform house;
    public GameObject end;
    private void Awake()
    {
        instance = this;
        foreach (TrigerSettings sd in settings)
        {
            sd.gameObject.SetActive(false);
        }
        settings[0].gameObject.SetActive(true);
        end.SetActive(false);
    }

    public void ssd(int flag)
    {
        if(flag == 24)
        {
            end.SetActive(true);
        }
        if(settings.Length >= flag)
        {
            foreach (TrigerSettings sd in settings)
            {
                sd.gameObject.SetActive(false);
            }
            settings[flag - 1].gameObject.SetActive(true);
            if (flag == 8)
            {
                sd.warp(new Vector3(519.77f + 12, 2f, 37.45f - 18f));
               
            }
            if (flag == 12) 
            {
                Vector3 gh2 = settings[flag - 1].transform.position;
                gh2.y = 2;
                sd.warp(gh2);
            }
            if(flag == 15)
            {
                Vector3 sd3 = house.position;
                sd.warp(sd3);
            }
            if(flag == 21)
            {
                Vector3 sd32 = settings[13].transform.position;
                sd.warp(sd32);
            }
            if (flag == 23)
            {
                Vector3 sd33 = house.position;
                sd.warp(sd33);
            }

        }
    }
    public Vector3 respawntarget(int flag)
    {
       Vector3 fg = settings[flag - 2].transform.position;
       
        fg.y = 2;

        return fg;
    }

}
