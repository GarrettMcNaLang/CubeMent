using UnityEngine;

public class AbsoluteOneWay : OneWayLogicScript
{
  public GameObject spriteRenderer;

 

    private void Awake()
    {
        

        

        
    }
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
                    LEFT.enabled = false;
                    RIGHT.enabled = false;
                    spriteRenderer.transform.Rotate(Vector3.forward * 0f);

                    break;
                }
            case Direction.Down:
                {
                    Debug.Log("Player should be moving UP");
                    DOWN.enabled = false;
                    LEFT.enabled = false;
                    RIGHT.enabled = false;
                    spriteRenderer.transform.Rotate(Vector3.forward * 180f);
                    break;
                }
            case Direction.Left:
                {
                    Debug.Log("Player should be moving Right");
                    UP.enabled = false;
                    DOWN.enabled = false;
                    LEFT.enabled = false;
                    spriteRenderer.transform.Rotate(Vector3.forward * 90f);
                    break;
                }
            case Direction.Right:
                {
                    Debug.Log("Player should be moving Left");
                    DOWN.enabled = false;
                    RIGHT.enabled = false;
                    UP.enabled = false;
                    spriteRenderer.transform.Rotate(Vector3.forward * -90f);
                    break;
                }
        }
    }
}
