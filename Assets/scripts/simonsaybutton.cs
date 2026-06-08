using UnityEngine;

public class simonsaybutton : MonoBehaviour
{
    public int id;
    public GameObject simonsaysGo;
   

    void Update()
    {
    }


    public void simonSays()
    {
        if (id == 1 && GameManager.Instance.combo == 0)
        {
            GameManager.Instance.combo = 1;
        }
        else
        {
            if (id == 2 && GameManager.Instance.combo == 1)
            {
                GameManager.Instance.combo = 2;
            }
            else
            {
                if (id == 3 && GameManager.Instance.combo == 2)
                {
                    GameManager.Instance.combo = 3;
                    if (GameManager.Instance.combo == 3)
                    {
                        simonsaysGo.SetActive(false);
                        

                    }
                }
                else
                {
                    GameManager.Instance.combo = 0;
                }
            }

        }
    }

}
