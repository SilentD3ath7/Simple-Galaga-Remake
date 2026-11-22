using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject greenEnemy, whiteEnemy;
        public int size;
    }

    #region Singleton

    public static EnemyPooler Instance;
    private void Awake()
    {
        Instance = this;
    }

    #endregion

    public List<Pool> poolList;
    public Dictionary<string, Queue<GameObject>> spawner;

    // Start is called before the first frame update
    void Start()
    {
        spawner = new Dictionary<string, Queue<GameObject>>();

        // A loop to instantiate a green or white enemy prefab (chosen at random) based on the size from the Pool class
        foreach (Pool pool in poolList)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                int randNum = Random.Range(0, 2); // Rand num generator that is either 0 or 1

                if (randNum == 0) // If num is 0 then it spawns a green enemy
                {
                    GameObject obj = Instantiate(pool.greenEnemy);
                    obj.SetActive(false);
                    objectPool.Enqueue(obj);
                }
                else if (randNum == 1) // If num is 1 then it spawns a white enemy
                {
                    GameObject obj = Instantiate(pool.whiteEnemy);
                    obj.SetActive(false);
                    objectPool.Enqueue(obj);
                }
            }
            spawner.Add(pool.tag, objectPool);
        }
    }

    // This will set the enemy to active when called from the EnemySpawner script
    public GameObject SpawnFromPool(string tag, Vector3 pos, Quaternion rot)
    {
        if (!spawner.ContainsKey(tag))
        {
            Debug.LogError("Pool with tag " + tag + " doesn't exist.");
            return null;
        }

        GameObject objectToSpawn = spawner[tag].Dequeue();

        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = pos;
        objectToSpawn.transform.rotation = rot;

        spawner[tag].Enqueue(objectToSpawn);

        return objectToSpawn;
    }
}
