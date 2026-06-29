using Unity.VisualScripting;
using UnityEngine;

public class TriggerManager : MonoBehaviour
{
    public static TriggerManager instance;
    public TrigerSettings[] settings = new TrigerSettings[] { };
    public player sd;
    

    private void Awake()
    {
        instance = this;
        foreach (TrigerSettings sd in settings)
        {
            sd.gameObject.SetActive(false);
        }
        settings[0].gameObject.SetActive(true);
    }
    public void ssd(int flag)
    {
        if(settings.Length >= flag)
        {
            settings[flag - 1].gameObject.SetActive(true);
            if(flag == 8)
            {
                sd.warp(new Vector3(519.77f + 12, 2f, 37.45f - 18f));
            }
            if (flag == 12) 
            {
                sd.warp(new Vector3(-65f + 12, 1.68568f, 33f - 18));
            }
            
        }
    }
    

}
