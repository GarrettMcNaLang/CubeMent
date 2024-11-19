using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Tilemaps;
using UnityEngine.UI;


public class GM : MonoBehaviour
{

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
    {One, Two, Three };

    public Levels Currlevel;

    [HideInInspector]
    public PlayerSpawnSpace CurrSpawner;
    [HideInInspector]
    public GameObject CurrCameraPosition;

    PlayerObject CurrPlayer;

    public PlayerObject PlayerObjectPrefab;
    

    private void Awake()
    {
        Instance = this;

        DontDestroyOnLoad(gameObject);

        

        NewLevelsContainer = ToConvert.ConvertToDictionaryLevels();

        CurrPlayer = Instantiate(PlayerObjectPrefab);

        
    }

    private void OnEnable()
    {
        OnPlayerDeath += InitiateGameOver;

        GetActivePlayer += ActivatePlayer;

        LevelTransition(Currlevel);
    }

    private void OnDisable()
    {
        OnPlayerDeath -= InitiateGameOver;

        GetActivePlayer -= ActivatePlayer;
    }


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

    public Vector3 GetCurrentSpawner()
    {
        Vector3 Spawner = Vector3.zero;

        switch(Currlevel)
        {
            case Levels.One:
            {
                  Spawner = NewLevelsContainer["One"].CurrSpawner.gameObject.transform.position;
                    Debug.Log("Level One Spawner Given");
                break;
            }
            case Levels.Two:
            {
                    Spawner = NewLevelsContainer["Two"].CurrSpawner.gameObject.transform.position;
                    Debug.Log("Level Two Spawner Given");
                    break;
            }
            case Levels.Three:
            {
                    Spawner = NewLevelsContainer["Three"].CurrSpawner.gameObject.transform.position;
                    Debug.Log("Level Three Spawner Given");
                    break;
            }


               
        }

       return Spawner;

    }

    public void LevelTransition(Levels CurrLevel)
    {
        var CurrString = CurrLevel.ToString();
        Debug.Log("Transition Level Functionality");
        CurrCameraPosition = NewLevelsContainer[CurrString].CameraPosition;

        CurrSpawner = NewLevelsContainer[CurrString].CurrSpawner;
        
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