using UnityEngine;

public class AbsoluteOneWay : OneWayLogicScript
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void SetDirectionFunc(Direction dir)
    {
        switch (dir)
        {
            case Direction.Up:
                {
                    Debug.Log("Player Should be moving Down");
                    DOWN.enabled = false;
                    LEFT.enabled = false;
                    RIGHT.enabled = false;
                    break;
                }
            case Direction.Down:
                {
                    Debug.Log("Player should be moving UP");
                    UP.enabled = false;
                    LEFT.enabled = false;
                    RIGHT.enabled = false;
                    break;
                }
            case Direction.Left:
                {
                    Debug.Log("Player should be moving Right");
                    UP.enabled = false;
                    DOWN.enabled = false;
                    RIGHT.enabled = false;
                    break;
                }
            case Direction.Right:
                {
                    Debug.Log("Player should be moving Left");
                    DOWN.enabled = false;
                    LEFT.enabled = false;
                    UP.enabled = false;
                    break;
                }
        }
    }
}