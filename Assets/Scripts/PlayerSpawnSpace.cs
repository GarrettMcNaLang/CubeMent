using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerSpawnSpace : MonoBehaviour
{
    

    public GameObject spawnPoint;

   

    public void SpawnerFunction(PlayerObject playerObject)
    {
        playerObject.transform.position = spawnPoint.transform.position;
    }
    
   
}
