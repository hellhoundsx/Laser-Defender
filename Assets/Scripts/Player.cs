using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float padding = 1f;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] GameObject laserPrefab;
    [SerializeField] float projectileFiringPeriod = 0.1f;

    Coroutine firingCoroutine;

    float xMin;
    float xMax;
    float yMin;
    float yMax;

    // Start is called before the first frame update
    void Start() {
        SetUpMoveBoundaries();
    }

    // Update is called once per frame
    void Update() {
        Move();
        Fire();
    }



    private void SetUpMoveBoundaries() {
        Camera camera = Camera.main;

        xMin = camera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        xMax = camera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
        yMin = camera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = camera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }
    private void Fire() {
        if (Input.GetButtonDown("Fire1")) {
            firingCoroutine = StartCoroutine(FireContinuosly());
        }
        if (Input.GetButtonUp("Fire1")) {
            StopCoroutine(firingCoroutine);
        }
    }

    IEnumerator FireContinuosly() {
        while(true) {
            GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity);

            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);

            yield return new WaitForSeconds(projectileFiringPeriod);
        }
    }

    private void Move () {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        var newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        var newYPos = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);

        gameObject.transform.position = new Vector2(newXPos, newYPos);
    }

}
