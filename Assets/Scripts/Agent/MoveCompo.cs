using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Agent
{
    public class MoveCompo : MonoBehaviour
    {
        [SerializeField] private float speed = 5f;
        private Rigidbody2D _rb;
        private Vector2 _moveDir;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void OnMove(InputValue value)
        {
            _moveDir = value.Get<Vector2>();
        }

        private void FixedUpdate()
        {
            _rb.linearVelocity = _moveDir * speed;
        }
    }
}