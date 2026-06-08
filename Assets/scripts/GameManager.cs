using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public enum GameState
{
    Menu,
    Playing,
    puzzle,
    Paused,
    GameOver,
    book
}

public class GameManager : MonoBehaviour
{
    public GameObject enemytest;
    public static GameManager Instance;
    public int combo = 0;
    public GameObject simonSay;
  
    public GameState currentState = GameState.Playing;
    public GameObject book;
    public GameObject keypuzzel;
    public GameObject mirrorPuzzle;
    public GameObject collerConectPuzzle;
    public GameObject maincamera;
    public GameObject puzzleCamera;
  

    public List<GameObject> wobbs = new List<GameObject>();
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
                maincamera.SetActive(true);
                puzzleCamera.SetActive(false);
                book.SetActive(false);
                break;
            case GameState.Playing:
                Time.timeScale = 1;
                maincamera.SetActive(true);
                puzzleCamera.SetActive(false);
                book.SetActive(false);
                break;
            case GameState.Paused:
                Time.timeScale = 0;
                maincamera.SetActive(true);
                puzzleCamera.SetActive(false);
                book.SetActive(false);
                break;
            case GameState.GameOver:
                Time.timeScale = 0;
                maincamera.SetActive(true);
                puzzleCamera.SetActive(false);
                book.SetActive(false);
                break;
            case GameState.book:
                maincamera.SetActive(true);
                puzzleCamera.SetActive(false);
                book.SetActive(true);
                Time.timeScale = 0;
                break;
            case GameState.puzzle:
                Time.timeScale = 1;
                maincamera.SetActive(false);
                puzzleCamera.SetActive(true);
                book.SetActive(false);
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
            simonsays();
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
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {

            KeyDilePuzzle();
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {

            mirrorPuzzle.SetActive(true);
            MirrorPuzzle();

        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            collerConectPuzzle.SetActive(true);
        }
    }
    public void simonsays()
    {
        simonSay.SetActive(true);
        combo = 0;
       
    }
    public void KeyDilePuzzle()
    {
        keypuzzel.SetActive(true);
        currentState = GameState.puzzle;
        SetState(GameState.puzzle);
    }
    public void MirrorPuzzle()
    {
        foreach (Transform child in mirrorPuzzle.transform)
        {
            child.gameObject.SetActive(true);
        }
        
    }
    public void collerConectPuzzleFn()
    {
        foreach (Transform child in collerConectPuzzle.transform)
        {
            child.gameObject.SetActive(true);
        }
        currentState = GameState.puzzle;
        SetState(GameState.puzzle);
    }
   public void puzzlecompleted()
    {
        currentState = GameState.Playing;
        SetState(GameState.Playing);
    }
}
