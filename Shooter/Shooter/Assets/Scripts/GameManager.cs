using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int score;
    public float spawnDistance;
    public GameObject player;
    public GameObject playerPrefab;
    public List<GameObject> enemyList;
    public List<GameObject> enemyPrefabList;
    public List<Transform> spawnPointList;

    public List<GameObject> enemy2List;
    public List<GameObject> gunnerPrefabList;
    public List<Transform> spawn2List;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            enemyList = new List<GameObject>();
        }
        else
        {
            Destroy(this.gameObject);
            Debug.LogError("[GameManager] Attempted to create a second Game Manager: " + this.gameObject.name);
        }
        
        
    }

    void Start()
    {
        SpawnPlayer();
    }
    private void SpawnEnemy()
        {
            //Pick a random enemy to spawn
            GameObject enemyToSpawn = enemyPrefabList[Random.Range(0, enemyPrefabList.Count)];

            //Pick a random point to spawn it

            Transform spawnPoint = spawnPointList[Random.Range(0, spawnPointList.Count)];

            //Pick a point within distance of spawn point to spawn at
            Vector3 randomVector = Random.insideUnitCircle;
            Vector3 newPosition = spawnPoint.position + randomVector * spawnDistance;

            //Instantiate the selected enemy at the selected position
            Instantiate(enemyToSpawn, newPosition, Quaternion.identity);
        }

        private void SpawnGunner()
        {
            //Pick up the gunner asset to spawn (Multiple assets if more are added by designer)
            GameObject gunnerToSpawn = gunnerPrefabList[Random.Range(0, gunnerPrefabList.Count)];

            //Pick a random point to spawn it

            Transform spawnPoint2 = spawn2List[Random.Range(0, spawn2List.Count)];

            Vector3 gunPosition = spawnPoint2.position;

            //Instantiate the selected enemy at the selected position
            Instantiate(gunnerToSpawn, gunPosition, Quaternion.identity);
        }

    private void Update()
    {
        if (player != null)
        {
        //Spawn a new enemy if we have less than 3 enemies
            if (enemyList.Count < 3)
            {
                SpawnEnemy();
            }

            if (enemy2List.Count < 1)
            {
                SpawnGunner();
            }
        }
    }

    private void SpawnPlayer()
    {
        if (player != null)
            {
                player = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
            }
    }


    public void DestroyAllEnemies()
    {
        foreach(GameObject enemy in enemyList)
        {
            Destroy(enemy);
        }
    }
}
