using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigs;
    [SerializeField] float timeBetweenWaves = 3f;
    [SerializeField] bool isLooping = true;
    WaveConfig currentWave;


    void Start() {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies () {
        do {
            foreach(WaveConfig waveConfig in waveConfigs) {
                currentWave = waveConfig;

                for(int i = 0; i < currentWave.getEnemyCount(); i++){
                    Instantiate(
                        currentWave.getEnemyPrefab(i),
                        currentWave.getStartingWaypoint().position,
                        Quaternion.identity,
                        transform
                    );

                    yield return new WaitForSeconds(currentWave.getRandomSpawnTime());
                }

                yield return new WaitForSeconds(timeBetweenWaves);
            }
        } while (isLooping);
    }

    public WaveConfig GetCurrentWave() { return currentWave; }
}
