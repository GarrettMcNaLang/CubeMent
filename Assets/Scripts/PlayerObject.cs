using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerObject : MonoBehaviour
{

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
    Dictionary<string, GameObject> StopperDict;
    
  


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

        
    }

    void OnEnable()
    {
       

        CanPress = true;

        GM.GetActivePlayer(this);
    }

    private void OnDisable()
    {
        
        Debug.Log("Player should have returned to spawn");
    }

    // Update is called once per frame
    void Update()
    {
        if (CanPress)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                DetermineDirection(Controls.UP);
                
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                DetermineDirection(Controls.DOWN);
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                DetermineDirection(Controls.LEFT);
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                DetermineDirection(Controls.RIGHT);
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
                    DisableExceptOne("Up");
                    break;
                    
                    
                }
            case Controls.DOWN:
                {
                    Direction = Vector2.down * PlayerSpeed;
                    DisableExceptOne("Down");
                    break;
                   
                }
            case Controls.LEFT:
                {
                    Direction = Vector2.left * PlayerSpeed;
                    DisableExceptOne("Left");
                    break;

                    
                }
            case Controls.RIGHT:
                {
                    Direction = Vector2.right * PlayerSpeed;
                    DisableExceptOne("Right");
                    break;
                   
                }

            
            
        }
    }

    public void DisableExceptOne(String EnableThis) 
    {
        Debug.LogFormat("Trigger {0} Activated", EnableThis);
        StopperDict[EnableThis].SetActive(true);
    }
   
    public void ResetFunction()
    {
        this.gameObject.SetActive(false);
        Direction = Vector2.zero;
        CanPress = true;
        isStill = true;
        var spawner = GM.Instance.GetCurrentSpawner();
        this.gameObject.transform.position = spawner;
    }

}
[Serializable]
public class StopperDic
{
    [SerializeField]
    public StopperObj[] Stoppers;

    public Dictionary<string, GameObject> ConvertToDictionary()
    {
        Dictionary<string, GameObject> newDic = new Dictionary<string, GameObject>();

        foreach(var Stp in Stoppers)
        {
            newDic.Add(Stp.name, Stp.Stopper);
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