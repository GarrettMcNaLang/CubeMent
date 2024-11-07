using UnityEngine;

public class PlayerObject : MonoBehaviour
{

    public string VelocityResetTag = "StaticBorders";

    Rigidbody2D rb;

    public float PlayerSpeed;

    Vector2 Direction;

    public bool isStill;

    bool CanPress;

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

    }

    void OnEnable()
    {
        

        CanPress = true;
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

        var isMoving = rb.linearVelocity.sqrMagnitude;

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
                    Direction = Vector2.up * PlayerSpeed; break;
                }
            case Controls.DOWN:
                {
                    Direction = Vector2.down * PlayerSpeed; break;
                }
            case Controls.LEFT:
                {
                    Direction = Vector2.left * PlayerSpeed; break;
                }
            case Controls.RIGHT:
                {
                    Direction = Vector2.right * PlayerSpeed; break;
                }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == VelocityResetTag)
        {
            Direction = Vector2.zero;
            CanPress = true;
            isStill = true;
        }
    }

}
