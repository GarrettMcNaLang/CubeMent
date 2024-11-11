using UnityEngine;

public class EdgeScript : MonoBehaviour
{
    BoxCollider2D parent;
    private void Awake()
    {
        parent = GetComponentInParent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        parent.enabled = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        parent.enabled = true;
    }



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
