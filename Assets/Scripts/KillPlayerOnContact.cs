using UnityEngine;

public class KillPlayerOnContact : MonoBehaviour
{
    private void Awake()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent<PlayerObject>(out PlayerObject player))
        {
            player.gameObject.SetActive(false);

            GM.OnPlayerDeath();

            Debug.Log("Player Should be dead");
        }
    }
}
