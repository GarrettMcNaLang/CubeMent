using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class OneWayLogicScript : MonoBehaviour
{

    //each direction isn't the way the collider faces, but where the player is able to move through
    

    //example, if it's UP, then the player will be able to move down through the space
    public EdgeCollider2D UP;
    //will be able to move up
    public EdgeCollider2D DOWN;
    //will be able to move right
    public EdgeCollider2D LEFT;
    //will be able to move left
    public EdgeCollider2D RIGHT;

    private void OnEnable()
    {
        SetDirectionFunc(SetDirection);
    }

    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }

    public Direction SetDirection;

    public void SetDirectionFunc(Direction dir)
    {
        switch (dir)
        {
            case Direction.Up:
                {
                    UP.transform.Rotate(0, 0, 180);
                    break;
                }
            case Direction.Down:
                {
                    DOWN.transform.Rotate(0, 0, -180);
                    break;
                }
            case Direction.Left:
                {
                    LEFT.transform.Rotate(0, 0, 270);
                    break;
                }
            case Direction.Right:
                {
                    RIGHT.transform.Rotate(0, 0, -270);
                    break;
                }
        }
    }
   

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collided");
        //collision.

    }


}
