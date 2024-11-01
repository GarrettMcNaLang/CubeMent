using UnityEngine;

public class PlayerObject : MonoBehaviour
{
    Rigidbody2D rb;

    public float PlayerSpeed;

    Vector2 Direction;


    bool VMoving;
    bool HMoving;

    bool CanPress;
    

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

        
            if (Input.GetAxisRaw("Vertical") != 0)
            {
                VMoving = false;
                VerticalMov();
            }
            VMoving = true;

            if (Input.GetAxisRaw("Horizontal") != 0)
            {

                HMoving = false;
                HorizontalMov();
            }
            HMoving = true;
                    
        
            

        
       

    }

    void FixedUpdate()
    {

        
        rb.MovePosition(rb.position + (Direction));

        if(rb.linearVelocityX == 0 && rb.linearVelocityY == 0)
        {
            CanPress = true;
        }
        else
        {
            CanPress = false;
        }

        

        

        //rb.Move(Vector3.left * PlayerSpeed, Quaternion.identity);
    }

    public void VerticalMov()
    {
        Direction = new Vector2(0, Input.GetAxisRaw("Vertical") * PlayerSpeed * Time.deltaTime);
    }

    public void HorizontalMov()
    {
        Direction = new Vector2(Input.GetAxisRaw("Horizontal") * PlayerSpeed * Time.deltaTime, 0);
    }


    

}
