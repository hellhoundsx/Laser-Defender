using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wave Config")]
public class WaveConfig : ScriptableObject {
    
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject pathPrefab;
    [SerializeField] float timeBetweenSpawns = 0.5f;
    [SerializeField] float spawnRandomFactor = 0.3f;
    [SerializeField] float moveSpeed = 2f;
    [SerializeField] int enemyNumber = 5;

    public GameObject getEnemyPrefab() { return enemyPrefab; }

    public List<Transform> geWaypoints() { 
        var waveWaypoints = new List<Transform>();

        foreach (Transform child in pathPrefab.transform) {
            waveWaypoints.Add(child.transform);
        }

        return waveWaypoints;
    }

    public float getTimeBetweenSpawns() { return timeBetweenSpawns; }

    public float getSpawnRandomFactor() { return spawnRandomFactor; }

    public float getMoveSpeed() { return moveSpeed; }

    public int getEnemyNumber() { return enemyNumber; }

}
