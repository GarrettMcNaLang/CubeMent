using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class OneWayLogicScript : MonoBehaviour
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

    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }

    public Direction SetDirection;

    public abstract void SetDirectionFunc(Direction dir);

    private void OnEnable()
    {
        SetDirectionFunc(SetDirection);
    }








}
