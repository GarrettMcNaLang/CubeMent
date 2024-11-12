using UnityEngine;

public class PlayerSpawnSpace : MonoBehaviour
{
    public GameObject playerPrefab;

    public GameObject spawnPoint;

    private void OnEnable()
    {
        
        Instantiate(playerPrefab, this.transform.position, Quaternion.identity);
    }
}
