using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class VictoryTile : MonoBehaviour
{
    //bool _DidPlayerWin;

    //public bool DidPlayerWin
    //{
    //    get { return _DidPlayerWin; }

    //    set { _DidPlayerWin = value;
    //        if (_DidPlayerWin == true)
    //        {

    //            ActivateVictory(true);
                
    //        }
            
    //    }
    //}

  
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("is Triggered");
        if (collision.gameObject.TryGetComponent<PlayerObject>(out PlayerObject player))
        {
            //if the player is still and triggering the object

            Debug.Log(player.name);
            if (player.isStill)
            {

                GM.Instance.VictoryCondition();
                

            }//if the player is still moving but triggering the object
         
            //ActivateVictory(DidPlayerWin);
        }


    }

   
   
}
