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

    

    

    public GameObject[] Spawners;

    public PlayerObject CurrPlayer;
    

    private void Awake()
    {
        Instance = this;

        DontDestroyOnLoad(gameObject);

        

        NewLevelsContainer = ToConvert.ConvertToDictionaryLevels();
    }

    private void OnEnable()
    {
        OnPlayerDeath += InitiateGameOver;

        GetActivePlayer += GetCurrentPlayer;
    }

    private void OnDisable()
    {
        OnPlayerDeath -= InitiateGameOver;
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

        Time.timeScale = 1.0f;

        CurrPlayer.ResetFunction();

    }

    public void LevelTransition(int LevelNum)
    {
        
    }

    public void GetCurrentSpawner()
    {
        
    }

    public void GetCurrentPlayer(PlayerObject aPlayer)
    {
        CurrPlayer = aPlayer;
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