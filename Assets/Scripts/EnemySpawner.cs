using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    EnemyPooler pooler;

    // Start is called before the first frame update
    private void Start()
    {
        pooler = EnemyPooler.Instance;
        Invoke("SpawnBackup", Enemy.spawnDelay);
    }

    // I created this function so that I can use the Invoke method and delay the spawn rate
    public void SpawnBackup()
    {
        Vector3 randomSpawn = new Vector3(Random.Range(-Player.boundX, Player.boundX), Random.Range(0f, 4.5f), -0.3f);

        // Enables an enemy from the pooler at a random spot within the boundry
        pooler.SpawnFromPool("Enemy", randomSpawn, Quaternion.Euler(90, 0, 0));

        Invoke("SpawnBackup", Enemy.spawnDelay);
    }
}
