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
    book,
    cutscene
}

public class GameManager : MonoBehaviour
{
    public GameObject sadf;
    public cutscenens df;
    public GameObject tasklist;
    public GameObject enemytest;
    public static GameManager Instance;
    public int combo = 0;
    public GameObject simonSay;
    public GameObject mirror1;
    public GameObject mirror2;
    public GameState currentState = GameState.Playing;
    public GameObject book;
    public GameObject keypuzzel;
    public GameObject mirrorPuzzle;
    public GameObject collerConectPuzzle;
    public GameObject maincamera;
    public GameObject puzzleCamera;
    public int orbdestoryed = 0;
    public GameObject burnebleprefab;
    public bool debugMode = false;
    public bool first = false;
    public bool checkon = false;
    public bool meatingSpot12;
    public bool item1 = false;
    public bool burnenemy = false;
    public bool hasTorch = false;
    public GameObject checkongo;
    public GameObject meatingSpot;
    public GameObject torch;
    public GameObject game;
    public int flag = 1;

    Vector3 pos;
    bool spawned = false;
    public float exposure = 1.5f;
    float night = 0.015f;
    float day = 1.5f;
    public int hp = 3;
    public GameObject hpGo;
    
    
       
    
    public List<GameObject> wobbs = new List<GameObject>();
    private void Awake()
    {
        Instance = this;
        flag = 1;
    }

    void Start()
    {
        game.SetActive(false);
        SetState(GameState.Menu);
        exposure = day;
        RenderSettings.skybox.SetFloat("_Exposure", exposure);
        DynamicGI.UpdateEnvironment();
    }
    public void SetState(GameState newState)
    {
        currentState = newState;

        switch (newState)
        {
            case GameState.Menu:
                Time.timeScale = 1;
                sadf.SetActive(true);
                maincamera.SetActive(true);
                puzzleCamera.SetActive(false);
                book.SetActive(false);
                hpGo.SetActive(false);
                tasklist.SetActive(false);
                break;
            case GameState.Playing:
                Time.timeScale = 1;
                sadf.SetActive(false);
                maincamera.SetActive(true);
                puzzleCamera.SetActive(false);
                book.SetActive(false);
                hpGo.SetActive(true);
                tasklist.SetActive(true);
                break;
            case GameState.Paused:
                Time.timeScale = 0;
                maincamera.SetActive(true);
                puzzleCamera.SetActive(false);
                book.SetActive(false);
                tasklist.SetActive(true);
                sadf.SetActive(false);
                break;
            case GameState.GameOver:
                Time.timeScale = 0;
                maincamera.SetActive(true);
                puzzleCamera.SetActive(false);
                book.SetActive(false);
                tasklist.SetActive(false);
                sadf.SetActive(false);
                break;
            case GameState.book:
                maincamera.SetActive(true);
                puzzleCamera.SetActive(false);
                book.SetActive(true);
                tasklist.SetActive(false);
                sadf.SetActive(false);
                Time.timeScale = 0;
                break;
            case GameState.puzzle:
                Time.timeScale = 1;
                maincamera.SetActive(false);
                puzzleCamera.SetActive(true);
                book.SetActive(false);
                hpGo.SetActive(false);
                tasklist.SetActive(false);
                sadf.SetActive(false);
                break;
            case GameState.cutscene:
                df.cutcenea();
                hpGo.SetActive(false);
                tasklist.SetActive(false);
                sadf.SetActive(true);
                break;

        }


    }
    void Update()
    {

        if(burnenemy && hasTorch)
        {
           
            if (Input.GetKeyDown(KeyCode.E))
            {
                torch.SetActive(false);
                enemyend();
                flag++;
                TriggerManager.instance.ssd(flag);
                hasTorch = false;
            }
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

        if (debugMode)
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                enemytest.SetActive(true);
            }
            if (Input.GetKeyDown(KeyCode.T))
            {
                simonsays();
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
    }
    //public void show()
    //{
    //    if (first)
    //    {
    //        checkongo.SetActive(true);

    //    }

    //}
    //public void show2()
    //{
    //    if (checkongo)
    //    {
    //        meatingSpot.SetActive(true);

    //    }

    //}
  
    public void startGame()
    {
        game.SetActive(true);
        SetState(GameState.Playing);
    }

    public void simonsays()
    {
        simonSay.SetActive(true);
        combo = 0;

    }
    public void startCutscen()
    {
        SetState(GameState.cutscene);
    }
    public void KeyDilePuzzle()
    {
        keypuzzel.SetActive(true);
        currentState = GameState.puzzle;
        SetState(GameState.puzzle);
    }
    public void MirrorPuzzle()
    {
        mirror1.SetActive(true);
        mirror2.SetActive(true);
        mirrorPuzzle.SetActive(true);
        foreach (Transform child in mirrorPuzzle.transform)
        {
            child.gameObject.SetActive(true);
        }
        if (spawned == false)
        {
            pos = new Vector3(2.11025f, 2.33918f, -12.38297f);
            Instantiate(burnebleprefab, pos, transform.rotation);
            spawned = true;
        }

    }
    public void collerConectPuzzleFn()
    {
        orbdestoryed = 0;
        collerConectPuzzle.SetActive(true);

        foreach (Transform child in collerConectPuzzle.transform)
        {
            child.gameObject.SetActive(true);
        }
        currentState = GameState.puzzle;
        SetState(GameState.puzzle);
    }
    public void puzzlecompleted()
    {
        Debug.Log("puzzle finished");
        currentState = GameState.Playing;
        SetState(GameState.Playing);
        mirror1.SetActive(false);
        mirror2.SetActive(false);
        flag++;
        TriggerManager.instance.ssd(flag);
        
    }
    public void mirrorpuzzlecompleted()
    {
        mirrorPuzzle.SetActive(false);
        mirror1.SetActive(false);
        mirror2.SetActive(false);
        spawned = false;
        //flag++;
        //TriggerManager.instance.ssd(flag);
    }
    public void enemyshow12()
    {
        enemytest.SetActive(true);
    }
    public void enemyend()
    {
        enemytest.SetActive(false);
    }
    public void setday()
    {
        exposure = day;
        RenderSettings.skybox.SetFloat("_Exposure", exposure);
        DynamicGI.UpdateEnvironment(); // Updates ambient lighting
    }
    public void setnight()
    {
        exposure = night;
        RenderSettings.skybox.SetFloat("_Exposure", exposure);
        DynamicGI.UpdateEnvironment(); // Updates ambient lighting
    }
}
