using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject enemytest;
    public static GameManager Instance;
    public int combo = 0;
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            enemytest.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            button1.SetActive(true);
            button2.SetActive(true);
            button3.SetActive(true);
            GameManager.Instance.combo = 0;
        }
    }
}
