using System.Collections;
using UnityEngine;

public class VictoryTile : MonoBehaviour
{
    bool _DidPlayerWin;

    public bool DidPlayerWin
    {
        get { return _DidPlayerWin; }

        set { _DidPlayerWin = value;
            if (_DidPlayerWin == true)
                ActivateVictory(true);
            else if(_DidPlayerWin == false)
                ActivateVictory(false);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("is Triggered");
        if (collision.gameObject.TryGetComponent<PlayerObject>(out PlayerObject player))
        {
            //if the player is still and triggering the object

            Debug.Log(player.name);
            if (player.isStill == true)
            {

                DidPlayerWin = true;

            }//if the player is still moving but triggering the object
            else if (player.isStill == false)
            {
                Debug.Log("player should be still and should activate function");
                DidPlayerWin = false;
                //StartCoroutine(WaitUntilTrue(player));
            }
            Debug.Log(DidPlayerWin);
            //ActivateVictory(DidPlayerWin);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Debug.Log("Exiting trigger");
        DidPlayerWin = false;
    }

    public void ActivateVictory(bool VCondition)
    {
        //Debug.Log("is this function activated");
        if(VCondition)
        {
            GM.Instance.VictoryCondition();
        }
        else
        {
            Debug.Log("Do Not Activate Victory Condition");
            return;
        }
        
    }
}
