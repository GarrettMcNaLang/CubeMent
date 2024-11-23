using UnityEngine;

public class StopPlayerScript : MonoBehaviour
{

    public bool willStop = false;

    bool isTouching;
    public enum Sides
    {
        up,
        down,
        left,
        right,
    }

    public Sides side;
  
    PlayerObject Playerparent;
    private void Awake()
    {
        Playerparent = GetComponentInParent<PlayerObject>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("StaticBorders"))
        {
            if (willStop)
            {
                Playerparent.Direction = Vector2.zero;
                Playerparent.CanPress = true;
                Playerparent.isStill = true;
                willStop = false;
            }
            else if (!willStop)
            {
                
            }

            

            


        }
    }



    private void OnTriggerStay2D(Collider2D collision)
    {
        isTouching = true;

        Debug.Log(this.gameObject.name + "isTouching");
        Debug.Log("IsTouchingWall");
        if (collision.gameObject.CompareTag("StaticBorders"))
        {
            
                switch (side)
                {
                    case Sides.up:
                        {
                            Playerparent.UpLock = true;
                            break;
                        }
                    case Sides.down:
                        {
                            Playerparent.DownLock = true;
                            break;
                        }
                    case Sides.left:
                        {
                            Playerparent.LeftLock = true;
                            break;
                        }
                    case Sides.right:
                        {
                            Playerparent.RightLock = true;
                            break;
                        }
                }
            
           
        }
        

        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        switch (side)
        {
            case Sides.up:
                {
                    Playerparent.UpLock = false;
                    break;
                }
            case Sides.down:
                {
                    Playerparent.DownLock = false;
                    break;
                }
            case Sides.left:
                {
                    Playerparent.LeftLock = false;
                    break;
                }
            case Sides.right:
                {
                    Playerparent.RightLock = false;
                    break;
                }
        }
    }
}
