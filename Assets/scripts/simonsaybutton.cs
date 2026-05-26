using UnityEngine;

public class simonsaybutton : MonoBehaviour
{
    public int id;
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            button1.SetActive(true);
            button2.SetActive(true);
            button3.SetActive(true);
        }
    }
    

    public void simonSays()
    {
        if(id == 1 && GameManager.Instance.combo == 0)
        {
            GameManager.Instance.combo = 1;
        }
        else
        {
            if(id == 2 && GameManager.Instance.combo == 1)
            {
                GameManager.Instance.combo = 2;
            }
            else
            {
                if (id == 3 && GameManager.Instance.combo == 2)
                {
                    GameManager.Instance.combo = 3;
                    if(GameManager.Instance.combo == 3)
                    {
                        button1.SetActive(false);
                        button2.SetActive(false);
                        button3.SetActive(false);
 
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
