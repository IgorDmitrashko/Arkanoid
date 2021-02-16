using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    public UnityEvent ImpactEvent;

    private RaycastHit _hitInfo;
    private Vector3 _pointer;

    private float _speed = .5f;
    private Ball _ball;

    private const float _leftmostPoint = 2.5f;
    private const float _rightmostPoint = 17.22f;
    private float _mzCord;

    private Vector3 _moveLimited;
    private Rigidbody _rigidbody;

    Vector3 mousePoint;

    private void Awake() {
       
    }

    void Start() {
        _moveLimited.y = .5f;
        _moveLimited.z = 3.08f;
    }

    private float HitFactor(Vector3 ball, Vector3 player, float playerWidth) {
        return (ball.x - player.x) / playerWidth;
    }

    private void OnCollisionEnter(Collision collision) {
        collision.collider.gameObject.CompareTag("Ball");
        {
            if(_ball == null) _ball = collision.collider.GetComponent<Ball>();
            if(_ball != null)
            {
                float x = HitFactor(_ball.transform.position, transform.position, collision.collider.bounds.size.x);
                _ball.BounceZ(x);
            }
        }
        ImpactEvent?.Invoke();
    }

    private Vector3 Move() {
        _mzCord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        mousePoint = Input.mousePosition;
        mousePoint.z = _mzCord;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    private void LateUpdate() {
        transform.position = Move();
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, _leftmostPoint, _rightmostPoint), _moveLimited.y, _moveLimited.z);
    } 
}
