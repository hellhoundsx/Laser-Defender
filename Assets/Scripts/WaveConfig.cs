using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wave Config", fileName = "New Wave Config")]
public class WaveConfig : ScriptableObject {
    
    [SerializeField] List<GameObject> enemyPrefabs;
    [SerializeField] Transform pathPrefab;
    [SerializeField] float moveSpeed = 2f;
    [SerializeField] int enemyNumber = 5;
    [SerializeField] float timeBetweenEnemySpawns = 1f;
    [SerializeField] float spawnTimeVariance = 0.3f;
    [SerializeField] float minSpawnTime = 0.2f;

    public List<Transform> getWaypoints() { 
        var waypoints = new List<Transform>();

        foreach (Transform child in pathPrefab.transform) {
            waypoints.Add(child.transform);
        }

        return waypoints;
    }

    public Transform getStartingWaypoint() { return pathPrefab.GetChild(0); }
    
    public int getEnemyCount() { return enemyPrefabs.Count; }
    
    public GameObject getEnemyPrefab(int index) { return enemyPrefabs[index]; }

    public float getTimeBetweenEnemySpawns() { return timeBetweenEnemySpawns; }

    public float getRandomSpawnTime() { 
        float spawnTime = Random.Range(
            timeBetweenEnemySpawns - spawnTimeVariance,
            timeBetweenEnemySpawns + spawnTimeVariance
        );

        return Mathf.Clamp(spawnTime, minSpawnTime, float.MaxValue);
     }

    public float getMoveSpeed() { return moveSpeed; }

    public int getEnemyNumber() { return enemyNumber; }

}
