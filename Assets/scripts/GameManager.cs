using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject enemytest;
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
    }
}
