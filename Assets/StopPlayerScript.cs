using UnityEngine;

public class StopPlayerScript : MonoBehaviour
{
    PlayerObject Playerparent;
    private void Awake()
    {
        Playerparent = GetComponentInParent<PlayerObject>();
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(PlayerObject.VelocityResetTag))
        {
            Playerparent.Direction = Vector2.zero;
            Playerparent.CanPress = true;
            Playerparent.isStill = true;

            this.gameObject.SetActive(false);
        }

        
    }
}
