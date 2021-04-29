using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour {
    [SerializeField] WaveConfig waveConfig;
    List<Transform> waypoints;
    [SerializeField] float moveSpeed = 2f;
    int waypointIndex = 0;

    void Start() {
        waypoints = waveConfig.geWaypoints();

        if(waypoints.Count > 0) {
            transform.position = waypoints[waypointIndex].transform.position;
        }
    }

    void Update() {
        if(waypoints.Count > 0) {
            Move();
        }
    }

    private void Move() {
        if (waypointIndex < waypoints.Count - 1) {
            var targetPosition = (Vector2)waypoints[waypointIndex + 1].transform.position;
            var movementThisFrame = moveSpeed * Time.deltaTime;

            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);

            Debug.Log(transform.position);
            Debug.Log(targetPosition);

            if((Vector2)transform.position == targetPosition) {
                waypointIndex++;
            }
        } else {
            Destroy(gameObject);
        }
    }
}
