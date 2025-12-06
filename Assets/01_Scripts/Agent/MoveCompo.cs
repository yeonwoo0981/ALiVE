using UnityEngine;
using UnityEngine.InputSystem;

namespace _01_Scripts.Agent
{
    public class MoveCompo : MonoBehaviour
    {
        [field:SerializeField] public float Speed { get; set; } = 5f;
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
            _rb.linearVelocity = _moveDir * Speed;
        }
    }
}