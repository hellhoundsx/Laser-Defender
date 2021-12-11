using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileFiringPeriod = 0.1f;

    Coroutine firingCoroutine;

    public bool isFiring;

    void Start() {
        
    }

    void Update() {
        Fire();
    }


    private void Fire() {
        if (isFiring && firingCoroutine == null) {
            firingCoroutine = StartCoroutine(FireContinuosly());
        } else if(!isFiring && firingCoroutine != null) {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
    }
    
    IEnumerator FireContinuosly() {
        while(true) {
            GameObject laser = Instantiate(
                projectilePrefab,
                transform.position,
                Quaternion.identity
            );

            Rigidbody2D rb = laser.GetComponent<Rigidbody2D>();

            if (rb != null) {
                rb.velocity = new Vector2(0, projectileSpeed);
            }

            yield return new WaitForSeconds(projectileFiringPeriod);
        }
    }
}
