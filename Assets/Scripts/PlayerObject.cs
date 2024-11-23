using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerObject : MonoBehaviour
{
    public bool LeftLock;
    public bool RightLock;
    public bool UpLock;
    public bool DownLock;

    public static string VelocityResetTag = "StaticBorders";

    Rigidbody2D rb;

    public float PlayerSpeed;

    public Vector2 Direction;

    public bool isStill;

    public bool CanPress;

   

    [SerializeField]
    string Stoppername;

    [SerializeField]
    StopperDic StopperDictionary;

   

    [SerializeField]
    Dictionary<string, StopPlayerScript> StopperDict;
    
  


    public enum Controls
    {
        UP,
        DOWN, 
        LEFT, 
        RIGHT   
    }

   
    

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        StopperDict = StopperDictionary.ConvertToDictionary();

        this.gameObject.SetActive(false);
    }

    void OnEnable()
    {
       

        CanPress = true;

        Direction = Vector3.zero;

        isStill = true;

        //GM.GetActivePlayer(this);
    }

    private void OnDisable()
    {
        CanPress = true;

        Direction = Vector3.zero;

        isStill = true;
        Debug.Log("Player should have returned to spawn");
    }

    // Update is called once per frame
    void Update()
    {
        if (CanPress)
        {
            if (Input.GetKeyDown(KeyCode.W) && !UpLock)
            {
                DetermineDirection(Controls.UP);
                StopperDict["Up"].willStop = true;
            }
            else if (Input.GetKeyDown(KeyCode.S) && !DownLock)
            {
                DetermineDirection(Controls.DOWN);
                StopperDict["Down"].willStop = true;
            }
            else if (Input.GetKeyDown(KeyCode.A) && !LeftLock)
            {
                DetermineDirection(Controls.LEFT);
                StopperDict["Left"].willStop = true;
            }
            else if (Input.GetKeyDown(KeyCode.D) && !RightLock)
            {
                DetermineDirection(Controls.RIGHT);
                StopperDict["Right"].willStop = true;
            }

            
        }
        
           
                    
        
            

        
       

    }

    

    void FixedUpdate()
    {



        rb.linearVelocity = Direction;

        //var isMoving = rb.linearVelocity.sqrMagnitude;

        //Debug.Log(isMoving);

        

        //rb.Move(Vector3.left * PlayerSpeed, Quaternion.identity);
    }

    public void DetermineDirection(Controls CurrInput)
    {
        isStill = false;
        CanPress = false;

        switch(CurrInput)
        {
            case Controls.UP:
                {
                    
                    Direction = Vector2.up * PlayerSpeed;
                    
                    break;
                    
                    
                }
            case Controls.DOWN:
                {
                    Direction = Vector2.down * PlayerSpeed;
                    
                    break;
                   
                }
            case Controls.LEFT:
                {
                    Direction = Vector2.left * PlayerSpeed;
                   
                    break;

                    
                }
            case Controls.RIGHT:
                {
                    Direction = Vector2.right * PlayerSpeed;
                   
                    break;
                   
                }

            
            
        }
    }

    //public void DisableExceptOne(String EnableThis) 
    //{
    //    Debug.LogFormat("Trigger {0} Activated", EnableThis);
    //    StopperDict[EnableThis].SetActive(true);
    //}
   
   

}
[Serializable]
public class StopperDic
{
    [SerializeField]
    public StopperObj[] Stoppers;

    public Dictionary<string, StopPlayerScript> ConvertToDictionary()
    {
        Dictionary<string, StopPlayerScript> newDic = new Dictionary<string, StopPlayerScript>();

        foreach(var Stp in Stoppers)
        {
            
            var StopperScript = Stp.Stopper.GetComponent<StopPlayerScript>();
            newDic.Add(Stp.name, StopperScript);
        }

        return newDic;
    }
}

[Serializable]
public class StopperObj
{
    [SerializeField]
    public string name;
    [SerializeField]
    public GameObject Stopper;
}