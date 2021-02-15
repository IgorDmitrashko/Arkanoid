using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour, IPointerClickHandler
{
    public UnityEvent ImpactEvent;
    public event Action MouseClickEvent;

    private RaycastHit _hitInfo;
    private Vector3 _pointer;

    private float _speed = .5f;
    private Ball _ball;

    private const float _leftmostPoint = 2.5f;
    private const float _rightmostPoint = 17.22f;

    private Vector3 _moveLimited;
    private Rigidbody _rigidbody;

    Vector3 hitPoint;

    private void Awake() {
        //_rigidbody = GetComponent<Rigidbody>();
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
            _ball = collision.collider.GetComponent<Ball>();
            float x = HitFactor(_ball.transform.position, transform.position, collision.collider.bounds.size.x);
            _ball.BounceZ(x);
        }
        ImpactEvent?.Invoke();
    }

    private void Move() {
        Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(_ray, out _hitInfo, 100f))
        {
            _pointer = Camera.main.ScreenToWorldPoint(_hitInfo.transform.position);
            transform.Translate(_pointer * _speed);
        }
    }

    private void LateUpdate() {
        Move();
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, _leftmostPoint, _rightmostPoint), _moveLimited.y, _moveLimited.z);
    }

    public void OnPointerClick(PointerEventData eventData) {
        MouseClickEvent?.Invoke();
    }
}
