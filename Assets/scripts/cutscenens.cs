using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class cutscenens : MonoBehaviour
{
    public Texture[] sdr = new Texture[] { };
    public RawImage ri;
    
    public GameObject menuCam;
   
    public void cutcenea()
    {
        StartCoroutine(sdf2());
    }

    IEnumerator sdf2()
    {
        for (int j = 0; j < sdr.Length; j++)
        {
            ri.texture = sdr[j];

            yield return new WaitForSeconds(1.4f);
        }
        GameManager.Instance.startGame();
        gameObject.SetActive(false);
        menuCam.SetActive(false);
    }
}
