using UnityEngine;

public class ThreeWay : OneWayLogicScript
{
    public GameObject spriteRenderer;
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
                    
                    UP.enabled = false;
                    
                    spriteRenderer.transform.Rotate(Vector3.forward * 0f);
                    break;
                }
            case Direction.Down:
                {
                    Debug.Log("Player should be moving UP");
                    DOWN.enabled = false;
                    spriteRenderer.transform.Rotate(Vector3.forward * 180f);
                    break;
                }
            case Direction.Left:
                {
                    Debug.Log("Player should be moving Right");
                   
                    LEFT.enabled = false;
                    spriteRenderer.transform.Rotate(Vector3.forward * 90f);
                    break;
                }
            case Direction.Right:
                {
                    Debug.Log("Player should be moving Left");
                   
                    RIGHT.enabled = false;
                    spriteRenderer.transform.Rotate(Vector3.forward * -90f);
                    break;
                }
        }
    }
}
