using Unity.VisualScripting;
using UnityEngine;

public class TriggerManager : MonoBehaviour
{
    public static TriggerManager instance;
    public TrigerSettings[] settings = new TrigerSettings[] { };
    

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
        }
    }
    

}
