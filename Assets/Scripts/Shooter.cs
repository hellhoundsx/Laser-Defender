using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("General")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float baseFiringRate = .2f;

    [Header("AI")]
    [SerializeField] bool useAI;
    [SerializeField] float AIFireVariable = .5f;
    [SerializeField] float minFiringSpeed = .1f;


    [HideInInspector]
    public bool isFiring;

    Coroutine firingCoroutine;

    void Start() {
        if(useAI) {
            isFiring = true;
        }
    }

    void Update() {
        Fire();
    }

    private float GetProjectileFiringPeriod () {
        if(useAI) {
            float randomTime = Random.Range(
                baseFiringRate - AIFireVariable,
                baseFiringRate + AIFireVariable
            );

            return Mathf.Clamp(randomTime, minFiringSpeed, float.MaxValue);
        } else {
            return baseFiringRate;
        }
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
                rb.velocity = transform.up * projectileSpeed;
            }

            yield return new WaitForSeconds(GetProjectileFiringPeriod());
        }
    }
}
