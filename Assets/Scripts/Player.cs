using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour {
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float paddingTop = 1f;
    [SerializeField] float paddingBottom = 1f;
    [SerializeField] float paddingLeft = .5f;
    [SerializeField] float paddingRight = .5f;
    [SerializeField] GameObject laserPrefab;

    Vector2 rawInput;
    Vector2 minBounds;
    Vector2 maxBounds;

    Shooter shooter;

    void Awake() {
        shooter = GetComponent<Shooter>();
    }
    
    void Start() {
        SetUpMoveBoundaries();
    }

    void Update() {
        Move();
    }

    void OnMove (InputValue value) {
        rawInput = value.Get<Vector2>();
    }

    void OnFire (InputValue value) {
        if(shooter != null) {
            shooter.isFiring = value.isPressed;
        }
    }

    private void SetUpMoveBoundaries() {
        Camera camera = Camera.main;

        minBounds = camera.ViewportToWorldPoint(new Vector2(0, 0));
        maxBounds = camera.ViewportToWorldPoint(new Vector2(1, 1));
    }

    private void Move () {
        Vector3 delta = rawInput * moveSpeed * Time.deltaTime;

        var newXPos = Mathf.Clamp(transform.position.x + delta.x, minBounds.x + paddingLeft, maxBounds.x - paddingRight);
        var newYPos = Mathf.Clamp(transform.position.y + delta.y, minBounds.y + paddingBottom, maxBounds.y - paddingTop);

        transform.position = new Vector2(newXPos, newYPos);
    }
}
