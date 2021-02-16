using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Vector3 _direction;

    private float[] _directionCount = { -1f, -.5f, .5f, 1f };
    private float _speed = 5;

   [SerializeField] private ControlClickMouse clickMouse;
    private bool isBallMoving;

    private void Awake() {
        _rigidbody = GetComponent<Rigidbody>();
        if(clickMouse != null) clickMouse.MouseClickEvent += BallMoving;
    }

    void Start() {      
        _direction.x = _directionCount[Random.Range(0, _directionCount.Length)];
        _direction.z = 1;
    }

    private void BallMoving() {
        isBallMoving = true;
    }

    void Update() {
        if(isBallMoving) Move();
    }

    public void BounceX() {
        _direction.x = -_direction.x;
    }

    public void BounceZ() {
        _direction.z = -_direction.z;
    }
    public void AddSpeed() {
        _speed += 1;
    }

    public void BounceZ(float x) {
        _direction.x = x;
        _direction.z = -_direction.z;
    }

    private void OnCollisionEnter(Collision collision) {
        if(collision.collider.CompareTag("Border")) BounceX();
        else if(collision.collider.CompareTag("TopBorder")) BounceZ();
        else if(collision.collider.CompareTag("Lost")) BounceZ();

    }

    private void Move() {
        _rigidbody.velocity = _direction.normalized * _speed;
    }

    private void LostCount() {
        _direction.z = -_direction.z;
    }
}
