using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour {
    WaveConfig waveConfig;
    EnemySpawner enemySpawner;
    List<Transform> waypoints;
    int waypointIndex = 0;


    void Awake() {
        enemySpawner = FindObjectOfType<EnemySpawner>();
    }
    
    void Start() {
        waveConfig = enemySpawner.GetCurrentWave();
        waypoints = waveConfig.getWaypoints();

        if(waypoints.Count > 0) {
            transform.position = waypoints[waypointIndex].transform.position;
        }
    }

    void Update() {
        if(waypoints.Count > 0) {
            followPath();
        }
    }

    private void followPath() {
        // if we are not at the last waypoint
        if (waypointIndex < waypoints.Count - 1) {
            Vector3 targetPosition = waypoints[waypointIndex + 1].position;
            float delta = waveConfig.getMoveSpeed() * Time.deltaTime;

            transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta);

            if(transform.position == targetPosition) {
                waypointIndex++;
            }
        } else {
            Destroy(gameObject);
        }
    }
}
