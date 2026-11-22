using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject greenEnemy, whiteEnemy, greenBullet, whiteBullet; // All the prefabs for the enemies
    public static float spawnDelay = 1.5f;
    public float bulletDelay = 1f;

    // When the enemy is enabled from the EnemySpawner then it starts attacking the player
    private void OnEnable()
    {
        if (this.gameObject.activeSelf)
        {
            Invoke("AttackPlayer", bulletDelay);
        }
    }

    // This is the function for the enemies to shoot at the player
    public void AttackPlayer()
    {
        // If the enemy is green then it spawns a green bullet at the enemy ship
        if (gameObject == greenEnemy)
        {
            GameObject bullet = SpawnBullet(greenBullet);

            bullet.transform.position = transform.position;

            CheckIfActive(bullet);
        }
        else if (gameObject == whiteEnemy) // If the enemy is white then it spawns a white bullet at the enemy ship
        {
            GameObject bullet = SpawnBullet(whiteBullet);

            bullet.transform.position = transform.position;

            CheckIfActive(bullet);
        }
    }

    public GameObject SpawnBullet(GameObject bullet)
    {
        return Instantiate<GameObject>(bullet, this.transform.position, Quaternion.Euler(90, 0, 0));
    }

    // If the enemy ship is active then it will continue to spawn Enemy bullets
    public void CheckIfActive(GameObject bullet)
    {
        if (this.gameObject.activeSelf)
        {
            Invoke("AttackPlayer", bulletDelay);
        }
        else if (!this.gameObject.activeSelf)
        {
            Destroy(bullet);
        }
    }
}