using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
//using UnityEngine.UIElements;

public class GM : MonoBehaviour
{
    private int _LevelsCompleted;

    public int LevelsCompleted
    {
        get { return _LevelsCompleted; }

        set { _LevelsCompleted = value; }
    }

    [SerializeField]
    Converter ToConvert;



    [SerializeField]
    Dictionary<string, LevelInfo> NewLevelsContainer;


    public static GM Instance;


    public static Action OnPlayerDeath;

    public static Action<PlayerObject> GetActivePlayer;

    public Button ResetButton;

    public Button NextLevelButton;

    public enum Levels 
    {One = 1, Two, Three };

    public Levels Currlevel;

    public String FinalLevel;

    [HideInInspector]
    public PlayerSpawnSpace CurrSpawner;
    [HideInInspector]
    public GameObject CurrCameraPosition;

    PlayerObject CurrPlayer;

    GameObject CameraObj;

    public GameObject PlayerObjectPrefab;
    

    private void Awake()
    {
        Instance = this;

        DontDestroyOnLoad(gameObject);

        

        NewLevelsContainer = ToConvert.ConvertToDictionaryLevels();

        CurrPlayer = Instantiate(PlayerObjectPrefab).GetComponent<PlayerObject>();

        if(CurrPlayer != null)
        {
            Debug.Log("Player Exists");
        }

        
    }

    private void OnEnable()
    {
        OnPlayerDeath += InitiateGameOver;

        GetActivePlayer += ActivatePlayer;

       
    }

    private void OnDisable()
    {
        OnPlayerDeath -= InitiateGameOver;

        GetActivePlayer -= ActivatePlayer;
    }

    #region UI
    public void ButtonActionOnClick(int Level)
    {
        switch ((Levels)Level)
        {
            case Levels.One:
                Currlevel = Levels.One;
                break;

            case Levels.Two:
                Currlevel = Levels.Two;
                break;

            case Levels.Three:
                Currlevel = Levels.Three;
                break;
        }

        LevelTransition(Currlevel);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ActivatePanel(GameObject panel)
    {
       panel.SetActive(true);
    }

    public void DeactivatePanel(GameObject panel)
    {
        panel.SetActive(false);
    }

    #endregion
    public void InitiateGameOver()
    {
        ResetButton.image.color = Color.red;
        TextMeshProUGUI buttontext = ResetButton.GetComponentInChildren<TextMeshProUGUI>();
        buttontext.color = Color.white;

        Time.timeScale = 0.0f;
    }

  
    public void ResetLogic()
    {
        ResetButton.image.color = Color.white;

        TextMeshProUGUI buttontext = ResetButton.GetComponentInChildren<TextMeshProUGUI>();

        buttontext.color = Color.black;

        ActivatePlayer(CurrPlayer);

        Time.timeScale = 1.0f;

       

    }

    public void BeginLevel()
    {
        ActivatePlayer(CurrPlayer);

        NewLevelsContainer[Currlevel.ToString()].CurrSpawner.SpawnerFunction(CurrPlayer);
        
        CameraObj.transform.position = NewLevelsContainer[Currlevel.ToString()].CameraPosition.transform.position;




    }

    public void LevelTransition(Levels CurrLevel)
    {
        var CurrString = CurrLevel.ToString();
        Debug.Log("Transition Level Functionality");
        CurrCameraPosition = NewLevelsContainer[CurrString].CameraPosition;

        CurrSpawner = NewLevelsContainer[CurrString].CurrSpawner;
        

        BeginLevel();
    }

  

    public void ActivatePlayer(PlayerObject aPlayer)
    {
        Debug.Log("Current Player Acquired");
        aPlayer.gameObject.SetActive(true);
       
    }

   
}

[Serializable]
public class Converter
{
    [SerializeField]
    public LevelObj[] Levels;

    public Dictionary<string, LevelInfo> ConvertToDictionaryLevels()
    {
        Dictionary<string, LevelInfo> newDic = new Dictionary<string, LevelInfo>();

        foreach (var Stp in Levels)
        {
            newDic.Add(Stp.currLevelNum, Stp.CurrLevel);
        }

        return newDic;
    }
}

[Serializable]
public class LevelObj
{
    [SerializeField]
    public string currLevelNum;

    [SerializeField]
    public LevelInfo CurrLevel;


}

[Serializable]
public class LevelInfo
{
    [SerializeField]
    public GameObject CameraPosition;
    [SerializeField]
    public PlayerSpawnSpace CurrSpawner;
}