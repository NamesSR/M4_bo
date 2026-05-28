using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public enum GameState
{
    Menu,
    Playing,
    Paused,
    GameOver,
    book
}

public class GameManager : MonoBehaviour
{
    public GameObject enemytest;
    public static GameManager Instance;
    public int combo = 0;
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public GameState currentState = GameState.Playing;
    public GameObject book;
    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        SetState(GameState.Playing);
    }
    public void SetState(GameState newState)
    {
        currentState = newState;

        switch (newState)
        {
            case GameState.Menu:
                Time.timeScale = 1;
                book.SetActive(false);
                break;
            case GameState.Playing:
                Time.timeScale = 1;
                book.SetActive(false);
                break;
            case GameState.Paused:
                Time.timeScale = 0;
                book.SetActive(false);
                break;
            case GameState.GameOver:
                Time.timeScale = 0;
                book.SetActive(false);
                break;
            case GameState.book:
                book.SetActive(true);
                Time.timeScale = 0;

                break;
        }


    }
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
            combo = 0;
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (currentState == GameState.Playing)
            {
                currentState = GameState.book;
                SetState(GameState.book);
            }
            else if (currentState == GameState.book)
            {
                currentState = GameState.Playing;
                SetState(GameState.Playing);
            }

        }
    }
    public void simonsays()
    {
        button1.SetActive(true);
        button2.SetActive(true);
        button3.SetActive(true);
        combo = 0;
    }
}
